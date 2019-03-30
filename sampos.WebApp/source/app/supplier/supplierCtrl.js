//var app = angular.module("MyApp")
app.controller('supplierCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Supplier', function ($scope, $state, $stateParams, $modal, $log, Supplier) {
    
    var Id = $stateParams.Id;


    $scope.searchText = '';
  


    $scope.supplier = null;
    $scope.readyToAdd = false;


    //$scope.$watch('searchText', function (newVal, oldVal) {
    //    if (newVal != oldVal) {

            
    //        // searchStocks();
    //    }
    //}, true);


    
   

    // search Suppliers
    
    $scope.searchAnySupplier = function () {
         
        Supplier.search($scope.searchText)
        .then(function (data) {
            
            
            $scope.suppliers = Supplier.suppliers;
        });
    }
        
    $scope.supplierDetail = function (id) {

        if (!id) return;
        
        Supplier.supplierDetail(id)
           .then(function (data) {
               
               
               $scope.currentSupplier = Supplier.currentSupplier;
               
               $scope.readyToAdd = true;
               $state.go('supplier.detail', { 'Id': id});

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteSupplier = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Supplier.delete(id)
            .then(function (data) {
               // console.log(data);
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').css({ "color": "red", "border": "2px solid red" });
                //$(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add supplier
    $scope.addSupplier = function () {
        //alert("supplier add");
        Supplier.newSupplier()
        .then(function (data) {
            $scope.supplier = Supplier.supplier;

            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editSupplier = function () {
        $scope.supplier = $scope.currentSupplier;
        console.log($scope.currentSupplier);

        $scope.open('lg');
    }

    

    // Open model to add edit supplier
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/supplier/AddEditSupplier.cshtml',
            controller: 'supplierModalCtrl',
            size: size,
            resolve: {
                supplier: function () {
                    return $scope.supplier;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentSupplier = response;
            console.log("response");
            console.log(response);
            $state.go('supplier.detail', { 'Id': response.supplier_id});
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('supplierModalCtrl', ['$scope', '$modalInstance', 'Supplier', 'supplier', function ($scope, $modalInstance, Supplier, supplier) {

    $scope.supplier = supplier;  // get the data
   
    if (supplier.id == 0)
        $scope.headerTitle = 'Add supplier';
    else
        $scope.headerTitle = 'Edit supplier';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        Supplier.Save($scope.supplier).then(function (response) {
            //console.log(response.data);
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    //---- Date Picker bits and pieces:

    //$scope.opend = function ($event, _Index) {

    //    if ($event) {
    //        // console.log($scope.status[_Index].opened + "date");

    //        $event.preventDefault();
    //        $event.stopPropagation();
    //    }
    //    $scope.status[_Index].opened = true;
    //    //alert($scope.status[_Index].opened);
    //    console.log($scope.status[_Index].opened + "date");
    //};
    //$scope.status = [
    //    { opened: false },
    //    { opened: false },
    //    { opened: false },
    //    { opened: false }];

    //$scope.dateOptions = {
    //    formatYear: 'yyyy',
    //    startingDay: 1,
    //    showWeeks: false,
    //    initDate: new Date()
    //};
    //$scope.formats = ['d/M/yyyy', 'dd/M/yyyy', 'd/MM/yyyy', 'dd/MM/yyyy'];
    //$scope.altInputFormats = ['d!/M!/yy', 'd!/M!/yyyy'];
    //$scope.format = $scope.formats[3];
    ////---- End Date picker stuff

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
