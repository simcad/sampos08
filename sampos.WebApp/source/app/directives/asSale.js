
var app = angular.module('MyApp');

app.directive("asSale", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/sale/saleListRow.cshtml'
    }
});