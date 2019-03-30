
var app = angular.module('MyApp');

app.directive("asStock", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/stock/userListRow.html'
        
    }
});