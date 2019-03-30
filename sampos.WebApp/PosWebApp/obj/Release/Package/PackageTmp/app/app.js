
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
            templateUrl: 'app/home/home.html',
            controller: 'homeCtrl'
        })

        .state('setup', {
            url: '/',
            templateUrl: 'app/setup/setup.html',
            controller: 'setupCtrl'
        })


        .state('supplier', {
            url: '/',
            templateUrl: 'app/supplier/supplier.html',
            controller: 'supplierCtrl'
        })

        .state('supplier.detail', {
            url: '^/supplier/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/supplier/supplierdetail.html',
            controller: 'supplierCtrl'
        })


        .state('company', {
            url: '/',
            templateUrl: 'app/company/company.html',
            controller: 'companyCtrl'
        })

        .state('company.detail', {
            url: '^/company/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/company/companydetail.html',
            controller: 'companyCtrl'
        })



        .state('group', {
            url: '/',
            templateUrl: 'app/group/group.html',
            controller: 'groupCtrl'
        })

        .state('group.detail', {
            url: '^/group/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/group/groupdetail.html',
            controller: 'groupCtrl'
        })

         .state('commission', {
             url: '/',
             templateUrl: 'app/commission/commission.html',
             controller: 'commissionCtrl'
         })

        .state('commission.detail', {
            url: '^/commission/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/commission/commissiondetail.html',
            controller: 'commissionCtrl'
        })

         .state('user', {
             url: '/',
             templateUrl: 'app/user/user.html',
             controller: 'userCtrl'
         })

        .state('user.detail', {
            url: '^/user/detail/{Id}',//{Id:[0-9]{1,5}}',
            templateUrl: 'app/user/userdetail.html',
            controller: 'userCtrl'
        })


        

         .state('brand.detail', {
             url: '^/brand/detail/{Id}',//{Id:[0-9]{1,5}}',
             templateUrl: 'app/brand/branddetail.html',
             controller: 'brandCtrl'
         })

                .state('brand', {
            url: '/',
            templateUrl: 'app/brand/brand.html',
            controller: 'brandCtrl'
        })

          .state('sysmessage', {
              url: '/sysmessage',
              templateUrl: 'app/sysmessage/sysmessage.html',
              controller: 'sysmessageCtrl'
          })



        .state('sysmessage.detail', {
            url: '^/sysmessage/detail/{Id}',//:[0-9]{1,5}}',
            templateUrl: 'app/sysmessage/sysmessagedetail.html',
            controller: 'sysmessageCtrl'
        })

       
        .state('creditcard', {
               url: '/creditcard',
               templateUrl: 'app/creditcard/creditcard.html',
               controller: 'creditcardCtrl'
          })


         .state('creditcard.detail', {
              url: '^/creditcard/detail/{Id}',//:[0-9]{1,5}}',
              templateUrl: 'app/creditcard/creditcarddetail.html',
              controller: 'creditcardCtrl'
          })


         .state('sequencenumber', {
             url: '/sequencenumber',
             templateUrl: 'app/sequencenumber/sequencenumber.html',
             controller: 'sequencenumberCtrl'
         })


         .state('sequencenumber.detail', {
             url: '^/sequencenumber/detail/{Id}',//:[0-9]{1,5}}',
             templateUrl: 'app/sequencenumber/sequencenumberdetail.html',
             controller: 'sequencenumberCtrl'
         })


        .state('about', {
            url: '/about',
            templateUrl: 'app/about/about.html',
            controller: 'aboutCtrl'
        })
        .state('contact', {
            url: '/contact',
            templateUrl: 'app/contact/contact.html',
            controller: 'contactCtrl'
        })
        .state('stock', {
            url: '/stock',
            templateUrl: 'app/stock/stock.html',
            controller: 'stockCtrl'
        })

        .state('stock.detail', {
            url: '^/stock/detail/{Id}/{barcode}',
            templateUrl: 'app/stock/stockdetail.html',  
            controller: 'stockCtrl'
        })
        .state('customer', {
            url: '/customer',   
            templateUrl: 'app/customer/customer.html',
            controller: 'customerCtrl'
        })



        .state('customer.detail', {
            url: '^/customer/detail/{Id:[0-9]{1,5}}',
            templateUrl: 'app/customer/customerdetail.html',
            controller: 'customerCtrl'
        })
        .state('customer.detail.contact', {
            url: '^/customer/detail/contact/{Id:[0-9]{1,5}}',
            templateUrl: 'app/customer/contact.html',
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

