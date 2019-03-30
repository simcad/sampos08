//var app = angular.module("MyApp")

//function MainCtrl() {

//}
//angular
//  .module('app', [])
//  .controller('MainCtrl', MainCtrl);

app.controller('sequencenumberCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Sequencenumber', function ($scope, $state, $stateParams, $modal, $log, Sequencenumber) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.groups = searchGroups();
    $scope.sequencenumbers = null;

    searchSequencenumber();

    $scope.sequencenumber = null;
    
    $scope.readyToAdd = false;
    

    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            
        }
    }, true);


    
    function searchSequencenumber() {

        Sequencenumber.search($scope.searchText)
        .then(function (data) {
            
            
            $scope.sequencenumbers = Sequencenumber.sequencenumberlist;

        });
    };

    // search credit card
    $scope.searchAnySequencenumber = function () {
        //alert($scope.searchText + 'scope');
       
        Sequencenumber.search($scope.searchText)
        .then(function (data) {
           
           
            $scope.sequencenumbers = Sequencenumber.sequencenumberlist;
           
           
        });
    }

    $scope.sequencenumberDetail = function (id) {

      
        if (id < 0) return;
       
        Sequencenumber.sequencenumberDetail(id)
           .then(function (data) {
               
               
               
               $scope.currentSequencenumber = Sequencenumber.currentSequencenumber;
               
               
               var _id = $scope.currentSequencenumber.sequence_number_type;
               $scope.readyToAdd = true;
               $state.go('sequencenumber.detail', { 'Id': id });

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteSequencenumber = function ($event, id) {

        
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Sequencenumber.delete(id)
            .then(function () {
                //var element = $event.currentTarget;
                //$(element).closest('div[class^="col-lg-12"]').hide();
                    $state.go('sequencenumber', null, { reload: true });
            })
        }
    };

    // Add Group
    $scope.addSequencenumber = function () {
        
        // call the controller ....
        Sequencenumber.newsequencenumber()
        .then(function (data) {
            $scope.sequencenumber = Sequencenumber.sequencenumber;
            $scope.sequencenumber.add = 1;
           // $scope.commission.commission_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editSequencenumber = function () {
        // the edit scope data is credit card not currentsequencenumber
        $scope.sequencenumber = $scope.currentSequencenumber;
        $scope.sequencenumber.add = 0;
        console.log($scope.currentSequencenumber);
        //$scope.commission.gcommission_max = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/sequencenumber/AddEditSequencenumber.cshtml',
            controller: 'SequencenumberModalCtrl',
            size: size,
            resolve: {
                sequencenumber: function () {
                    return $scope.sequencenumber;
                }
            }
        });
        modalInstance.result.then(function (response) {
                $scope.currentSequencenumber = response;
            //console.log("response");
            //console.log(response);
            //$state.go('sequencenumber.detail', { 'Id': response.credit_card_id });
            //$state.go('home');


            if (response.add == 1) {
              
                $state.go('sequencenumber', null, { reload: true });
              

            } else {
                
                $state.go('sequencenumber.detail', { 'Id': response.sequence_number_type });

            }
            
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('SequencenumberModalCtrl', ['$scope', '$modalInstance', 'Sequencenumber', 'sequencenumber', function ($scope, $modalInstance, Sequencenumber, sequencenumber) {

    $scope.sequencenumber = sequencenumber;  // get the data
   
    if (sequencenumber.credit_card_id== "")
        $scope.headerTitle = 'Add sequence number';
    else
        $scope.headerTitle = 'Edit sequence number';

    
    $scope.save = function () {
        // call the service
      
        Sequencenumber.Save($scope.sequencenumber).then(function (response) {
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
