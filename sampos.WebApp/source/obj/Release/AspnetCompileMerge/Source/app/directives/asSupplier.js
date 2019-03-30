
var app = angular.module('MyApp');

app.directive("asSupplier", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/supplier/supplierListRow.html'
    }
});