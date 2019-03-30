//var app = angular.module("MyApp")

//function MainCtrl() {

//}
//angular
//  .module('app', [])
//  .controller('MainCtrl', MainCtrl);

app.controller('commissionCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Commission', function ($scope, $state, $stateParams, $modal, $log, Commission) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.groups = searchGroups();
    
    
    $scope.commission = null;
    $scope.readyToAdd = false;
    

    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
        }
    }, true);


    
    function searchCommissions() {

        Commission.search($scope.searchText)
        .then(function (data) {
            // console.log("stock");
            //console.log(Stock.stocks);
            console.log(data);
            $scope.commissions = Commission.commissions;

        });
    };

    // search Customer
    $scope.searchAnyCommission = function () {
        // alert($scope.searchText + 'scope');
        Commission.search($scope.searchText)
        .then(function (data) {
           
            $scope.commissions = Commission.commissions;

           
        });
    }

    $scope.commissionDetail = function (id) {
        if (id=="") return;
       
        Commission.commissionDetail(id)
           .then(function (data) {
               
               
               $scope.currentCommission = Commission.currentCommission;
               
               //console.log('$scope.currentGroup');
               //console.log($scope.currentGroup);
               //console.log(' end $scope.currentGroup');
               console.log($scope.currentCommission.sales_commission_id);
               var _id = $scope.currentCommission.sales_commission_id;
               $scope.readyToAdd = true;
               $state.go('commission.detail', { 'Id': id });

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteCommission = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Commission.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add Group
    $scope.addCommission = function () {
        //alert("group add");
        Commission.newCommission()
        .then(function (data) {
            $scope.commission = Commission.commission;
            $scope.commission.add = 1;
           // $scope.commission.commission_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editCommission = function () {
        $scope.commission = $scope.currentCommission;
        $scope.commission.add = 0;
        console.log($scope.currentCommission);
        //$scope.commission.gcommission_max = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/commission/AddEditCommission.html',
            controller: 'commissionModalCtrl',
            size: size,
            resolve: {
                commission: function () {
                    return $scope.commission;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentCommission = response;
            //console.log("response");
            //console.log(response);
            $state.go('commission.detail', { 'Id': response.commission_id });
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('commissionModalCtrl', ['$scope', '$modalInstance', 'Commission', 'commission', function ($scope, $modalInstance, Commission, commission) {

    $scope.commission = commission;  // get the data
   
    if (commission.commission_id == 1)
        $scope.headerTitle = 'Add commission';
    else
        $scope.headerTitle = 'Edit commission';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        Commission.Save($scope.commission).then(function (response) {
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
