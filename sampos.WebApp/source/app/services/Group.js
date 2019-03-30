angular.module('MyApp')
       .factory('Group', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/group/';
           var contactBaseUrl = 'api/Contact/';

           var groupService = {};  //group object
           groupService.groups = [];   // array
           groupService.currentGroup = {};  // current object
           groupService.group = {};
       
           // Search groups
           groupService.search = function (text) {
               var deferred = $q.defer();
              
               return $http({
                   url: baseUrl + 'searchgroup',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       groupService.groups = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New groups
           groupService.newGroup = function () {
               var deferred = $q.defer(); 
               
               return $http.get(baseUrl + "newgroup")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(groupService.group = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save group
           groupService.Save = function (group, files) {
              // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", group)
                .success(function (data) {
                    deferred.resolve(groupService.group = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // groups detail by group id call controller 
           
           groupService.groupDetail = function (id) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "groupdetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            groupService.currentGroup = data[0]._Group[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete groups
           groupService.delete = function (id) {
              
               var deferred = $q.defer();
               return $http.post(baseUrl + "deletegroup/" + id)
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
           groupService.groupContacts = function (Id) {
               //alert("call group services ");
               var deferred = $q.defer();
              // alert(contactBaseUrl + "BygroupId/" + Id);
              
               return $http.get(contactBaseUrl + "BygroupId/" + Id)
                    .success(function (data) {
                        deferred.resolve(groupService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return groupService;
       }]);