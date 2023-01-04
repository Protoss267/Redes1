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
    public partial class Form1 : Form
    {
        ArbolRed arbol;
        List<String> listID = new List<string>();
        public Form1()
        {
            InitializeComponent();
           
        }
        

      

       

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            List<ArbolRed> li = new List<ArbolRed>();
             arbol.PreOrden(li);
            for (int i = 0; i < li.Count(); i++)
            {
                text += li[i].getRaiz().getMarca() + " ";
            }
            textBox5.Text = text;
        }

      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string id;
        string marca;
        int puerto;
        private void button1_Click_1(object sender, EventArgs e)
        {
            


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Hay campos vacios");

                }
            
                else
                {
                id = textBox1.Text;
                marca = textBox2.Text;
                try
                {
                    puerto = Convert.ToInt32(textBox3.Text);
                }
                catch(FormatException exep)
                {
                    MessageBox.Show(exep.Message+"\n"+"La Cantidad de puerto debe ser numerica"+"\n"+"Se toma como valor el 0");
                    textBox3.Clear();
                    
                    textBox3.Focus();
                    
                    //puerto = 0;
                   

                }


                ComponenteDeRed nuevo = new ComponenteDeRed(id, marca, puerto);

                if (arbol == null)
                    {
                   
                    arbol = new ArbolRed(nuevo);
                   
                         MessageBox.Show("Se Agrego Correctamente");
                    groupBox3.Enabled = true;
                    listID.Add(id);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }


                    else
                    {
                    string padre = comboBox2.Text;

                    if (comboBox2.Text == "")
                    {
                        MessageBox.Show("No especifico a donde queria conectar el nuevo dispositivo");
                    }
                    else
                    {
                        if (!listID.Contains(id))
                        {
                            if (arbol.Adicionar(nuevo, padre))
                            {
                                MessageBox.Show("Se Agrego Correctamente");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                comboBox2.Text = "Padres";
                                listID.Add(id);

                            }
                            else
                                MessageBox.Show("No se pudo Insertar ");
                        }
                        else
                            MessageBox.Show("El Id ya existe en el sistema");
                    }
                    }
                }

           
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ArbolRed> list = new List<ArbolRed>();
             arbol.PreOrden(list);
            comboBox1.Items.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
                comboBox1.Items.Add(list[i].getRaiz().getId());
            }
            if(comboBox1 != null)
            {
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string id = textBox5.Text;
            string marca = textBox6.Text;
            string puerto = textBox7.Text;
           

            ArbolRed modificar = arbol.Buscar(comboBox1.SelectedItem.ToString());

            if (id == "")
            {
                MessageBox.Show("El ID no puede estar vacio");
            }
            else if (listID.Contains(id) && !id.Equals(modificar.getRaiz().getId()))
            {
                MessageBox.Show("El Id q intenta insertar ya se encuentra registrado");
            }
            else
            {
                modificar.getRaiz().setId(id);
               
               
            }

            if(marca=="")
            {
                return;
            }
            else
            {
                modificar.getRaiz().setMarca(marca);
               
               
            }

            if (puerto == "")
            {
                return;
            }
            else
            {
                int prt;
                try
                {
                     prt = Convert.ToInt32(puerto);
                }catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message + "\n" + "La Cantidad de puerto debe ser numerica" + "\n" + "Se toma como valor el 0");
                    prt = 0;
                }
                modificar.getRaiz().setPuertos(prt);
               
                
            }
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            MessageBox.Show("Se modifico correctamente");
            button3_Click(sender, e);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics d = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Black, 5);
            int posIX = 200;
            int posIY = 600;
            Font fnt = new Font("Arial", 18);

            string text = "";
                List<ArbolRed> li = new List<ArbolRed>();
            if (arbol != null)
            {
                arbol.PreOrden(li);

                d.DrawString("PreOrden: ", fnt, Brushes.White, posIX -150, posIY);
                for (int i = 0; i < li.Count(); i++)
                {
                    text += "ID" + li[i].getRaiz().getId() + " ";
                    
                    d.FillRectangle(Brushes.Chartreuse, posIX, posIY, 70, 60);
                   
                    d.DrawRectangle(pen, posIX, posIY, 70, 60);
                    posIX += 85;
                }
                textBox5.Text = text;
            }
            else
                MessageBox.Show("El arbol esta vacio,no podemos llevar a cabo el recorrido");
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ArbolRed> list = new List<ArbolRed>();
            if (arbol != null)
            {
                arbol.PreOrden(list);
                comboBox2.Items.Clear();
                for (int i = 0; i < list.Count(); i++)
                {
                    comboBox2.Items.Add(list[i].getRaiz().getId());
                }
            }
            else
                MessageBox.Show("El arbol esta vacio,no podemos obtener nodos");
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (arbol != null)
            {
                List<ArbolRed> list = new List<ArbolRed>();
                arbol.PreOrden(list);
                comboBox3.Items.Clear();
                for (int i = 0; i < list.Count(); i++)
                {
                    comboBox3.Items.Add(list[i].getRaiz().getId());
                }
            }
            else
                MessageBox.Show("El arbol se encuentra vacio");

        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            if (arbol != null)
            {
                if (comboBox3 == null)
                {
                    comboBox4.Items.Add("El nodo padre no puede estar vacio");
                }

                else
                {
                    var trabajo = arbol.Buscar(comboBox3.Text);
                    List<ArbolRed> li = new List<ArbolRed>();
                    li = trabajo.getHijos();
                    comboBox4.Items.Clear();
                    for (int i = 0; i < li.Count(); i++)
                    {
                        comboBox4.Items.Add(li[i].getRaiz().getId());
                    }
                }
            }
            else
                MessageBox.Show("El arbol se encuentra vacio");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3 != null)
            {

                var eliminar = arbol.Buscar(comboBox3.Text);
                if (eliminar.getRaiz().getId().Equals(arbol.getRaiz().getId()))
                {
                    arbol = null;
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();
                    MessageBox.Show("Se Elimino Correctamente");
                }
                else
                {
                    List<ArbolRed> li = new List<ArbolRed>();
                    li = eliminar.getHijos();
                    var hijoEliminar = arbol.Buscar(comboBox4.Text);


                }
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                MessageBox.Show("Se Elimino Correctamente");
                button3_Click(sender, e);
            }
            else
                MessageBox.Show("No se pudo Eliminar,verifique!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
             Graphics d = this.CreateGraphics();
            d = this.CreateGraphics();
            int widht = (Screen.PrimaryScreen.Bounds.Width / 2) / 2 * 2;
            int height = (Screen.PrimaryScreen.Bounds.Height / 2);
            if (arbol != null)
                arbol.PintarArbol(d, widht, height);


        }

      

       
    }
}
