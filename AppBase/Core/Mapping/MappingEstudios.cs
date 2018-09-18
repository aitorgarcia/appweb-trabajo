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

        /// <summary>
        /// Método que recoge los Estudios del DataTable introducido por parámetro y los añade a una lista de Estudios.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Devuelve una lista de objetos Estudio.</returns>
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
