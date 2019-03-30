// controller code
angular.module('MyApp')
       .factory('Creditcard', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/Creditcard/';
           //var contactBaseUrl = 'api/Contact/';

           var CreditcardService = {};  //service object
           CreditcardService.creditcardlist = [];   // array
           CreditcardService.currentCreditcard = {};  // current object
           CreditcardService.creditcard = {};

           // Search object
           CreditcardService.search = function (text) {
               var deferred = $q.defer();

               if (text == "") { text = '^';}
               return $http.get(baseUrl + "searchcreditcard/" + text)  // call the controller in C#
                    .success(function (data) {

                        deferred.resolve(CreditcardService.creditcardlist = data);
              

               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // New credit card
           //******************************************
           CreditcardService.newcreditcard = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newcreditcard")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(CreditcardService.creditcard = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // Save credit card
           //******************************************
           CreditcardService.Save = function (creditcard, files) {
               // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", creditcard)
                .success(function (data) {
                    deferred.resolve(CreditcardService.creditcard = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           
           //******************************************
           // details
           //******************************************

           CreditcardService.creditcardDetail = function (id) {
               var deferred = $q.defer();

               return $http.get(baseUrl + "detail/" + id)
                    .success(function (data) {
                        deferred.resolve(

                            // directly refer to the model data
                            CreditcardService.currentCreditcard = data[0]._Creditcardcharges[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // delete sysmessage
           //******************************************
           CreditcardService.delete = function (id) {

               var deferred = $q.defer();
              
              
               return $http.post(baseUrl + "delete/" + id)
                    .success(function (data) {

                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

          
           return CreditcardService;
       }]);