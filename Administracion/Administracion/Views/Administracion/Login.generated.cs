﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Administracion;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Administracion/Login.cshtml")]
    public partial class _Views_Administracion_Login_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Administracion_Login_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!-- Scripts-->\r\n<script");

WriteLiteral(" src=\"http://ajax.googleapis.com/ajax/libs/angularjs/1.3.10/angular.min.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"http://angular-ui.github.io/bootstrap/ui-bootstrap-tpls-0.13.0.min.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"https://cdnjs.cloudflare.com/ajax/libs/angular-i18n/1.5.0/angular-locale_es" +
"-es.min.js\"");

WriteLiteral("></script>\r\n\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 326), Tuple.Create("\"", 377)
, Tuple.Create(Tuple.Create("", 332), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts")
, 332), false)
, Tuple.Create(Tuple.Create(" ", 341), Tuple.Create("propios/administracionController.js", 342), true)
);

WriteLiteral("></script>\r\n\r\n<div");

WriteLiteral(" ng-app=\"app\"");

WriteLiteral(">\r\n\r\n    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 422), Tuple.Create("\"", 463)
, Tuple.Create(Tuple.Create("", 428), Tuple.Create<System.Object, System.Int32>(Href("~/Imagenes/pexels-photo-884454.jpeg")
, 428), false)
);

WriteLiteral(" style=\'position:fixed;top:0;left:0;width:100%;height:100%;z-index:-1;opacity:0.4" +
"\'");

WriteLiteral(">\r\n\r\n\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("></div>\r\n            <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral(" style=\"height:780px; padding-top:150px\"");

WriteLiteral(">\r\n                <br><br><br>\r\n                <div");

WriteLiteral(" class=\"well\"");

WriteLiteral(" style=\"border-radius:0; background-color:#39b3d7; padding:0; margin:0;  border:1" +
"px solid #39b3d7\"");

WriteLiteral(">\r\n                    <h5");

WriteLiteral(" style=\"text-align:center; color:white\"");

WriteLiteral(">Panel de administración</h5>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"well\"");

WriteLiteral(" style=\"border-radius:0; background-color:#f9f9f9;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" ng-controller=\"AdministracionController\"");

WriteLiteral(" data-ng-init=\"init()\"");

WriteLiteral(" class=\"demo\"");

WriteLiteral(" style=\"width:auto\"");

WriteLiteral(">\r\n                        <form");

WriteLiteral(" id=\"userForm\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(" name=\"userForm\"");

WriteLiteral(" ng-show=\"!signUp.submitted\"");

WriteLiteral(" ng-submit=\"userForm.$valid\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"glyphicon glyphicon-user\"");

WriteLiteral(" style=\"color:#39b3d7\"");

WriteLiteral("></i><span");

WriteLiteral(" style=\"color:#4aa1bb\"");

WriteLiteral("> Usuario:</span><br />\r\n                                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" ng-model=\"admin.Usuario\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"usuario\"");

WriteLiteral(" id=\"usuario\"");

WriteLiteral(" style=\"border-radius:0; max-width:500px; border-color:#dedede;\"");

WriteLiteral(" required />\r\n                                <span");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(" ng-show=\"userForm.users.$error.required && (userForm.users.$dirty && userForm.us" +
"ers.$touched)\"");

WriteLiteral("></span>\r\n                            </div>\r\n\r\n                            <div");

WriteLiteral(" class=\"form-group clearfix\"");

WriteLiteral(" style=\"margin-bottom:0;\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"glyphicon glyphicon-lock\"");

WriteLiteral(" style=\"color:#39b3d7\"");

WriteLiteral("></i><span");

WriteLiteral(" style=\"color:#4aa1bb\"");

WriteLiteral("> Contraseña:</span><br />\r\n                                <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" ng-model=\"admin.Contrasena\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"contrasena\"");

WriteLiteral(" id=\"contrasena\"");

WriteLiteral(" style=\"border-radius:0; max-width:500px; border-color:#dedede;\"");

WriteLiteral(" required /> <br />\r\n                                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-info pull-right\"");

WriteLiteral(" value=\" Acceder\"");

WriteLiteral(" id=\"btn-submit\"");

WriteLiteral(" ng-click=\"ValidarDatos()\"");

WriteLiteral(" style=\"border-radius:0; border:none;\"");

WriteLiteral(">\r\n                            </div>\r\n                        </form>\r\n         " +
"           </div>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("></div>\r\n        </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
