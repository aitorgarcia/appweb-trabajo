using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Login;
using Core.Usuario;
using Core.Demandante;
using Core.Estudio;
using AccesoDatosDemandante;

namespace Negocio
{
    public class NGDemandante
    {

        public DemandanteModel GetDemandanteModelByUserId(int id)
        {
            UTDemandante utDemandante = new UTDemandante();
            return utDemandante.GetDemandanteModelByUserId(id);
        }



        public Demandante GetDemandanteByUserId(int id)
        {
            UTDemandante utDemandante = new UTDemandante();
            return utDemandante.GetDemandanteByUserId(id);
        }



        public bool ValidarDatosDemandante(Demandante emp)
        {
            //if (!String.IsNullOrEmpty(emp.NombreEmpresa) && !String.IsNullOrEmpty(emp.Direccion) &&
            //    emp.NumeroEmpleados != null && emp.IdUsuario != null && emp.TipoIndustria != null)
            //{
                UTDemandante utDemandante = new UTDemandante();

                return utDemandante.GuardarDatosDemandante(emp);
            //}
            //return false;
        }




        public List<Estudio> ObtenerEstudios()
        {
            AccesoDatos.UTDemandante utDemandante = new AccesoDatos.UTDemandante();
            List<Estudio> result;

            return result = utDemandante.ObtenerEstudios();
        }

    }
}
