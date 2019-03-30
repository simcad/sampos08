angular.module('MyApp')
       .factory('Stock', ['$q', '$http', function ($q, $http) {
           // see Stock as stockService
           var baseUrl = 'api/stock/';
           var contactBaseUrl = 'api/Stockdetail/';

           var stockService = {};
           stockService.stocks = [];
           stockService.currentStock = {};
           stockService.brands = []; //look up liar
           stockService.groups = [];
           stockService.suppliers = [];
           stockService.gsts = [];
           stockService.stock = {};

           

           // Search Stock
           stockService.search = function (text) {
               var deferred = $q.defer();
               
               return $http({
                   url: baseUrl + 'search',
                   method: 'GET',
                   params: { 'searchText': text },
                   cache: true
               }).success(function (data) {
                   //console.log(data);
                   deferred.resolve(
                       stockService.stocks = data
                       );
               }).error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // New Stocks
           stockService.newStock = function () {
               var deferred = $q.defer();
               return $http.get(baseUrl + "new")
                    .success(function (data) {
                        deferred.resolve(stockService.stock = data);
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // Save Stock
           stockService.Save = function (stock, files) {
               var deferred = $q.defer();
               //console.log("services");
              // console.log(stock);
               return $http.post(baseUrl + "Save", stock)
                .success(function (data) {

                    //console.log(data);
                    deferred.resolve(stockService.stock = data);
                })

               .error(function (error) {
                   deferred.reject(error);
               });
               return deferred.promise;
           }

           // Customers detail by customer id
           stockService.stockDetail = function (id,barcode) {
               var deferred = $q.defer();
               
               return $http.get(baseUrl + "detail/" + id + "/" + barcode)
                    .success(function (data) {
                        //console.log(data);
                        //console.log("stock js - service");
                        //console.log(data[0]._Stock[0]);
                        //stockService.currentStock = data[0]._Stock[0]
                        stockService.brands = data[0]._Brand;
                        stockService.groups = data[0]._Group;
                        stockService.suppliers = data[0]._Supplier;
                        
                        stockService.gsts = data[0]._GST;
                        
                        //console.log(stockService.gsts);
                        deferred.resolve(
                              stockService.currentStock = data[0]._Stock[0]
                              
                              );
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           // delete Customers
           stockService.delete = function (id) {
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

           // get barcode
           stockService.getbarcode = function () {
               
               var deferred = $q.defer();
               return $http.get(baseUrl + "getbarcode")
                    .success(function (data) {
                      
                        deferred.resolve();
                    })
               .error(function (error) {
                   deferred.reject(error);
               })
               return deferred.promise;
           }

           /*       CUSTOMER Stock details
            ************************************/
           stockService.stockDetails = function (Id) {
               //alert("call customer services ");
               var deferred = $q.defer();
               //alert(contactBaseUrl + "ByCustomerId/" + Id);

               return $http.get(contactBaseUrl + "ByStockId/" + Id)
                    .success(function (data) {
                        deferred.resolve(stockService.conntacts = data);
                    }).error(function (error) {
                        deferred.reject(error);
                    })
               return deferred.promise;
           }

           return stockService;
       }]);

