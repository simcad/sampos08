
var app = angular.module('MyApp');

app.directive("asUser", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/user/UserListRow.cshtml'
    }
});