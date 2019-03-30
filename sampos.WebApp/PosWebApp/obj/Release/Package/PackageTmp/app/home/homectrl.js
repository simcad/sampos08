

angular.module("MyApp")
       .controller("homeCtrl", ['$scope', function ($scope) {
           $scope.pageTitle = 'Simcad SamPOS web application';
           $scope.message = '';
           $scope.currentdate = new Date();
          // console.log($scope.currentdate);
       }]);
