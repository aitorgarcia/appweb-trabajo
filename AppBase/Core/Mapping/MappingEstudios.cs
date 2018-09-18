using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Core.Mapping
{
    public class MappingEstudios
    {

        public List<Estudio.Estudio> VolcarEstudios(DataTable dt)
        {
            List<Estudio.Estudio> result = new List<Estudio.Estudio>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Estudio.Estudio aux = new Estudio.Estudio();
                aux.Nombre = dt.Rows[i]["Nombre"].ToString();
                aux.NivelEstudios = Convert.ToInt32(dt.Rows[i]["NivelEstudios"]);
                result.Add(aux);
            }

            return result;
        }

    }
}
