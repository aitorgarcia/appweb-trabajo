var app = angular.module("app", []);

app.controller('AdministracionController', ['$scope', '$http', '$element', '$interval','myHttp', function ($scope, $http, $element, $interval, myHttp) {

    //Variables
    $scope.admin = {};
    $scope.usuarioParaEliminar = {};
    $scope.listDemandantes = {};
    $scope.listOfertas = {};
    $scope.listEmpleadores = {};
    $scope.listUsuarios = {};



   /*
    *  FUNCIONES
    */

    //Método para comprobar el inicio de sesión de un administrador.
    $scope.ValidarDatos = function () {
        var url = "/Administracion/IniciarSesion";
        var data =  $scope.admin;

        myHttp.post(url, data)
            .then(function (result) {
                if (result === false)
                    alert("Los datos introducidos no son correctos.");
                else
                    window.location.href = "/Administracion/IndexAdministracion";
            })
            .catch(function () {
                alert("Error de la función JS.");
            })
    }




    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }





    $scope.EliminarUsuario = function (IdUsuario, TipoUsuario) {
        myHttp.post("/Administracion/EliminarUsuario", { IdUsuario: IdUsuario, TipoUsuario: TipoUsuario })
          .then(function (result) {
              if (result === true) {
                  alert("Usuario eliminado correctamente");
                  window.location.href = "/Administracion/IndexAdministracion";
              } else {
                  alert("Error al eliminar el usuario.");
              }

          })
          .catch(function (err) {
              alert("Error de la promesa");
          })
    };




    //Método que muestra una modal con la tabla de Demandantes inscritos en una Oferta.
    $scope.ModalOfertas = function (oferta) {
        $scope.CargarDemandantesInscritos(oferta);
        $('#modalDemandantesInscritos').modal('show');
    };


    //Método que muestra una modal con la tabla de Ofertas que tiene un Empleador
    $scope.ModalEmpleadores = function (idEmpleador) {
        $scope.CargarOfertasDeEmpleador(idEmpleador);
        $('#modalOfertasPorEmpleador').modal('show');
    };


    //Método que muestra una modal con la tabla de Ofertas que tiene un Empleador
    $scope.ModalEliminarUsuario = function (usuarioPurgado) {
        $scope.usuarioParaEliminar = usuarioPurgado;
        $('#modalEliminarUsuario').modal('show');
    };


    //Método para obtener las ofertas de un empleador.
    $scope.CargarOfertasDeEmpleador = function (idEmpleador) {
        myHttp.post("/Administracion/GetOfertasDeEmpleador", { idEmpleador: idEmpleador })
          .then(function (result) {
              addElementCompileAngularToSelector($('#OfertasPorEmpleador'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };




    //Método para obtener los demandantes inscritos a una oferta concreta.
    $scope.CargarDemandantesInscritos = function (idOferta) {
        myHttp.post("/Administracion/GetDemandantesInscritosOferta", { idOferta: idOferta })
          .then(function (result) {
              addElementCompileAngularToSelector($('#DemandantesInscritos'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };





    //Método para obtener los demandantes de la base de datos.
    $scope.GetDemandantes = function () {
        myHttp.post("/Administracion/ObtenerDemandantes")
          .then(function (result) {
              $('#Ofertas').empty();
              $('#Empleadores').empty();
              $('#Usuarios').empty();
              addElementCompileAngularToSelector($('#Demandantes'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };





    //Método para obtener los usuarios de la base de datos.
    $scope.GetUsuarios = function () {
        myHttp.post("/Administracion/ObtenerUsuarios")
          .then(function (result) {
              $('#Demandantes').empty();
              $('#Ofertas').empty();
              $('#Empleadores').empty();
              addElementCompileAngularToSelector($('#Usuarios'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };





    //Método para obtener los empleadores de la base de datos.
    $scope.GetEmpleadores = function () {
        myHttp.post("/Administracion/ObtenerEmpleadores")
          .then(function (result) {
              $('#Ofertas').empty();
              $('#Demandantes').empty();
              $('#Usuarios').empty();
              addElementCompileAngularToSelector($('#Empleadores'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };




    //Método para obtener las ofertas de la base de datos.
    $scope.GetAllOfertas = function () {
        myHttp.post("/Administracion/GetAllOfertas")
          .then(function (result) {
              $('#Demandantes').empty();
              $('#Empleadores').empty();
              $('#Usuarios').empty();
              addElementCompileAngularToSelector($('#Ofertas'), result, true, false);
          })
          .catch(function () {
              alert("Error de la promesa");
          })
    };


}]);




/*
* ############################################################################
* #                                 SERVICIOS                                #
* ############################################################################
*/

app.factory('myHttp', ['$http', '$q', function ($http, $q) {

    var httpFactory = {

        get: function (baseUrl) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'GET',
                url: baseUrl + '/datos.json'
            }).success(function (data, status, headers, config) {
                defered.resolve(data);
            }).error(function (data, status, headers, config) {
                defered.reject(status);
            });

            return promise;
        },




        post: function (baseUrl, dataIn) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: baseUrl,
                data: dataIn,
                contentType: "application/json; charset=utf-8",
            }).success(function (data, status, headers, config) {
                defered.resolve(data)
            }).error(function (data, status, headers, config) {
                defered.reject(status);
            });
            return promise;
        }

    }
    return httpFactory;
}]);