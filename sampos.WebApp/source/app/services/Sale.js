angular.module('MyApp')
       .factory('Sale', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/Sale/';
           var contactBaseUrl = 'api/Contact/';

           var saleService = {};  //group object
           saleService.sales = [];   // array
           saleService.currentSale = {};  // current object
           saleService.sale = {};



           // Search groups
           saleService.search = function (text) {
               var deferred = $q.defer();

               return $http({
                   url: baseUrl + 'searchsale',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: false
               }).success(function (data) {
                   deferred.resolve(
                       saleService.sales = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           saleService.test = function (text) {
               alert(text);
               var d = baseUrl + 'mystest' + "?id =a";
               console.log(d);
               var deferred = $q.defer();
               return $http({
                   url: baseUrl + 'mystest',
                   method: 'GET',
                   params: { 'id': text },
                   cache: false
               }).success(function (data) {                                     
                   deferred.resolve(saleService.sales = data);        
                   
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;

           }
           // Search groups
           //saleService.search = function (text) {

           //    //alert(text);
           //    var deferred = $q.defer();
              
           //    return $http({
           //        url: baseUrl + 'searchsale',
           //        method: 'GET',
           //        params: { 'searchText': text },
           //        cache: true
           //    }).success(function (data) {
           //        deferred.resolve(
           //            saleService.sales = data);
           //    }).error(function (error) {
           //        deferred.reject(error);
           //    })
           //    return deferred.promise;
           //}

           // New groups
           saleService.newSale = function () {
               var deferred = $q.defer(); 
               
               return $http.get(baseUrl + "newsale")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(saleService.sale = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save group
           saleService.Save = function (sale, files) {
              // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", sale)
                .success(function (data) {
                    deferred.resolve(saleService.sale = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // groups detail by group id call controller 
           
           saleService.saleDetail = function (id) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "saleDetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            saleService.currentGroup = data[0]._Group[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete groups
           saleService.delete = function (id) {
              
               var deferred = $q.defer();
               return $http.post(baseUrl + "deletesale/" + id)
                    .success(function (data) {
                        
                        console.log(data);
                        //saleService.search("");
                        //deferred.resolve(saleService.group = data);
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }
                      
           /*       group CONTACTS
            ************************************/
           saleService.groupContacts = function (Id) {
               //alert("call group services ");
               var deferred = $q.defer();
              // alert(contactBaseUrl + "BygroupId/" + Id);
              
               return $http.get(contactBaseUrl + "BygroupId/" + Id)
                    .success(function (data) {
                        deferred.resolve(saleService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return saleService;
       }]);