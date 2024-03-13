using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Aplication.Exceptions
{
    public class CategoriaServiceException : Exception
    {
        public CategoriaServiceException(string message) : base(message) 
        {
            //Grabar el log y enviar mensaje por correo de error
        }
    }
}
