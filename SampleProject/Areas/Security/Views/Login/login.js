app.controller('LoginController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Security/Login/Login'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
