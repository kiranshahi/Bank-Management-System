app.controller('OpenNewAccountController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Employee/BankAccount/Index'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
