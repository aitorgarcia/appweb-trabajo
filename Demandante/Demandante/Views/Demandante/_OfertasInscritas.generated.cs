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
    using Demandante;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Demandante/_OfertasInscritas.cshtml")]
    public partial class _Views_Demandante__OfertasInscritas_cshtml : System.Web.Mvc.WebViewPage<List<Core.Empleador.OfertaEmpleoInscrita>>
    {
        public _Views_Demandante__OfertasInscritas_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<h4>Datos de oferta:</h4><br />\r\n<div");

WriteLiteral(" data-ng-init=\"listOfertasInscritas = ");

            
            #line 4 "..\..\Views\Demandante\_OfertasInscritas.cshtml"
                                     Write(Json.Encode(Model));

            
            #line default
            #line hidden
WriteLiteral("; ");

WriteLiteral("\"");

WriteLiteral(">\r\n\r\n        ");

WriteLiteral("\r\n            ");

WriteLiteral("\r\n                <table");

WriteLiteral(" class=\"table table-striped table-bordered\"");

WriteLiteral(" style=\"text-align:center\"");

WriteLiteral(">\r\n                    <thead");

WriteLiteral(" style=\"background-color:#565656; overflow:hidden\"");

WriteLiteral(">\r\n                        <tr");

WriteLiteral(" style=\"color:white\"");

WriteLiteral(">\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Título</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Num. Vacantes</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Sueldo</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Fecha de creación</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Fecha de finalización</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">Estado inscripción</th>\r\n                            <th");

WriteLiteral(" style=\"text-align:center; font-weight:normal; vertical-align:middle\"");

WriteLiteral(">");

WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n             " +
"       <tbody>\r\n                        <tr");

WriteLiteral(" ng-repeat=\"x in listOfertasInscritas\"");

WriteLiteral(">\r\n                            <td");

WriteLiteral(" class=\"sc\"");

WriteLiteral(" style=\"vertical-align:middle; margin-left:10px !important\"");

WriteLiteral(">{{x.Titulo}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.NumeroVacantes}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Sueldo}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.FechaLanzamientoString}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.FechaFinString}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral(">{{x.Nombre}}</td>\r\n                            <td");

WriteLiteral(" style=\"vertical-align:middle\"");

WriteLiteral("><button");

WriteLiteral(" class=\"btn btn-info\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" ng-click=\"ModalVerOfertaInscrita(x)\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-eye-open\"");

WriteLiteral("></i></button></td>\r\n                        </tr>\r\n                    </tbody>\r" +
"\n                </table>\r\n            ");

WriteLiteral(" <!-- cierre table -->\r\n        ");

WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591
