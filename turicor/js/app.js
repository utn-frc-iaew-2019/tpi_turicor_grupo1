var app = angular.module("app", [])

app.controller("ClientesController", function ($scope, $http) {
    $scope.articulos = [];

    $http.get('http://localhost:57801/api/Empleados').then(
        function (response) {
            debugger;
            $scope.clientes = response.data;
        })

})