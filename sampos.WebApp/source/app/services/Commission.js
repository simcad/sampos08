angular.module('MyApp')
       .factory('Commission', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/commission/';
           //var contactBaseUrl = 'api/Contact/';

           var commissionService = {};  //group object
           commissionService.commissions = [];   // array
           commissionService.currentCommission = {};  // current object
           commissionService.commission = {};
       
           // Search groups
           commissionService.search = function (text) {
               var deferred = $q.defer();
              
               return $http({
                   url: baseUrl + 'searchcommission',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {

                   deferred.resolve(commissionService.commissions = data);
                   
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New commission
           commissionService.newCommission = function () {
               var deferred = $q.defer(); 
               
               return $http.get(baseUrl + "newcommission")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(commissionService.commission = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save commission
           commissionService.Save = function (commission, files) {
              // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", commission)
                .success(function (data) {
                    deferred.resolve(commissionService.group = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // commissions detail by commission id call controller 
           
           commissionService.commissionDetail = function (id) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "commissiondetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            commissionService.currentCommission = data[0]._Commission[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete commission
           commissionService.delete = function (id) {
              
               var deferred = $q.defer();
               alert('delete commission');
               return $http.post(baseUrl + "deletecommission/" + id)
                    .success(function (data) {
                        
                        console.log(data);
                        //groupService.search("");
                        //deferred.resolve(groupService.group = data);
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }
                      
           /*       group CONTACTS
            ************************************/
           //commissionService.commissionContacts = function (Id) {
           //    //alert("call group services ");
           //    var deferred = $q.defer();
           //   // alert(contactBaseUrl + "BygroupId/" + Id);
              
           //    return $http.get(contactBaseUrl + "ByCommissionId/" + Id)
           //         .success(function (data) {
           //             deferred.resolve(commissionService.conntacts = data);
           //         }).error(function (error) {
           //             deferred.reject(error);
           //         })
           //    return deferred.promise;
           //}

           return commissionService;
       }]);