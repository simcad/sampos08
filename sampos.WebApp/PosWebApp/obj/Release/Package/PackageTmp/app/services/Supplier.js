//var app = angular.module("MyApp")
angular.module('MyApp')
       .factory('Supplier', ['$q', '$http', function ($q, $http) {

           var baseUrl = 'api/supplier/';
           var contactBaseUrl = 'api/Contact/';


           var supplierService = {};  //supplier object
           supplierService.suppliers = [];   // array
           supplierService.currentSupplier = {};  // current object
           supplierService.supplier = {};

           // Search suppliers
           supplierService.search = function (text) {
               var deferred = $q.defer();

               return $http({
                   url: baseUrl + 'searchsupplier',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   deferred.resolve(
                       supplierService.suppliers = data);
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New suppliers
           supplierService.newSupplier = function () {
               var deferred = $q.defer();

               return $http.get(baseUrl + "newsupplier")  // call the controller in C#
                    .success(function (data) {
                        deferred.resolve(supplierService.supplier = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save supplier
           supplierService.Save = function (supplier, files) {
               // alert("save service")
               var deferred = $q.defer();
               return $http.post(baseUrl + "Save", supplier)
                .success(function (data) {
                    deferred.resolve(supplierService.supplier = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // suppliers detail by supplier id call controller 

           supplierService.supplierDetail = function (id) {
               var deferred = $q.defer();
               //console.log("supplierjs");
               console.log(baseUrl + "supplierdetail/" + id);
               //console.log(" end supplierjs");
               return $http.get(baseUrl + "supplierdetail/" + id)
                    .success(function (data) {
                        deferred.resolve(
                            supplierService.currentSupplier = data[0]._Supplier[0]);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete suppliers
           supplierService.delete = function (id) {

               var deferred = $q.defer();
               return $http.post(baseUrl + "deletesupplier/" + id)
                    .success(function (data) {

                        console.log(data);
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
           supplierService.supplierContacts = function (Id) {
               //alert("call supplier services ");
               var deferred = $q.defer();
               // alert(contactBaseUrl + "BysupplierId/" + Id);

               return $http.get(contactBaseUrl + "BysupplierId/" + Id)
                    .success(function (data) {
                        deferred.resolve(supplierService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return supplierService;
       }


       ]);
