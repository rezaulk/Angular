 
var app = angular.module('myApp', []);
debugger;
app.controller('myCtrl', function ($scope, $http) {
    $scope.Email = "";
    $scope.Password = "";
    
    $scope.Address = "";
    $scope.Address2 = "";
    $scope.City = "";


    $scope.showMsg = function () {
        debugger;
        dat = {
            name: $scope.Name,
            username: $scope.Username,
            email: $scope.Email,
            password: $scope.Password,
            type: $scope.singleSelect, 
        } 
       
        $http({
            method: 'POST',
            url: '/Home/Adduser',
            data: dat
        }).then(function mySuccess(response) {
            debugger;
            window.location.pathname = 'Home/Login';
        }, function myError(response) {
                debugger;
            $scope.myWelcome = response.statusText;
        });
    };

    $scope.Signupcall = function () { 
        window.location.pathname = 'Home/Signup';
            
 
    };
    $scope.Signincall = function () {
        window.location.pathname = 'Home/Login';


    };


    $scope.login = function () {
        var k = $scope.Address;
        debugger;
        dat = {
            username: $scope.Username,
            password: $scope.Password,
        }

        $http({
            method: 'POST',
            url: '/Home/Login',
            data: dat
        }).then(function mySuccess(response) {
            debugger;
            if (response.data === "") {
                $scope.message = "Please sign up first";
            }
            else if (response.data === "Admin" || response.data === "Manager")
            {
                window.location.pathname = 'Home/Dashboard';
            }
            
            else {
                $scope.message = "Assistant Manager didn't allow to sign up";
            }
         
        }, function myError(response) {
                
            debugger;
                $scope.message = "Please sign up first";
        });
    };


    $scope.init = function () {
        debugger;
        $http({
            method: 'GET',
            url: '/Home/GetAllUser' 
            
        }).then(function mySuccess(response) {
            $scope.employees = response.data;  
        }, function myError(response) {

                debugger;
        });
    };






});