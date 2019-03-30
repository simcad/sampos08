
var app = angular.module('MyApp');

app.directive("asBrand", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/brand/brandListRow.cshtml'
    }
});