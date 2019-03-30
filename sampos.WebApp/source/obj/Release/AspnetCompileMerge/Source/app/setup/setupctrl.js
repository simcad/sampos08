angular.module("MyApp")
       .controller("setupCtrl", ['$scope', function ($scope) {
           $scope.pageTitle = 'Simcad POS - Set up';
           $scope.message = '';
           $scope.currentdate = new Date();
           //console.log($scope.currentdate);
       }]);
