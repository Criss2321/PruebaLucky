using Data;
using Entity;
using System.Configuration;

namespace Business
{
    public class PersonalService
    {
        private readonly PersonalDAO personalDAO;

        public PersonalService(PersonalDAO personalDAO)
        {
            this.personalDAO = personalDAO;
        }

        public List<Personal> ListadoPersonal()
        {
            return personalDAO.ListadoPersonal();
        }

        public bool RegistrarPersonal(Personal personal)
        {
            return personalDAO.RegistrarPersonal(personal);
        }

        public bool EditarDatosPersonal(Personal personal)
        {
            return personalDAO.EditarDatosPersonal(personal);
        }

        public bool EliminarPersonal(int idPersonal)
        {
            return personalDAO.EliminarPersonal(idPersonal);
        }
    }
}
