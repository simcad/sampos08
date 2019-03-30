// controller code
angular.module('MyApp')
       .factory('Sequencenumber', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/Sequencenumber/';
           //var contactBaseUrl = 'api/Contact/';
            
           var SequencenumberService = {};  //service object
           SequencenumberService.sequencenumberlist = [];   // array
           SequencenumberService.currentSequencenumber = {};  // current object
           SequencenumberService.sequencenumber = {};
            
           // Search object
           SequencenumberService.search = function (text) {
               var deferred = $q.defer();

               if (text == "") { text = '^';}
               return $http.get(baseUrl + "searchseq/" + text)  // call the controller in C#
                    .success(function (data) {

                        deferred.resolve(SequencenumberService.sequencenumberlist = data);
              

               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // New credit card
           //******************************************
           SequencenumberService.newsequencenumber = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newsequencenumber")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(SequencenumberService.sequencenumber = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // Save credit card
           //******************************************
           SequencenumberService.Save = function (sequencenumber, files) {
               // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", sequencenumber)
                .success(function (data) {
                    deferred.resolve(SequencenumberService.sequencenumber = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           
           //******************************************
           // details
           //******************************************

           SequencenumberService.sequencenumberDetail = function (id) {
               var deferred = $q.defer();

               return $http.get(baseUrl + "detail/" + id)
                    .success(function (data) {
                        deferred.resolve(

                            // directly refer to the model data
                            SequencenumberService.currentSequencenumber = data[0]._Sequencenumber[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           //******************************************
           // delete sysmessage
           //******************************************
           SequencenumberService.delete = function (id) {

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

          
           return SequencenumberService;
       }]);