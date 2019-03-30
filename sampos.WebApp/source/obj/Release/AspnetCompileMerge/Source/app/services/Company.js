//var app = angular.module("MyApp")
angular.module('MyApp')
       .factory('Company', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/company/';
           var contactBaseUrl = 'api/Contact/';
          
           var companyService = {};  //company object
           companyService.companys = [];   // array of company
           companyService.currentCompany = {};  // current company object
           companyService.company = {};  // 

           // Search company
           companyService.search = function (text) {
               var deferred = $q.defer();

               return $http({
                   url: baseUrl + 'searchcompany',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       companyService.companys = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New suppliers
           companyService.newCompany = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newcompany")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(companyService.company = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save supplier
           companyService.Save = function (company, files) {
            
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", company)
                .success(function (data) {
                    deferred.resolve(companyService.company = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // suppliers detail by supplier id call controller 

           companyService.companyDetail = function (id) {
               var deferred = $q.defer();
               
               //console.log(baseUrl + "companydetail/" + id);
               
               return $http.get(baseUrl + "companydetail/" + id)
                    .success(function (data) {
                        console.log(data);
                        deferred.resolve(
                            
                            companyService.currentCompany = data[0]._Company[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete suppliers
           companyService.delete = function (id) {

               var deferred = $q.defer();
               return $http.post(baseUrl + "deletecompany/" + id)
                    .success(function (data) {

                        //console.log(data);
                        //supplierService.search("");
                        //deferred.resolve(supplierService.supplier = data);
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           /*       supplier CONTACTS
            ************************************/
           companyService.companyContacts = function (Id) {
               //alert("call supplier services ");
               var deferred = $q.defer();
               // alert(contactBaseUrl + "BysupplierId/" + Id);

               return $http.get(contactBaseUrl + "BycompanyId/" + Id)
                    .success(function (data) {
                        deferred.resolve(companyService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return companyService;
       }


       ]);
