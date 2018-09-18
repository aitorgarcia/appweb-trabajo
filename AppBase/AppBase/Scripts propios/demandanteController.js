var app = angular.module("app", ['ui.bootstrap']);

//var tipoUsuario = Object.freeze({Demandante:1,Empleador:0})

app.controller('DemandanteController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.dem = {};
    $scope.estudios = [];
    $scope.dataDemModel = {};
    $scope.listOfertasDisponibles = {};
    $scope.listOfertasInscritas = {};
    $scope.ofertaDetalleModal = {};
    $scope.inscripcion = {};




    $scope.ModalVerOfertaDisponible = function (oferta) {
        $scope.ofertaDetalleModal = oferta;
        //$scope.obtenerInscritos(oferta);
        $('#modalVerOfertaDisponible').modal('show');
    };

    $scope.ModalVerOfertaInscrita = function (oferta) {
        $scope.ofertaDetalleModal = oferta;
        //$scope.obtenerInscritos(oferta);
        $('#modalVerOfertaInscrita').modal('show');
    };





    $scope.ObtenerDatosDemandanteModel = function (idDemandante) {
        var url = "/Demandante/ObtenerDatosDemandanteModel";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos de demandante no se han cargado correctamente")
            } else {
                $scope.dataDemModel = result;
                $scope.CargarOfertasDisponibles();
                $scope.CargarOfertasInscritas();
            }
        }).error(function () {
            alert("Error en la función.")
        });
        //tipoUsuario.Demandante;


        //$scope.dataDemModel.Id = idDemandante;
        //$scope.CargarOfertasDisponibles();
        //$scope.CargarOfertasInscritas();

    };






    $scope.InscribirDemandante = function () {
        var url = "/Demandante/InscribirDemandante";
        $scope.inscripcion.idDemandante = $scope.dataDemModel.Id;
        $scope.inscripcion.idOfertaEmpleo = $scope.ofertaDetalleModal.Id;
        $http({
            method: 'POST',
            url: url,
            data: $scope.inscripcion,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al inscribirse en la oferta.")
            } else {
                alert("Se ha inscrito correctamente en la oferta.")
                window.location.href = "/Demandante/InicialDemandante";
            }
        }).error(function () {
        });
    };

   



    $scope.CargarOfertasInscritas = function () {
        var url = "/Demandante/GetOfertasInscritas";

        $http({
            method: 'POST',
            url: url,
            data: { idDemandante: $scope.dataDemModel.Id },
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al cargar las ofertas en las que está inscrito.")
            } else {
                $scope.listOfertasInscritas = result;
            }
        }).error(function () {
        });
    };


    $scope.CargarOfertasDisponibles = function () {
        var url = "/Demandante/GetOfertasDisponibles";

        $http({
            method: 'POST',
            url: url,
            data: { idDemandante: $scope.dataDemModel.Id },
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al cargar las ofertas en las que está inscrito.")
            } else {
                $scope.listOfertasDisponibles = result;
            }
        }).error(function () {
        });
    };




    $scope.ObtenerEstudios = function () {
        var url = "/Demandante/ObtenerEstudios";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los niveles de estudios no se han cargado correctamente.")
            } else {
                $scope.estudios = result;
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };






    $scope.GuardarDatosDemandante = function () {
        var url = "/Demandante/GuardarDatosDemandante";
        $http({
            method: 'POST',
            url: url,
            data: $scope.dem,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Compruebe que ha rellenado correctamente todos los campos obligatorios.")
            } else {
                alert("Datos registrados correctamente.")
                window.location.href = "/Demandante/InicialDemandante";
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