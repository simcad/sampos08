
angular.module("MyApp")
       .controller("contactCtrl", ['$scope', function ($scope) {

           var headOffice = {
               'address': '7 Tweed Court',
               'contactNo': '0412 075538',
               'fax': '(613) 98036654',
               'email': 'peng@simcad.com',
           };

           var branch1 = {
               'address': '',
               'contactNo': '',
               'fax': '',
               'email': '',
           };


           var branch2 = {
               'address': '',
               'contactNo': '',
               'fax': '',
               'email': '',
           };

           $scope.pageTitle = 'Contact Us';
           $scope.headOffice = headOffice;
         //  $scope.branch1 = branch1;
          // $scope.branch2 = branch2;

       }]);