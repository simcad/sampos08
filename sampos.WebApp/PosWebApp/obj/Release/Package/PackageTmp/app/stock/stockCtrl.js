//var app = angular.module("MyApp")
app.controller('stockCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Stock', function ($scope, $state, $stateParams, $modal, $log, Stock) {

    var Id = $stateParams.Id;
    
    
    $scope.searchText = '';
    $scope.stocks = null;//searchStocks();
   // $scope.stocks = searchAnyStock();
    $scope.contacts = [];
    $scope.stock = null;
    $scope.readyToAdd = false;
    //$scope.currentStock = null;
   // $scope.brand = LoadBrand();
    
    $scope.SubResizeScreen = function () {
        //     var _Header = $("header").height();
        //   var _margins = 120;
        //  var _Win = $(window).height() - _Header - _margins - $("#ButtonPanelContent").height();

        var _ht = $('#panelheightlist').height();
        $('#panelheight').height(_ht);



    };
    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
            if (newVal.length > 2 && newVal.length < 6) {
                 searchStocks();

                

            }
        }
    }, true);


    function LoadBrand() {
        
        Stock.brand("AC2")
        .then(function (data) {
            // console.log("brand");
            //console.log(Stock.stocks);
           // console.log(data);
            $scope.brands = Stock.brand;

        });
    };

    function searchStocks() {
        Stock.search($scope.searchText)
        .then(function (data) {
           // console.log("stock");
            //console.log(Stock.stocks);
            //console.log(data);
            $scope.stocks = Stock.stocks;
           // $scope.SubResizeScreen();
        });
    };

    // search Customer
    $scope.searchAnyStock = function () {
       // alert($scope.searchText + 'scope');
        Stock.search($scope.searchText)
        .then(function (data) {
            $scope.stocks = Stock.stocks;
           // $scope.SubResizeScreen();
        });
    }

    $scope.stockDetail = function (id,barcode) {
        if (!id) return;
    
        Stock.stockDetail(id,barcode)
           .then(function (data) {
               //console.log('stock detail check!')
               //console.log(data);
               
               $scope.currentStock = Stock.currentStock;
               if ($scope.currentStock.stock_last_transfer_date != null) {

                   $scope.currentStock.stock_last_transfer_date = new Date($scope.currentStock.stock_last_transfer_date).toString("yyyy-MM-dd");
               }
               
               //console.log('stock detail check date=::' + $scope.currentStock.stock_last_transfer_date);
               
               
               var _id = $scope.currentStock.idd;
               $scope.readyToAdd = true;
               $state.go('stock.detail', { 'Id': _id ,'barcode': barcode });
         
        });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);
    
    // Delete a customer and hide the row
    $scope.deleteCustomer = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Customer.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add Customer
    $scope.addStock = function () {
        Stock.newStock()
        .then(function (data) {
            $scope.stock = Stock.stock;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editStock = function () {
        $scope.stock = $scope.currentStock;
        
        $scope.open('lg');
    }

    // Utilities function

    //$scope.ApplyDateCorrectionToServer = function () {

    //    // Apply the fix to remoe TIME components from dates before sending data to the server
    //    if ($scope.stock.stock_last_transfer_date) {
    //        $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date).toString('yyyy-MM-dd');
    //    }
    //    else {
    //        $scope.stock.stock_last_transfer_date = null;
    //    }

        
    //    if ($scope.stock.stock_exp_date) {
    //        $scope.stock.stock_exp_date = new Date($scope.stock.stock_exp_date).toString('yyyy-MM-dd');
    //    }
    //    else {
    //        $scope.stock.stock_exp_date = null;
    //    }
        

    //}

    //$scope.ApplyDateCorrectionToScreen = function () {
    //    // Apply the fix to remove TIME components from dates before populating binding
    //    // Note: in order to keep the controls on screen from blanking, have them use a temp 
    //    //property that is not sent to the server...

    //    //$scope.Investigation.OutcomeDate

    //    if ($scope.stock.stock_last_transfer_date) {
    //        $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date);
    //    }
    //    else {
    //        $scope.stock.stock_last_transfer_date = null;
    //    }

    //    if ($scope.stock.stock_exp_date) {
    //        $scope.stock.stock_exp_date = new Date($scope.stock.stock_exp_date);
    //    }
    //    else {
    //        $scope.stock.stock_exp_date = null;
    //    }

        
    //}


    // Open model to add edit customer
    $scope.open = function (size) {        
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/stock/AddEditStock.html',
            controller: 'stockModalCtrl',
            size: size,
            resolve: {
                stock: function () {
                    return $scope.stock;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentStock = response;
            console.log("response");
            console.log(response);
            $state.go('stock.detail', { 'Id': response.idd, 'barcode': response.barcode });            
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

  

    
}]);

app.controller('stockModalCtrl', ['$scope', '$modalInstance', 'Stock', 'stock', function ($scope, $modalInstance, Stock, stock) {

    $scope.stock = stock;
    $scope.brands = Stock.brands;  // Stock will call the stockServices
    $scope.groups = Stock.groups;
    $scope.suppliers = Stock.suppliers;
    $scope.gsts = Stock.gsts;
    $scope.gstprice = 0.00;
    //console.log($scope.stock);
   
    $scope.initdesc = '';
    //$scope.$watch('stock.stock_model', function (newVal, oldVal,scope) {
    //   // if (newVal != oldVal) {
    //    $scope.initdesc = newVal;
    //    stock.stock_desc = newVal + '*' + oldVal;
    //   // }
    //}, true);
    $scope.addGST = function (_v, _gstrate) {

        if (_v == null) {
            return;
        }

        if ($scope.stock.idd == 0) {
            var lgst;
            lgst = 0.00;
            if ($scope.stock.tax_rate == null) {


            } else {
                _gstrate = $scope.stock.tax_rate;
            }

            lgst = _v * (1 + _gstrate / 100);
            $scope.gstprice = lgst.toFixed(2);

            $scope.stock.stock_GST_price = $scope.gstprice;
        }

    }

    $scope.setGST = function (_gst) {
        //alert(_gst);
        //console.log(_gst);
        $scope.stock.tax_rate = _gst;
    }
    $scope.getBarcode = function ($event) {
    
        if ($scope.stock.idd == 0) {
            
            Stock.getbarcode().then(function (data)
            {
                
                $scope.stock.barcode = data.data;
                var _today = new Date();
                $scope.stock.stock_last_transfer_date = _today;// .toString("yyyy-MM-dd");
                $scope.stock.stock_max_discount = 50;
                $scope.stock.tax_rate_id = 1;

            })
           
        }
    };
    $scope.getDesc = function () {

        if ($scope.stock.idd == 0 ) {

            $scope.stock.stock_desc = $scope.stock.brand_id + ' ' + $scope.stock.stock_model + ' ' + $scope.stock.stock_size + ' ' + $scope.stock.stock_colour;

            //$scope.stock.stock_desc = $scope.initdesc;
        }
    };
    //if ($scope.stock.stock_last_transfer_date != null) {
          //  $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date).toString('yyyy-MM-dd');
        //console.log("before save fixed:" + $scope.stock.stock_last_transfer_date);
    //}
    // $scope.ApplyDateCorrectionToScreen();

   // if ($scope.stock.stock_last_transfer_date) {
     //   $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date);
    //}
    //else {
      //  $scope.stock.stock_last_transfer_date = null;
    //}


    if (stock.idd > 0)
        $scope.headerTitle = 'Edit Stock';
    else
        $scope.headerTitle = 'Add Stock';

    

    
    $scope.save = function () {
       // console.log($scope.stock);
        
        //ApplyDateCorrectionToServer();

        // Apply the fix to remoe TIME components from dates before sending data to the server
        if ($scope.stock.stock_last_transfer_date !=null) {
            //console.log($scope.stock.stock_last_transfer_date);
            $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date).toString('yyyy-MM-dd');
         
        }
        
        
        Stock.Save($scope.stock).then(function (response) {
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    //---- Date Picker bits and pieces:

    $scope.opend = function ($event, _Index) {

        if ($event) {
           // console.log($scope.status[_Index].opened + "date");
            
            $event.preventDefault();
            $event.stopPropagation();
        }
        $scope.status[_Index].opened = true;
        //alert($scope.status[_Index].opened);
        console.log($scope.status[_Index].opened + "date");
    };
    $scope.status = [
        { opened: false },
        { opened: false },
        { opened: false },
        { opened: false }];

    $scope.dateOptions = {
        formatYear: 'yyyy',
        startingDay: 1,
        showWeeks: false,
        initDate: new Date()
    };
    $scope.formats = ['d/M/yyyy', 'dd/M/yyyy', 'd/MM/yyyy', 'dd/MM/yyyy'];
    $scope.altInputFormats = ['d!/M!/yy', 'd!/M!/yyyy'];
    $scope.format = $scope.formats[3];
    //---- End Date picker stuff

    //---- End Date picker stuff

  



}]);


$(document).ready(function () {


    //$("#last_date").datepicker({ changeMonth: true, changeYear: true });
    //$("#last_date").datepicker($.datepicker.regional["AU"]);
    //$("#last_date").datepicker("option", "altField", 'last_date');
    //$("#last_date").datepicker("option", "showOn", 'both');
    //$("#last_date").datepicker("option", "currentText", "Now");
    //$("#last_date").datepicker({ showWeek: true, firstDay: 1 });
    
    
});
//function ApplyDateCorrectionToServer () {

//    // Apply the fix to remoe TIME components from dates before sending data to the server
//    if ($scope.stock.stock_last_transfer_date) {
//        $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date).toString('yyyy-MM-dd');
//    }
//    else {
//        $scope.stock.stock_last_transfer_date = null;
//    }


//    if ($scope.stock.stock_exp_date) {
//        $scope.stock.stock_exp_date = new Date($scope.stock.stock_exp_date).toString('yyyy-MM-dd');
//    }
//    else {
//        $scope.stock.stock_exp_date = null;
//    }


//};
//function ApplyDateCorrectionToScreen () {
//    // Apply the fix to remove TIME components from dates before populating binding
//    // Note: in order to keep the controls on screen from blanking, have them use a temp 
//    //property that is not sent to the server...

//    //$scope.Investigation.OutcomeDate

//    if ($scope.stock.stock_last_transfer_date) {
//        $scope.stock.stock_last_transfer_date = new Date($scope.stock.stock_last_transfer_date);
//    }
//    else {
//        $scope.stock.stock_last_transfer_date = null;
//    }

//    if ($scope.stock.stock_exp_date) {
//        $scope.stock.stock_exp_date = new Date($scope.stock.stock_exp_date);
//    }
//    else {
//        $scope.stock.stock_exp_date = null;
//    }


//};
