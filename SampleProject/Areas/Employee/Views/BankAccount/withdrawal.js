app.controller('WithdrawalController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Employee/BankAccount/Withdrawal'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
