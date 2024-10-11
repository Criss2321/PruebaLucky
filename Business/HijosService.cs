using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HijosService
    {
        private readonly HijosDAO hijosDAO;

        public HijosService(HijosDAO hijosDAO)
        {
            this.hijosDAO = hijosDAO;
        }

        public List<Hijos> ListadoHijos(int idPersonal)
        {
            return hijosDAO.ListadoHijos(idPersonal);
        }

        public bool RegistrarHijos(Hijos hijos)
        {
            return hijosDAO.RegistrarHijos(hijos);
        }

        public bool EditarHijos(Hijos hijos)
        {
            return hijosDAO.EditarHijos(hijos);
        }

        public bool EliminarHijos(int idHijo)
        {
            return hijosDAO.EliminarHijos(idHijo);
        }
    }
}
