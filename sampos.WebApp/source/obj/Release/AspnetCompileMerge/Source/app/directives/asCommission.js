var app = angular.module('MyApp');

app.directive("asCommission", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/commission/commissionListRow.cshtml'
    }
});

