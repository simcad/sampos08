//var app = angular.module("MyApp")

//function MainCtrl() {

//}
//angular
//  .module('app', [])
//  .controller('MainCtrl', MainCtrl);

app.controller('creditcardCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Creditcard', function ($scope, $state, $stateParams, $modal, $log, Creditcard) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.groups = searchGroups();
    $scope.creditcards = null;

    searchCreditcard();

    $scope.creditcard = null;
    
    $scope.readyToAdd = false;
    

    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
            if (newVal.length > 2)
            {
                searchCreditcard();

            }
            //searchCreditcard();
        }
    }, true);

    
    
    function searchCreditcard() {

        Creditcard.search($scope.searchText)
        .then(function (data) {
            // console.log("stock");
            //console.log(Stock.stocks);
            //console.log(data);
            
            $scope.creditcards = Creditcard.creditcardlist;
            //$scope.creditcards = data.data;


        });
    };


    $scope.refresh = function () {
        //alert($scope.searchText + 'scope');

        Creditcard.search("")
        .then(function (data) {


            $scope.creditcards = Creditcard.creditcardlist;


        });
    }

    // search credit card
    $scope.searchAnyCreditcard = function () {
        //alert($scope.searchText + 'scope');
       
        Creditcard.search($scope.searchText)
        .then(function (data) {
           
           
            $scope.creditcards = Creditcard.creditcardlist;
           
           
        });
    }

    $scope.creditcardDetail = function (id) {

      
        if (id < 0) return;
       
        Creditcard.creditcardDetail(id)
           .then(function (data) {
               
               
               
               $scope.currentCreditcard = Creditcard.currentCreditcard;
               
               
               var _id = $scope.currentCreditcard.credit_card_id;
               $scope.readyToAdd = true;
               $state.go('creditcard.detail', { 'Id': id });

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteCreditcard = function ($event, id) {

        
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Creditcard.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-sm-9"]').hide();
                    $state.go('creditcard', null, { reload: true });
            })
        }
    };

    // Add Group
    $scope.addCreditcard = function () {
        
        // call the controller ....
        Creditcard.newcreditcard()
        .then(function (data) {
            $scope.creditcard = Creditcard.creditcard;
            $scope.creditcard.add = 1;
           // $scope.commission.commission_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editCreditcard = function () {
        // the edit scope data is credit card not currentcreditcard
        $scope.creditcard = $scope.currentCreditcard;
        $scope.creditcard.add = 0;
       
        //$scope.commission.gcommission_max = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/creditcard/AddEditCreditcard.html',
            controller: 'CreditcardModalCtrl',
            size: size,
            resolve: {
                creditcard: function () {
                    return $scope.creditcard;
                }
            }
        });
        modalInstance.result.then(function (response) {
                $scope.currentCreditcard = response;
            //console.log("response");
            //console.log(response);
            //$state.go('creditcard.detail', { 'Id': response.credit_card_id });
            //$state.go('home');


            if (response.add == 1) {
              
                $state.go('creditcard', null, { reload: true });
              

            } else {
                
                $state.go('creditcard.detail', { 'Id': response.credit_card_id });

            }
            
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('CreditcardModalCtrl', ['$scope', '$modalInstance', 'Creditcard', 'creditcard', function ($scope, $modalInstance, Creditcard, creditcard) {

    $scope.creditcard = creditcard;  // get the data
   
    if (creditcard.credit_card_id== "")
        $scope.headerTitle = 'Add credit card';
    else
        $scope.headerTitle = 'Edit credit card';

    
    $scope.save = function () {
        // call the service
      
        Creditcard.Save($scope.creditcard).then(function (response) {
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
