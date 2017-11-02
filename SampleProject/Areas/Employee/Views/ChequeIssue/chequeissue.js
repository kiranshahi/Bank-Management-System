app.controller('IssueChequesController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Employee/IssueCheques/Index'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
