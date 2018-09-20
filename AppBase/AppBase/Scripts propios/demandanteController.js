var app = angular.module("app", []);
//var tipoUsuario = Object.freeze({Demandante:1,Empleador:0})



app.controller('DemandanteController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.dem = {};
    $scope.estudios = [];
    $scope.dataDemModel = {};
    $scope.listOfertasDisponibles = {};
    $scope.listOfertasInscritas = {};
    $scope.ofertaDetalleModal = {};
    $scope.inscripcion = {};

    $scope.dataDemModelEditarUsuario = {};
    $scope.dataDemModelEditarDemandante = {};





    //Método que muestra una página modal con los datos del Empleador para editarlos.
    $scope.ModalEditarDemandante = function (dataDemModel) {
        $scope.dataDemModelEditarDemandante = JSON.parse(JSON.stringify(dataDemModel));
        $('#modalEditarDemandante').modal('show');
    };


    //Método que muestra una página modal con los datos del Usuario para editarlos.
    $scope.ModalEditarUsuario = function (dataDemModel) {
        $scope.dataDemModelEditarUsuario = JSON.parse(JSON.stringify(dataDemModel));
        $('#modalEditarUsuario').modal('show');
    };



    //Método que guarda los NUEVOS datos MODIFICADOS del Demandante.
    $scope.ModificarDatosDemandante = function () {
        var url = "/Demandante/ModificarDatosDemandante";
        $http({
            method: 'POST',
            url: url,
            data: $scope.dataDemModelEditarDemandante,
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


    //Método que guarda los NUEVOS datos MODIFICADOS del Empelador.
    $scope.ModificarDatosUsuario = function () {
        var url = "/Demandante/ModificarDatosUsuario";
        $http({
            method: 'POST',
            url: url,
            data: $scope.dataDemModelEditarUsuario,
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





    //Método que muestra la información detallada de la ofertas disponibles.
    $scope.ModalVerOfertaDisponible = function (oferta) {
        $scope.ofertaDetalleModal = oferta;
        $('#modalVerOfertaDisponible').modal('show');
    };


    //Método que muestra la información de la oferta en la que el demandante está inscrito.
    $scope.ModalVerOfertaInscrita = function (oferta) {
        $scope.ofertaDetalleModal = oferta;
        $('#modalVerOfertaInscrita').modal('show');
    };




    //Método que obtiene los datos del Demandante para cargar la vista
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
    };



    //Método que desisnscribe al demandante de una oferta de empleo en la que estaba suscrito.
    $scope.DesinscribirDemandante = function () {
        var url = "/Demandante/DesinscribirDemandante";
        $scope.inscripcion.idDemandante = $scope.dataDemModel.Id;
        $scope.inscripcion.idOfertaEmpleo = $scope.ofertaDetalleModal.Id;
        $http({
            method: 'POST',
            url: url,
            data: $scope.inscripcion,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ha ocurrido un error al desinscribirse de la oferta.")
            } else {
                alert("Se ha desinscrito correctamente de la oferta.")
                window.location.href = "/Demandante/InicialDemandante";
            }
        }).error(function () {
        });
    };


    //Método que inscribe al demandante en una oferta de empleo.
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

   


    //Método que carga las ofertas en las que el usuario se ha inscrito.
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


    //Método que carga las ofertas que tiene disponibles el demandante. (todas - inscritas)
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



    //Método que devuelve los niveles de estudios que hay en la BD.
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





    //Método que guarda los datos del Demandante cuando accede por primera vez.
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



// Método usado para recoger las imagenes introducidas por el demandante.
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