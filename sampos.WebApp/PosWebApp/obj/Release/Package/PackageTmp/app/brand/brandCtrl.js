//var app = angular.module("MyApp")
app.controller('brandCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Brand', function ($scope, $state, $stateParams, $modal, $log, Brand) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.brands = searchBrands();


    $scope.brand = null;
    $scope.readyToAdd = false;


    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
        }
    }, true);


    
    function searchBrands() {

        alert($scope.searchText);
        Brand.search($scope.searchText)
        .then(function (data) {
            // console.log("stock");
            //console.log(Stock.stocks);
            console.log(data);
            $scope.brands = Brand.brands;

        });
    };

    // search Customer
    $scope.searchAnyBrand = function () {
        // alert($scope.searchText + 'scope');
        Brand.search($scope.searchText)
        .then(function (data) {
            console.log(data);
            $scope.brands = Brand.brands;
        });
    }

    $scope.brandDetail = function (id) {

        if (!id) return;
        
        Brand.brandDetail(id)
           .then(function (data) {
               
               
               $scope.currentBrand = Brand.currentBrand;
              
               $scope.readyToAdd = true;
               $state.go('brand.detail', { 'Id': id});

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteBrand = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Brand.delete(id)
            .then(function (data) {
                console.log(data);
                var element = $event.currentTarget;
                
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add Brand
    $scope.addBrand = function () {
        //alert("brand add");
        Brand.newBrand()
        .then(function (data) {
            $scope.brand = Brand.brand;

            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editBrand = function () {
        $scope.brand = $scope.currentBrand;
        //console.log($scope.currentBrand);

        $scope.open('lg');
    }

    

    // Open model to add edit brand
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/brand/AddEditBrand.html',
            controller: 'brandModalCtrl',
            size: size,
            resolve: {
                brand: function () {
                    return $scope.brand;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentBrand = response;
            console.log("response");
            console.log(response);
            $state.go('brand.detail', { 'Id': response.brand_id});
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('brandModalCtrl', ['$scope', '$modalInstance', 'Brand', 'brand', function ($scope, $modalInstance, Brand, brand) {

    $scope.brand = brand;  // get the data
   
    if (brand.id == 0)
        $scope.headerTitle = 'Add Brand';
    else
        $scope.headerTitle = 'Edit Brand';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        Brand.Save($scope.brand).then(function (response) {
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
