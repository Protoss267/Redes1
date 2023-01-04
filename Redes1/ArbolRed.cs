using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redes1
{
    class ArbolRed
    {


        protected ComponenteDeRed raiz;
        protected List<ArbolRed> subArbol;

        public ArbolRed(ComponenteDeRed raiz)
        {
            this.raiz = raiz;
            subArbol = new List<ArbolRed>();
        }

        public ComponenteDeRed getRaiz() => raiz;
        public List<ArbolRed> getHijos() => subArbol;

        public bool Adicionar(ComponenteDeRed add, string id)
        {
            var obj = Buscar(id);
            if (obj != null)
            {
                if (obj.PuedoInsertar())
                {
                    obj.subArbol.Add(new ArbolRed(add));
                    return true;
                }
            }
            return false;

        }

        public ArbolRed Buscar(string id)
        {
            if (raiz.getId().Equals(id))
                return this;
            else
            {
                for (int i = 0; i < subArbol.Count(); i++)
                {
                    var trabajo = subArbol[i];
                    var resultado = trabajo.Buscar(id);
                    if (resultado != null)
                        return resultado;

                }
            }
            return null;
        }

        public bool PuedoInsertar()
        {
            if ((raiz.getPuerto() - subArbol.Count()) - 1 > 0)
                return true;
            return false;

        }

        public bool esPc()
        {
            if (subArbol.Count() == 0)
                return true;
            else
                return false;
        }

        //public bool Eliminar(String IDpadre)
        //{
        //    if (raiz.getId().Equals(IDpadre))
        //        return true;
        //    else
        //    {
        //        for(int i=0;i<subArbol.Count();i++)
        //        {
        //            if (subArbol[i].getRaiz().getId().Equals(IDpadre))
        //                return true;
        //            else
        //                subArbol[i].Eliminar(IDpadre);
        //        }
        //    }
        //    return false;
        //}

        

        public void PreOrden(List<ArbolRed> li)
        {
           
                li.Add(this);
                for (int i = 0; i < subArbol.Count(); i++)
                {
                    var trabajo = subArbol[i];
                   // li.Add(trabajo);
                    trabajo.PreOrden(li);
                }
            
            

        }
    


        //---------------------------Aki vamos a pintar el arbol--------------------------

        //int posIX = 750;
        //int PosIY = 40;

        public  void PintarArbol(Graphics e,int x,int y)
            {
           
           
            Brush colorF = Brushes.Aqua;
            int ancho = 70;
            int largo = 50;
            Font fnt = new Font("Arial", 7);
            int desplX = 150;
            int desplY = 80;
            e.FillRectangle(colorF, x, y, ancho, largo);

            e.DrawString($"ID:{raiz.getId()}" + "\n" + $"Marca:{raiz.getMarca()}" + "\n" + $"Puertos:{raiz.getPuerto()}",
           fnt, Brushes.Black, x + 10, y + 10);

            var medio = subArbol.Count() / 2;
            for (int i = 0; i < subArbol.Count(); i++)
            {
                if (i == 0)
                {
                    e.FillRectangle(colorF, x, y += desplY, ancho, largo);
                    e.DrawRectangle(Pens.Black, x, y += desplY, ancho + 5, largo + 5);
                }
                else
                {
                    e.FillRectangle(colorF, x += desplX, y, ancho, largo);

                }
                subArbol[i].PintarArbol(e,x,y);
                //    e.FillRectangle(colorF, posIX, PosIY + desplY, ancho, largo);
                //    e.DrawString($"ID:{subArbol[medio].getRaiz().getId()}" + "\n" + $"Marca:{subArbol[medio].getRaiz().getMarca()}" + "\n" + $"Puertos:{subArbol[medio].getRaiz().getPuerto()}",
                //   fnt, Brushes.Black, posIX + 10, PosIY + desplY + 10);

                //    if(i==medio)
                //    subArbol[medio].PintarArbol(e);



                //    for (int j = medio - 1; j >= 0; j--)
                //    {
                //        e.FillRectangle(colorF, posIX - desplX, PosIY + desplY, ancho, largo);
                //        e.DrawString($"ID:{subArbol[j].getRaiz().getId()}" + "\n" + $"Marca:{subArbol[j].getRaiz().getMarca()}" + "\n" + $"Puertos:{subArbol[j].getRaiz().getPuerto()}", fnt, Brushes.Black, posIX - desplX + 10, PosIY + desplY + 10);
                //        subArbol[j].PintarArbol(e);
                //    }
                //    for (int x = medio + 1; x < subArbol.Count(); x++)
                //    {
                //        e.FillRectangle(colorF, posIX + desplX, PosIY + desplY, ancho, largo);
                //        e.DrawString($"ID:{subArbol[x].getRaiz().getId()}" + "\n" + $"Marca:{subArbol[x].getRaiz().getMarca()}" + "\n" + $"Puertos:{subArbol[x].getRaiz().getPuerto()}", fnt, Brushes.Black, posIX + desplX + 10, PosIY + desplY + 10);
                //        subArbol[x].PintarArbol(e);
                //    }

                // subArbol[i].PintarArbol(e);



            }
           

        }
        
       

        

    }

        
    
}

