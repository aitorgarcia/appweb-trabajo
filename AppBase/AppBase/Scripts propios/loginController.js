var app = angular.module("app", []);

app.controller('LoginController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.user = {};

    $scope.ValidarDatos = function () {

        var url = "/Login/IniciarSesion";

        $http({
            method: 'POST',
            url: url,
            data: $scope.user,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos introducidos no son correctos.")
            } else if (result.TipoUsuario == 0) {
                window.location.href = "/Empleador/Index";
            } else {
                window.location.href = "/Demandante/Index";
            }
        }).error(function () {
            alert("Error en la función js");
        });
    };

}]);