using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Core.Mapping
{
    public class MappingIndustrias
    {

        /// <summary>
        /// Recoge los tipos de industrias del dataTable introducido por parámetro para agregarselos a una nueva lista de Industrias.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Devuelve una lista de Industrias con cada uno de los tipos de industrias.</returns>
        public List<Industria.Industria> VolcarIndustrias(DataTable dt)
        {
            List<Industria.Industria> result = new List<Industria.Industria>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Industria.Industria aux = new Industria.Industria();
                aux.Nombre = dt.Rows[i]["Nombre"].ToString();
                aux.TipoIndustria = Convert.ToInt32(dt.Rows[i]["TipoIndustria"]);
                result.Add(aux);
            }

            return result;
        }

    }
}
