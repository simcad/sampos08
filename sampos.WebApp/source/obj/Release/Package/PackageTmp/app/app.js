
var app = angular.module('MyApp', [
    'ui.router',
    'ui.bootstrap',
    'ngAnimate'
    
    //'angularFileUpload'
]);

app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

    // default route
        $urlRouterProvider.otherwise('/');
    //alert('config');
   
    $stateProvider
        .state('home', {
            url: '/',
            templateUrl: 'app/home/home.cshtml',
            controller: 'homeCtrl'
        })

        .state('sale', {
            url: '/',
            templateUrl: 'app/home/home.html',
            controller: 'homeCtrl'
        })


        .state('setup', {
            url: '/',
            templateUrl: 'app/setup/setup.cshtml',
            controller: 'setupCtrl'
        })     
    


        .state('supplier', {
            url: '/',
            templateUrl: 'app/supplier/supplier.cshtml',
            controller: 'supplierCtrl'
        })

        .state('supplier.detail', {
            url: '^/supplier/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/supplier/supplierdetail.cshtml',
            controller: 'supplierCtrl'

        })


        .state('company', {
            url: '/',
            templateUrl: 'app/company/company.cshtml',
            controller: 'companyCtrl'
        })

        .state('company.detail', {
            url: '^/company/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/company/companydetail.cshtml',
            controller: 'companyCtrl'
        })


         
        .state('group', {
            url: '/',
            templateUrl: 'app/group/group.cshtml',
            controller: 'groupCtrl'
        })

        .state('group.detail', {
            url: '^/group/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/group/groupdetail.cshtml',
            controller: 'groupCtrl'
        })

         .state('commission', {
             url: '/',
             templateUrl: 'app/commission/commission.cshtml',
             controller: 'commissionCtrl'
         })

        .state('commission.detail', {
            url: '^/commission/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/commission/commissiondetail.cshtml',
            controller: 'commissionCtrl'
        })

         .state('user', {
             url: '/',
             templateUrl: 'app/user/user.cshtml',
             controller: 'userCtrl'
         })

        .state('user.detail', {
            url: '^/user/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/user/userdetail.cshtml',
            controller: 'userCtrl'
        })


        

         .state('brand.detail', {
             url: '^/brand/detail/{Id}',//{Id:[0-9]{1,5}}',
             templateUrl: 'app/brand/branddetail.cshtml',
             controller: 'brandCtrl'
         })

                .state('brand', {
            url: '/',
            templateUrl: 'app/brand/brand.cshtml',
            controller: 'brandCtrl'
        })

          .state('sysmessage', {
              url: '/sysmessage',
              templateUrl: 'app/sysmessage/sysmessage.cshtml',
              controller: 'sysmessageCtrl'
          })



        .state('sysmessage.detail', {
            url: '^/sysmessage/detail/{Id}',//:[0-9]{1,5}}',
            templateUrl: 'app/sysmessage/sysmessagedetail.cshtml',
            controller: 'sysmessageCtrl'
        })

       
        .state('creditcard', {
               url: '/creditcard',
               templateUrl: 'app/creditcard/creditcard.cshtml',
               controller: 'creditcardCtrl'
          })


         .state('creditcard.detail', {
              url: '^/creditcard/detail/{Id}',//:[0-9]{1,5}}',
              templateUrl: 'app/creditcard/creditcarddetail.cshtml',
              controller: 'creditcardCtrl'
          })


         .state('sequencenumber', {
             url: '/',
             templateUrl: 'app/sequencenumber/sequencenumber.cshtml',
             controller: 'sequencenumberCtrl'
         })


         .state('sequencenumber.detail', {
             url: '^/sequencenumber/detail/{Id}',//:[0-9]{1,5}}',
             templateUrl: 'app/sequencenumber/sequencenumberdetail.cshtml',
             controller: 'sequencenumberCtrl'
         })


        .state('about', {
            url: '/',
            templateUrl: 'app/about/about.html',
            controller: 'aboutCtrl'
        })
        .state('contact', {
            url: '/',
            templateUrl: 'app/contact/contact.html',
            controller: 'contactCtrl'
        })
        .state('stock', {
            url: '/',
            templateUrl: 'app/stock/stock.cshtml',
            controller: 'stockCtrl'
        })

        .state('stock.detail', {
            url: '^/stock/detail/{Id}/{barcode}',
            templateUrl: 'app/stock/stockdetail.cshtml',  
            controller: 'stockCtrl'
        })
        .state('customer', {
            url: '/',   
            templateUrl: 'app/customer/customer.cshtml',
            controller: 'customerCtrl'
        })



        .state('customer.detail', {
            url: '^/customer/detail/{Id:[0-9]{1,5}}',
            templateUrl: 'app/customer/customerdetail.cshtml',
            controller: 'customerCtrl'
        })
        .state('customer.detail.contact', {
            url: '^/customer/detail/contact/{Id:[0-9]{1,5}}',
            templateUrl: 'app/customer/contact.cshtml',
            controller: 'customerContactCtrl'
        })
       
    


}]);

app.directive('loading', ['$http', function ($http) {
    return {
        restrict: 'A',
        link: function (scope, elm, attrs) {
            scope.isLoading = function () {
                return $http.pendingRequests.length > 0;
            };
            scope.$watch(scope.isLoading, function (v) {
                if (v) {
                    elm.show();
                } else {
                    elm.hide();
                }
            });
        }
    };

}]);

app.directive('fileUpload', function () {
    return {
        scope: true,        //create a new scope
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                //iterate files since 'multiple' may be specified on the element
                for (var i = 0; i < files.length; i++) {
                    //emit event upward
                    scope.$emit("fileSelected", { file: files[i] });
                }
            });
        }
    };
});

