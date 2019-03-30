var app = angular.module('MyApp');

app.directive("asCreditcard", function () {
    return {
        restrict: 'E',
        replace: 'true',
       
        templateUrl: 'app/creditcard/creditcardListRow.cshtml'
    }
});
