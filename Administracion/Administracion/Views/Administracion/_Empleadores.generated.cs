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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Administracion/_Empleadores.cshtml")]
    public partial class _Views_Administracion__Empleadores_cshtml : System.Web.Mvc.WebViewPage<List<Core.Empleador.EmpleadorModel>>
    {
        public _Views_Administracion__Empleadores_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<h4>Listado de empleadores:</h4><br />\r\n<div");

WriteLiteral(" data-ng-init=\"listEmpleadores = ");

            
            #line 5 "..\..\Views\Administracion\_Empleadores.cshtml"
                                Write(Json.Encode(Model));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n\r\n\r\n    <form>\r\n        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral(" style=\"border-radius:0\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></i></span>\r\n            <input");

WriteLiteral(" id=\"text\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"text\"");

WriteLiteral(" placeholder=\"Escribe para filtrar...\"");

WriteLiteral(" ng-model=\"filtroEmpleadores\"");

WriteLiteral(" style=\"border-radius:0\"");

WriteLiteral(">\r\n        </div>\r\n    </form>\r\n\r\n    <br />\r\n\r\n\r\n    <table");

WriteLiteral(" class=\"table table-striped table-bordered\"");

WriteLiteral(" style=\"text-align:center\"");

WriteLiteral(">\r\n        <thead");

WriteLiteral(" style=\"background-color:#565656; overflow:hidden\"");

WriteLiteral(">\r\n            <tr");

WriteLiteral(" style=\"color:white\"");

WriteLiteral(">\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'IdUsuario\')\"");

WriteLiteral(">\r\n                    Id Usuario \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'IdUsuario\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'Id\')\"");

WriteLiteral(">\r\n                    Id Empleador \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'Id\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'NombreEmpresa\')\"");

WriteLiteral(">\r\n                    Nombre empresa \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'NombreEmpresa\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'Direccion\')\"");

WriteLiteral(">\r\n                    Dirección \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'Direccion\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'Email\')\"");

WriteLiteral(">\r\n                    Email \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'Email\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'Telefono\')\"");

WriteLiteral(">\r\n                    Teléfono \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'Telefono\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'NumeroEmpleados\')\"");

WriteLiteral(">\r\n                    Nº Empleados \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'NumeroEmpleados\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(" ng-click=\"sort(\'TipoIndustriaNombre\')\"");

WriteLiteral(">\r\n                    Tipo Industria \r\n                    <span");

WriteLiteral(" class=\"glyphicon sort-icon\"");

WriteLiteral(" ng-show=\"sortKey==\'TipoIndustriaNombre\'\"");

WriteLiteral(" ng-class=\"{\'glyphicon-chevron-up\':reverse,\'glyphicon-chevron-down\':!reverse}\"");

WriteLiteral("></span>\r\n                </th>\r\n                <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral("></th>\r\n            </tr>\r\n        </thead>\r\n\r\n\r\n        <tbody>\r\n            <tr" +
"");

WriteLiteral(" ng-repeat=\"x in listEmpleadores | orderBy:sortKey:reverse | filter:filtroEmplead" +
"ores\"");

WriteLiteral(">\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.IdUsuario}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Id}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.NombreEmpresa}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Direccion}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Email}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Telefono}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.NumeroEmpleados}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.TipoIndustriaNombre}}</td>\r\n                <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral("><button");

WriteLiteral(" class=\"btn btn-info\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" ng-click=\"ModalEmpleadores(x.Id)\"");

WriteLiteral(" style=\"border-radius: 0\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-th-list\"");

WriteLiteral("></i></button></td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
