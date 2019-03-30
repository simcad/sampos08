//var app = angular.module("MyApp")
app.controller('companyCtrl', ['$scope', '$state', '$stateParams', '$modal', '$log', 'Company', function ($scope, $state, $stateParams, $modal, $log, Company) {
    
    var Id = $stateParams.Id;


    $scope.searchText = '';
    $scope.companys = searchCompany();


    $scope.company = null;
    $scope.readyToAdd = false;  
    //$scope.companyDetail("05");

    //$scope.$watch('searchText', function (newVal, oldVal) {
    //    if (newVal != oldVal) {

            
    //        // searchStocks();
    //    }
    //}, true);


    function searchCompany() {
        Company.search($scope.searchText)
        .then(function (data) {
            
            $scope.companys = Company.companys;
            $scope.companyDetail("05");

        });
    };

   

  
    
    $scope.searchAnyCompany = function () {


        Company.search($scope.searchText)
        .then(function (data) {
           
            $scope.companys = Company.companys;
           
        });
    }
        
    $scope.companyDetail = function (id) {

        if (!id) return;
       // alert(id);
        Company.companyDetail(id)
           .then(function (data) {
               $scope.currentCompany = Company.currentCompany;
               if ($scope.currentCompany.GST_register_date != null) {

                   $scope.currentCompany.GST_register_date = new Date($scope.currentCompany.GST_register_date).toString("yyyy-MM-dd");
               }

               console.log('c check date=::' +  $scope.currentCompany.GST_register_date );
               
               
               
               $scope.readyToAdd = true;
               $state.go('company.detail', { 'Id': id });

           });
    };

    /* Need to call after defining the function
       It will be called on page refresh        */
    //$scope.currentStock = $scope.stockDetail(Id);

    // Delete a customer and hide the row
    $scope.deletecompany = function ($event, id) {
        var ans = confirm('Are you sure to delete it?');
        if (ans) {
            company.delete(id)
            .then(function (data) {
                console.log(data);
                var element = $event.currentTarget;
                $(element).closest('div[class^="col-lg-12"]').hide();
            })
        }
    };

    // Add supplier
    $scope.addCompany = function () {
        //alert("supplier add");
        Company.newCompany()
        .then(function (data) {
            $scope.company = Company.company;

            $scope.open('lg');
        });
    }

    // Edit Customer
    $scope.editCompany = function () {
        $scope.company = $scope.currentCompany;
       // console.log($scope.currentCompany);

        $scope.open('lg');
    }

    

    // Open model to add edit supplier
    $scope.open = function (size) {
        var modalInstance = $modal.open({
            animation: false,
            backdrop: 'static',
            templateUrl: 'app/company/AddEditCompany.cshtml',
            controller: 'companyModalCtrl',
            size: size,
            resolve: {
                company: function () {
                    return $scope.company;
                }
            }
        });
        modalInstance.result.then(function (response) {
            $scope.currentCompany = response;
            console.log("response");
            console.log(response);
            $state.go('company.detail', { 'Id': response.Company_id });
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };




}]);

app.controller('companyModalCtrl', ['$scope', '$modalInstance', 'Company', 'company', function ($scope, $modalInstance, Company, company) {

    $scope.company = company;  // get the data
   
    if (company.Company_Id == '')
        $scope.headerTitle = 'Add Company';
    else
        $scope.headerTitle = 'Edit company';


    $scope.save = function () {
        // call the service
        //alert("save dd")
        Company.Save($scope.company).then(function (response) {
            //console.log(response.data);
            $modalInstance.close(response.data);
        })
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    //---- Date Picker bits and pieces:

    $scope.opend = function ($event, _Index) {

        if ($event) {
            // console.log($scope.status[_Index].opened + "date");

            $event.preventDefault();
            $event.stopPropagation();
        }
        $scope.status[_Index].opened = true;
        //alert($scope.status[_Index].opened);
        console.log($scope.status[_Index].opened + "date");
    };
    $scope.status = [
        { opened: false },
        { opened: false },
        { opened: false },
        { opened: false }];

    $scope.dateOptions = {
        formatYear: 'yyyy',
        startingDay: 1,
        showWeeks: false,
        initDate: new Date()
    };
    $scope.formats = ['d/M/yyyy', 'dd/M/yyyy', 'd/MM/yyyy', 'dd/MM/yyyy'];
    $scope.altInputFormats = ['d!/M!/yy', 'd!/M!/yyyy'];
    $scope.format = $scope.formats[3];
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
