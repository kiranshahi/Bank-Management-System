app.controller('DepositController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Employee/BankAccount/Deposit'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
