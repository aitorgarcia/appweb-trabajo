var app = angular.module("app", ['ui.bootstrap']);

app.controller('EmpleadorController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.emp = {};
    $scope.industrias = [];
    $scope.dataEmpModel = {};
    $scope.oferta = {};
    $scope.listOfertas = [];
    $scope.ofertaDetalle = {};
    $scope.listInscritos = {};
    $scope.inscripcionEstado = {};



    //Método que muestra una página modal con la información detallada de las ofertas del empleador
    //  y a su vez llama a CargarDemandantesInscristos()
    $scope.ModalVerOferta = function (oferta) {
        $scope.ofertaDetalle = oferta;
        $scope.CargarDemandantesInscritos(oferta);
        $('#modalVerOferta').modal('show');
    };



    //Método que cambia el estado de una inscripción (de Pendiente a Aceptado o Rechazado).
    $scope.CambiarEstado = function (inscrito, estado) {
        var url = "/Empleador/CambiarEstado";
        $scope.inscripcionEstado.idDemandante = inscrito.IdDemandante;
        $scope.inscripcionEstado.idOfertaEmpleo = inscrito.IdOfertaEmpleo;
        $scope.inscripcionEstado.Estado = estado;
        $scope.inscripcionEstado.Notas = inscrito.Notas;
        $scope.inscripcionEstado.CV = inscrito.CV;
        $http({
            method: 'POST',
            url: url,
            data: $scope.inscripcionEstado,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Fallo al aceptar o rechazar la inscripción.")
            } else {
                alert("Los cambios se han realizado correctamente.")
                window.location.href = "/Empleador/IndexEmpleador";
            }
        }).error(function () {
        });
    };



    //Método que muestra el listado de los demandantes inscritos en una oferta.
    $scope.CargarDemandantesInscritos = function (oferta) {
        var url = "/Empleador/GetDemandantesInscritosOferta";
        $scope.ofertaAux = oferta;

        $http({
            method: 'POST',
            url: url,
            data: $scope.ofertaAux,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al cargar los demandantes de la oferta.")
            } else {
                $scope.listInscritos = result;
            }
        }).error(function () {
        });
    };



    //Método que obtiene los datos del Empleador para mostrarlos en la vista.
    $scope.ObtenerDatosEmpleadorModel = function () {
        var url = "/Empleador/ObtenerDatosEmpleadorModel";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos de empleador no se han cargado correctamente")
            } else {
                $scope.dataEmpModel = result;
                $scope.CargarOfertas();
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };





    //Método que carga los tipos de industrias existentes en la BD para la vista de primer acceso.
    $scope.ObtenerIndustrias = function () {
        var url = "/Empleador/ObtenerIndustrias";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Las industrias no se han cargado correctamente.")
            } else {
                $scope.industrias = result;
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };



    //Método que crea una oferta nueva con los datos introducidos por el empleador.
    $scope.CrearOferta = function () {
        var url = "/Empleador/GuardarDatosOfertaEmpleo";
        $scope.oferta.IdEmpleador = $scope.dataEmpModel.Id;
        $http({
            method: 'POST',
            url: url,
            data: $scope.oferta,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Compruebe que ha rellenado correctamente todos los campos obligatorios.")
            } else {
                alert("Datos de la oferta registrados correctamente.")
                window.location.href = "/Empleador/IndexEmpleador";
            }
        }).error(function () {
        });
    };



    //Método que carga las ofertas de un empleador concreto
    $scope.CargarOfertas = function () {
        var url = "/Empleador/ObtenerOfertas";
        $http({
            method: 'POST',
            url: url,
            data: { idEmpleador: $scope.dataEmpModel.Id },
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al cargar las ofertas del empleador.")
            } else {
                $scope.listOfertas = result;
            }
        }).error(function () {
        });
    };



    //Método que guarda los datos del Empleador en la vista del primer acceso.
    $scope.GuardarDatosEmpleador = function () {
        var url = "/Empleador/GuardarDatosEmpleador";
        $http({
            method: 'POST',
            url: url,
            data: $scope.emp,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Compruebe que ha rellenado correctamente todos los campos obligatorios.")
            } else {
                alert("Datos registrados correctamente.")
                window.location.href = "/Empleador/IndexEmpleador";
            }
        }).error(function () {
        });
    };
}]);




// Método usado para recoger las imagenes introducidas por el empleador.
app.directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}]);