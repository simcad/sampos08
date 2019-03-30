angular.module('MyApp')
       .factory('User', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/user/';
           var contactBaseUrl = 'api/Contact/';

           var userService = {};  //group object
           userService.users = [];   // array
           userService.currentUser = {};  // current object
           userService.user = {};
       
           // Search groups
           userService.search = function (text) {
               var deferred = $q.defer();
              
               return $http({
                   url: baseUrl + 'searchuser',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       userService.users = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New groups
           userService.newUser = function () {
               var deferred = $q.defer(); 
               
               return $http.get(baseUrl + "newuser")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(userService.user = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save group
           userService.Save = function (user, files) {
              // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", user)
                .success(function (data) {
                    deferred.resolve(userService.user = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // groups detail by group id call controller 
           
           userService.userDetail = function (id) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "userdetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            userService.currentUser = data[0]._User[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete groups
           userService.delete = function (id) {
              
               var deferred = $q.defer();
               return $http.post(baseUrl + "deleteuser/" + id)
                    .success(function (data) {
                        
                        //console.log(data);
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
           userService.userContacts = function (Id) {
               //alert("call group services ");
               var deferred = $q.defer();
              // alert(contactBaseUrl + "BygroupId/" + Id);
              
               return $http.get(contactBaseUrl + "ByuserId/" + Id)
                    .success(function (data) {
                        deferred.resolve(groupService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return userService;
       }]);