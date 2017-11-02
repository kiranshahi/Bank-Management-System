app.controller('registerController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Security/Login/Register'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
