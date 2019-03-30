var app = angular.module('MyApp');

app.directive("asSysmessage", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/sysmessage/sysmessageListRow.cshtml'
    }
});
