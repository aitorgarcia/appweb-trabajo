var app = angular.module("app", []);

app.controller('RegistroController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.user = {};

    $scope.ValidarDatos = function () {

        var url = "/Registro/RegistrarUsuario";

        $http({
            method: 'POST',
            url: url,
            data: $scope.user,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos de registro introducidos no son correctos o ya está registrado el usuario.")
            } else {
                alert("Usuario registrado con éxito, para iniciar sesión introduce sus credenciales.")
                window.location.href = "/Login/Index";
            }
        }).error(function () {

        });
    };

}]);