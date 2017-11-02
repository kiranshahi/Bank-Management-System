app.controller('userController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Admin/User/ListUserView'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
