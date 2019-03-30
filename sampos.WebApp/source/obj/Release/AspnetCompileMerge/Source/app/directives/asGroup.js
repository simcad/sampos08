
var app = angular.module('MyApp');

app.directive("asGroup", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/group/groupListRow.cshtml'
    }
});