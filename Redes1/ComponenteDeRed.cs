using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redes1
{
    class ComponenteDeRed
    {
        protected string id;
        protected string marca;
        protected int puerto;

        public ComponenteDeRed(string id, string marca, int puerto)
        {
            this.id = id;
            this.marca = marca;
            this.puerto = puerto;
        }

        public string getId() => id;
        public string getMarca() => marca;
        public int getPuerto() => puerto;

        public void setId(string id)
        {
            this.id = id;
        }
        public void setMarca(string marca)
        {
            if (marca == "")
                return;
            else
            this.marca = marca;
        }
        public void setPuertos(int puerto)
        {
            if (puerto == 0)
                return;
            this.puerto = puerto;
        }
    }
}
