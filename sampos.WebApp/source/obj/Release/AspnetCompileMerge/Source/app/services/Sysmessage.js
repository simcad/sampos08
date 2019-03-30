// controller code
angular.module('MyApp')
       .factory('Sysmessage', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/sysmessage/';
           //var contactBaseUrl = 'api/Contact/';

           var sysmessageService = {};  //group object
           sysmessageService.sysmessages = [];   // array
           sysmessageService.currentSysmessage = {};  // current object
           sysmessageService.sysmessage = {};

           // Search groups
           sysmessageService.search = function (text) {
               var deferred = $q.defer();

               if (text == "") { text = '^';}
               return $http.get(baseUrl + "searchsysmessages/" + text)  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(sysmessageService.sysmessages = data)
               

               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New sysmessage
           sysmessageService.newsysmessage = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newsysmessage")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(sysmessageService.sysmessage = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save sysmessage
           sysmessageService.Save = function (sysmessage, files) {
               // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", sysmessage)
                .success(function (data) {
                    deferred.resolve(sysmessageService.sysmessage = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // sysmessages detail by sysmessage id call controller 


           sysmessageService.sysmessageDetail = function (id) {
               var deferred = $q.defer();

               return $http.get(baseUrl + "detail/" + id)
                    .success(function (data) {
                        deferred.resolve(

                            // directly refer to the model data
                            sysmessageService.currentSysmessage = data[0]._Message[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete sysmessage
           sysmessageService.delete = function (id) {

               var deferred = $q.defer();
               
               return $http.post(baseUrl + "deletesysmessage/" + id)
                    .success(function (data) {

                
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           /*       group CONTACTS
            ************************************/
           //sysmessageService.sysmessageContacts = function (Id) {
           //    //alert("call group services ");
           //    var deferred = $q.defer();
           //   // alert(contactBaseUrl + "BygroupId/" + Id);

           //    return $http.get(contactBaseUrl + "BysysmessageId/" + Id)
           //         .success(function (data) {
           //             deferred.resolve(sysmessageService.conntacts = data);
           //         }).error(function (error) {
           //             deferred.reject(error);
           //         })
           //    return deferred.promise;
           //}

           return sysmessageService;
       }]);