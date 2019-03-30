//var app = angular.module("MyApp")

//function MainCtrl() {

//}
//angular
//  .module('app', [])
//  .controller('MainCtrl', MainCtrl);

app.controller('sysmessageCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Sysmessage', function ($scope, $state, $stateParams, $modal, $log, Sysmessage) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.groups = searchGroups();
    
    searchSysmessages();

    $scope.sysmessage = null;
    $scope.readyToAdd = false;
    

    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
        }
    }, true);


    
    function searchSysmessages() {

        Sysmessage.search($scope.searchText)
        .then(function (data) {
          
            
            $scope.sysmessages = Sysmessage.sysmessages;

        });
    };

    // search Customer
    $scope.searchAnySysmessage = function () {
         //alert($scope.searchText + 'scope');
        Sysmessage.search($scope.searchText)
        .then(function (data) {
           
            $scope.sysmessages = Sysmessage.sysmessages
            
           
        });
    }

    $scope.sysmessageDetail = function (id) {

      
        if (id < 0) return;
       
        Sysmessage.sysmessageDetail(id)
           .then(function (data) {
               
               
               
               $scope.currentSysmessage = Sysmessage.currentSysmessage;
               
               
               var _id = $scope.currentSysmessage.m_id;
               $scope.readyToAdd = true;
               $state.go('sysmessage.detail', { 'Id': id });

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteSysmessage = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Sysmessage.delete(id)
            .then(function () {
                //var element = $event.currentTarget;
                //$(element).closest('div[class^="col-lg-12"]').hide();
                //sysmessage
                $state.go('sysmessage', null, { reload: true });
            })
        }
    };

    // Add Group
    $scope.addSysmessage = function () {
        
        // call the controller ....
        Sysmessage.newsysmessage()
        .then(function (data) {
            $scope.sysmessage = Sysmessage.sysmessage;
            $scope.sysmessage.add = 1;
           // $scope.commission.commission_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editSysmessage = function () {
        $scope.sysmessage = $scope.currentSysmessage;
        $scope.sysmessage.add = 0;
        console.log($scope.currentSysmessage);
        //$scope.commission.gcommission_max = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/sysmessage/AddEditSysmessage.cshtml',
            controller: 'sysmessageModalCtrl',
            size: size,
            resolve: {
                sysmessage: function () {
                    return $scope.sysmessage;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentSysmessage = response;
            //console.log("response");
            //console.log(response);
            
            if (response.m_id == 0) {

                $state.go('sysmessage', null, { reload: true });


            } else {

                //$state.go('creditcard.detail', { 'Id': response.credit_card_id });
                $state.go('sysmessage.detail', { 'Id': response.m_id });

            }
            //$state.go('sysmessage.detail', { 'Id': response.m_id });
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('sysmessageModalCtrl', ['$scope', '$modalInstance', 'Sysmessage', 'sysmessage', function ($scope, $modalInstance, Sysmessage, sysmessage) {

    $scope.sysmessage = sysmessage;  // get the data
   
    if (sysmessage.m_id == 0)
        $scope.headerTitle = 'Add receipt message';
    else
        $scope.headerTitle = 'Edit receipt message';

    
    $scope.save = function () {
        // call the service
      
        Sysmessage.Save($scope.sysmessage).then(function (response) {
            //console.log(response.data);
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

   




}]);


$(document).ready(function () {


    

});
