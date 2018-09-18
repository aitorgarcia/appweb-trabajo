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


    $scope.ModalVerOferta = function (oferta) {
        $scope.ofertaDetalle = oferta;
        $scope.CargarDemandantesInscritos(oferta);
        $('#modalVerOferta').modal('show');
    };





    //$scope.cambiarEstado = function (inscritoCambiar, estado) {
    //    $scope.cambiarEstadoOfertaDemandante.IdDemandante = inscritoCambiar.IdDemandante;
    //    $scope.cambiarEstadoOfertaDemandante.IdOfertaEmpleo = inscritoCambiar.IdOfertaEmpleo;
    //    $scope.cambiarEstadoOfertaDemandante.Estado = estado;

    //    myHttp.post("/Empleador/CambiarEstado", $scope.cambiarEstadoOfertaDemandante)
    //      .then(function (data) {
    //          window.location.href = "/Empleador/InicioEmpleador";
    //      })
    //      .catch(function (err) {
    //          alert("Error de la promesa");
    //          window.location.href = "/Empleador/InicioEmpleador";
    //      })
    //};





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
                alert("Se ha realizado correctamente.")
                window.location.href = "/Empleador/InicialDemandante";
            }
        }).error(function () {
        });
    };




    $scope.CargarDemandantesInscritos = function (oferta) {
        var url = "/Empleador/GetDemandantesInscritosOferta";
        $scope.ofertaAux = oferta;

        $http({
            method: 'POST',
            url: url,
            data: $scope.ofertaAux,
            //data: { idOferta: $scope.oferta.Id },
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