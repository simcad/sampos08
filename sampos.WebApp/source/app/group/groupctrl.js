//var app = angular.module("MyApp")
app.controller('groupCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Group', function ($scope, $state, $stateParams, $modal, $log, Group) {

    var Id = $stateParams.Id;

    console.log($modal);
    $scope.searchText = '';
    //$scope.groups = searchGroups();
    // $scope.stocks = searchAnyStock();
    //$scope.contacts = [];
    $scope.group = null;
    $scope.readyToAdd = false;
    //$scope.currentStock = null;
    // $scope.brand = LoadBrand();


    $scope.$watch('searchText', function (newVal, oldVal) {
        if (newVal != oldVal) {
            // searchStocks();
        }
    }, true);


    
    function searchGroups() {

        alert($scope.searchText);
        Group.search($scope.searchText)
        .then(function (data) {
            // console.log("stock");
            //console.log(Stock.stocks);
            console.log(data);
            $scope.groups = Group.groups;

        });
    };

    // search Customer
    $scope.searchAnyGroup = function () {
        // alert($scope.searchText + 'scope');
        Group.search($scope.searchText)
        .then(function (data) {
            
            $scope.groups = Group.groups;
            
        });
    }

    $scope.groupDetail = function (id) {
        if (id=="") return;
        
        Group.groupDetail(id)
           .then(function (data) {
               
               
               $scope.currentGroup = Group.currentGroup;
               
              
               $scope.readyToAdd = true;
               $state.go('group.detail', { 'Id': id});

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deleteGroup = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            Group.delete(id)
            .then(function () {
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add Group
    $scope.addGroup = function () {
        //alert("group add");
        Group.newGroup()
        .then(function (data) {
            $scope.group = Group.group;
            $scope.group.group_max = 1;
            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editGroup = function () {
        $scope.group = $scope.currentGroup;
        console.log($scope.currentGroup);
        $scope.group.group_max = 0;
        $scope.open('lg');
    }

    

    // Open model to add edit group
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/group/AddEditGroup.cshtml',
            controller: 'groupModalCtrl',
            size: size,
            resolve: {
                group: function () {
                    return $scope.group;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentGroup = response;
            //console.log("response");
            //console.log(response);
            $state.go('group.detail', { 'Id': response.group_id});
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('groupModalCtrl', ['$scope', '$modalInstance', 'Group', 'group', function ($scope, $modalInstance, Group, group) {

    $scope.group = group;  // get the data
   
    if (group.group_max == 1)
        $scope.headerTitle = 'Add Group';
    else
        $scope.headerTitle = 'Edit Group';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        Group.Save($scope.group).then(function (response) {
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
