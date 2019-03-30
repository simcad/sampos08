//var app = angular.module("MyApp")
angular.module('MyApp')
       .factory('Brand', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/brand/';
           var contactBaseUrl = 'api/Contact/';

           var brandService = {};  //brand object
           brandService.brands = [];   // array
           brandService.currentBrand = {};  // current object
           brandService.brand = {};

           // Search brands
           brandService.search = function (text) {
               var deferred = $q.defer();

               return $http({
                   url: baseUrl + 'searchbrand',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       brandService.brands = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New brands
           brandService.newBrand = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newbrand")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(brandService.brand = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save brand
           brandService.Save = function (brand, files) {
               // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", brand)
                .success(function (data) {
                    deferred.resolve(brandService.brand = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // brands detail by brand id call controller 

           brandService.brandDetail = function (id) {
               var deferred = $q.defer();
               //console.log("brandjs");
               console.log(baseUrl + "branddetail/" + id);
               //console.log(" end brandjs");
               return $http.get(baseUrl + "branddetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            brandService.currentBrand = data[0]._Brand[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);  
               })
               return deferred.promise;
           }

           // delete brands
           brandService.delete = function (id) {

               var deferred = $q.defer();
               return $http.post(baseUrl + "deletebrand/" + id)
                    .success(function (data) {

                        console.log(data);
                        //brandService.search("");
                        //deferred.resolve(brandService.brand = data);
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           /*       brand CONTACTS
            ************************************/
           brandService.brandContacts = function (Id) {
               //alert("call brand services ");
               var deferred = $q.defer();
               // alert(contactBaseUrl + "BybrandId/" + Id);

               return $http.get(contactBaseUrl + "BybrandId/" + Id)
                    .success(function (data) {
                        deferred.resolve(brandService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return brandService;
       }


       ]);
