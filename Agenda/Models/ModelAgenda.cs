using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Models
{
    [Serializable]
    class ModelAgenda
    {
        public string Nombre { get; set; }
        public string Apelido { get; set; }
        public double Fijo { get; set; }
        public string Email { get; set; }
        public double Celular { get; set; }

    }

}
