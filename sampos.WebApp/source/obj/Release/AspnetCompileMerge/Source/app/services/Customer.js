angular.module('MyApp')
       .factory('Customer', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/customer/';
           var contactBaseUrl = 'api/Contact/';

           var customerService = {};
           customerService.customers = [];
           customerService.currentCustomer = {};
       
           // Search Customers
           customerService.search = function (text) {
               var deferred = $q.defer();
               
               return $http({
                   url: baseUrl + 'search1',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       customerService.customers = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New Customers
           customerService.newCustomer = function () {
               var deferred = $q.defer(); 
               
               return $http.get(baseUrl + "new1")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(customerService.customer = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save Customer
           customerService.Save = function (customer, files) {
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save1", customer)
                .success(function (data) {
                    deferred.resolve(customerService.customer = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // Customers detail by customer id
           customerService.customerDetail = function (id) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "detail1/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            customerService.currentCustomer = data[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete Customers
           customerService.delete = function (id) {
               var deferred = $q.defer();
               return $http.post(baseUrl + "delete/" + id)
                    .success(function (data) {
                        //alert(data);
                        //console.log(data);
                        //customerService.search("");
                        //deferred.resolve(customerService.customer = data);
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }
                      
           /*       CUSTOMER CONTACTS
            ************************************/
           customerService.customerContacts = function (Id) {
               //alert("call customer services ");
               var deferred = $q.defer();
              // alert(contactBaseUrl + "ByCustomerId/" + Id);
              
               return $http.get(contactBaseUrl + "ByCustomerId/" + Id)
                    .success(function (data) {
                        deferred.resolve(customerService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return customerService;
       }]);