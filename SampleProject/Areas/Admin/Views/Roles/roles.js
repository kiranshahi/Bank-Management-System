app.controller('ManageRolesController', function ($scope, $http) {
    $http({
        method: 'Get',
        url: '/Security/Login/Roles'
    }).then(function (response) {
        $scope.depts = response.data;
    });
});
