var app = angular.module("MyApp")
app.controller('customerCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Customer', function ($scope, $state, $stateParams, $modal, $log, Customer) {

    var Id = $stateParams.Id;
    
    $scope.searchText = '';
    $scope.customers = null;
    $scope.contacts = [];
    $scope.customer = null;
    $scope.currentCustomer = null;
    


    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {

            if (newVal.length > 2 && newVal.length < 6) {

                
                searchCustomers();
             
            }
        }
    }, true);

    function searchCustomers() {
        Customer.search($scope.searchText)
        .then(function (data) {

            $scope.customers = Customer.customers;
            $scope.SubResizeScreen();
        });
    };


    $scope.SubResizeScreen = function () {
   //     var _Header = $("header").height();
     //   var _margins = 120;
      //  var _Win = $(window).height() - _Header - _margins - $("#ButtonPanelContent").height();

        var _ht = $('#custpanelheightlist').height();
        $('#custpanelheight').height(_ht);
        


    };
    // search Customer
    $scope.searchCusts = function () {
        
        Customer.search($scope.searchText)
        .then(function (data) {
           // console.log("customer");
            //console.log(Customer.customers);
            $scope.customers = Customer.customers;
            $scope.SubResizeScreen();
            // ("#custpanelheight").height = 500;
            
        });
    }

    $scope.customerDetail = function (id) {
        
        if (!id) return;
        //alert(id);
        Customer.customerDetail(id)
           .then(function (data) {
            
               $scope.currentCustomer = Customer.currentCustomer;
               //console.log("detail");
               //console.log($scope.currentCustomer);
            var _id = $scope.currentCustomer.customer_id;
            $state.go('customer.detail', { 'Id': _id });

        });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    $scope.currentCustomer = $scope.customerDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteCustomer = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Customer.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lm-12"]').hide();
            })
        }
    };

    // Add Customer
           
    $scope.addCustomer = function () {

        
        Customer.newCustomer()
        .then(function (data) {
            $scope.customer = Customer.customer;
            $scope.open('m');
        });
    }

    // Edit Customer
    $scope.editCustomer = function () {
        $scope.customer = $scope.currentCustomer;
        $scope.open('lg');
    }

    // Open model to add edit customer
    $scope.open = function (size) {        
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/customer/AddEditCustomer.html',
            controller: 'customerModalCtrl',
            size: size,
            resolve: {
                customer: function () {
                    return $scope.customer;
                }
            }
        });
        modalInstance.result.then(function (response) {
            console.log("check response");
            console.log(response);
            $scope.currentCustomer = response;
            //must goto detail using customer_id
            $state.go('customer.detail', { 'Id': response.customer_id });            
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };


    
}]);

app.controller('customerModalCtrl', ['$scope', '$modalInstance', 'Customer', 'customer', function ($scope, $modalInstance, Customer, customer) {

    $scope.customer = customer;
    console.log("edit customer");
    console.log(customer);
    if (customer.Id > 0)
        $scope.headerTitle = 'Edit Customer';
    else
        $scope.headerTitle = 'Add Customer';
        
    $scope.save = function () {
        Customer.Save($scope.customer).then(function (response) {
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

}]);
