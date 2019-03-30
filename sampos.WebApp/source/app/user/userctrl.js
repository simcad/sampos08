//var app = angular.module("MyApp")
app.controller('userCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'User', function ($scope, $state, $stateParams, $modal, $log, User) {

    var Id = $stateParams.Id;


    $scope.searchText = '';
    //$scope.groups = searchGroups();
    // $scope.stocks = searchAnyStock();
    //$scope.contacts = [];
    $scope.user = null;
    $scope.readyToAdd = false;
    //$scope.currentStock = null;
    // $scope.brand = LoadBrand();


    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
        }
    }, true);


    
    function searchUsers() {

        alert($scope.searchText);
        User.search($scope.searchText)
        .then(function (data) {
            // console.log("stock");
            //console.log(Stock.stocks);
            console.log(data);
            $scope.users = User.users;

        });
    };

    // search Customer
    $scope.searchAnyUser = function () {
        // alert($scope.searchText + 'scope');
      User.search($scope.searchText)
        .then(function (data) {
            
            $scope.users = User.users;
            console.log('after user');
            console.log($scope.users);
        });
    }

    $scope.userDetail = function (id) {
        if (id=="") return;
        
        User.userDetail(id)
           .then(function (data) {
               
               
               $scope.currentUser = User.currentUser;
               
               //console.log('$scope.currentGroup');
               //console.log($scope.currentGroup);
               //console.log(' end $scope.currentGroup');
               //var _id = $scope.currentGroup.group_id;
               $scope.readyToAdd = true;
               $state.go('user.detail', { 'Id': id});

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteUser = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            User.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add Group
    $scope.addUser = function () {
        //alert("group add");
        User.newUser()
        .then(function (data) {
            $scope.user = User.user;
            //$scope.group.group_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editUser = function () {
        $scope.user = $scope.currentUser;
        console.log($scope.currentUser);
        //$scope.user.user_id = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/user/AddEditUser.cshtml',
            controller: 'userModalCtrl',
            size: size,
            resolve: {
                user: function () {
                    return $scope.user;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentUser = response;
          
            console.log(response);
            $state.go('user.detail', { 'Id': response.user_id});
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('userModalCtrl', ['$scope', '$modalInstance', 'User', 'user', function ($scope, $modalInstance, User, user) {

    $scope.user = user;  // get the data
   
    //if (group.group_max == 1)
      //  $scope.headerTitle = 'Add Group';
    //else
        $scope.headerTitle = 'Edit/Add User';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        User.Save($scope.user).then(function (response) {
            //console.log(response.data);
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    //---- Date Picker bits and pieces:

    //$scope.opend = function ($event, _Index) {

    //    if ($event) {
    //        // console.log($scope.status[_Index].opened + "date");

    //        $event.preventDefault();
    //        $event.stopPropagation();
    //    }
    //    $scope.status[_Index].opened = true;
    //    //alert($scope.status[_Index].opened);
    //    console.log($scope.status[_Index].opened + "date");
    //};
    //$scope.status = [
    //    { opened: false },
    //    { opened: false },
    //    { opened: false },
    //    { opened: false }];

    //$scope.dateOptions = {
    //    formatYear: 'yyyy',
    //    startingDay: 1,
    //    showWeeks: false,
    //    initDate: new Date()
    //};
    //$scope.formats = ['d/M/yyyy', 'dd/M/yyyy', 'd/MM/yyyy', 'dd/MM/yyyy'];
    //$scope.altInputFormats = ['d!/M!/yy', 'd!/M!/yyyy'];
    //$scope.format = $scope.formats[3];
    ////---- End Date picker stuff

    //---- End Date picker stuff





}]);


$(document).ready(function () {


    //$("#last_date").datepicker({ changeMonth: true, changeYear: true });
    //$("#last_date").datepicker($.datepicker.regional["AU"]);
    //$("#last_date").datepicker("option", "altField", 'last_date');
    //$("#last_date").datepicker("option", "showOn", 'both');
    //$("#last_date").datepicker("option", "currentText", "Now");
    //$("#last_date").datepicker({ showWeek: true, firstDay: 1 });


});
