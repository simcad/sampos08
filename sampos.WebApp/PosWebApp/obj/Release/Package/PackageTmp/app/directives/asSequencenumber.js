var app = angular.module('MyApp');

app.directive("asSequencenumber", function () {
    return {
        restrict: 'E',
        replace: 'true',
        templateUrl: 'app/sequencenumber/sequencenumberListRow.html'
    }
});
