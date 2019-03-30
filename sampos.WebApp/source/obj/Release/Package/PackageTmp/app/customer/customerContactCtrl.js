
var app = angular.module("MyApp");
app.controller("customerContactCtrl", ['$scope', '$state', '$stateParams', '$modal', '$log', 'Customer', function ($scope, $state, $stateParams, $modal, $log, Customer) {

    var customer_id = $stateParams.Id;
    
    $scope.customerContacts = function (customer_id) {
        return Customer.customerContacts(customer_id)
        .then(function (data) {
          
          
            $scope.contacts = Customer.conntacts;
        });
    };
    
    
   // $scope.customerContacts(customer_id);
}]);