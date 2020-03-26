using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Proyecto1_OLC1
{
    public partial class Form1 : Form
    {
        Analizador lex = new Analizador();
        List<Image> imagenes = new List<Image>();
        List<Image> imagenesAFD = new List<Image>();
        Boolean mostrarAFN = false;
        Boolean mostrarAFD = false;
        Boolean mostrarTT = false;
        public static RichTextBox[] txtEntrada = new RichTextBox[20];
        int contadorImagen = 0;

        public Form1()
        {
            
            InitializeComponent();
            nuevaPestana();
        }
        int i = 0;

       

        private void button7_Click(object sender, EventArgs e)
        {
            //Nueva pestaña

            try
            {
                nuevaPestana();
            }
            catch (Exception)
            {
                MessageBox.Show("Limite de pestañas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void nuevaPestana()
        {



            tabControl1.TabPages.Add("pestaña" + (i + 1));

            //RichTextBox txtEntrada = new RichTextBox();
            tabControl1.TabPages[i].Controls.Add(txtEntrada[i] = new RichTextBox());
            txtEntrada[i].ForeColor = Color.DarkBlue;
            txtEntrada[i].SetBounds(0, 0, 492, 411);

            i++;
        }

        private void aBRIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader leerArchivo;
            openFileDialog1.Filter = "er files (*.er)|*.er";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //   txtPrueba.Text = openFileDialog1.FileName;

                leerArchivo = new StreamReader(openFileDialog1.FileName);
                //  txtEntrada.Text = leerArchivo.ReadToEnd();
                int x = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
                txtEntrada[x].Text = leerArchivo.ReadToEnd();
                tabControl1.SelectedTab.Text = Path.GetFileName(openFileDialog1.FileName.ToString());
                leerArchivo.Close();

            }
        }

        private void gUARDARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "er files (*.er)|*.er";
            if (guardar.ShowDialog() == DialogResult.OK)
            {


                StreamWriter escribir = new StreamWriter(guardar.FileName);

                foreach (object line in txtEntrada[x].Lines)
                {
                    escribir.WriteLine(line);

                }

                escribir.Close();
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {

            lex.Analizar(txtEntrada[tabControl1.TabPages.IndexOf(tabControl1.SelectedTab)].Text);
            //  imagenes = al.getListaImg();
            //imagenes.Add(al.getListaImg()[al.getListaImg().Count - 1]);
            contadorImagen = lex.getListaImg().Count() - 1;
            mostrarAFN = true;
            mostrarImagen();
            //  imagenAfn.Image = imagenes[imagenes.Count()-1];

            if (lex.getListaTok().Count() > 0 && lex.getListaEr().Count() == 0)
            {
                MessageBox.Show("lista de Tokens generada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lex.getListaTok().Count() == 0 && lex.getListaEr().Count() > 0)
            {
                MessageBox.Show("lista de Errores generada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lex.getListaTok().Count() > 0 && lex.getListaEr().Count() > 0)
            {
                MessageBox.Show("lista de Tokens y de Errores generada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //System.ArgumentNullException

      

        private void button3_Click(object sender, EventArgs e)
        {
            contadorImagen--;
            mostrarImagen();
        }
        public void mostrarImagen()
        {

            if (contadorImagen < 0)
            {
                contadorImagen = 0;
            }
            else if (contadorImagen == lex.getListaImg().Count())
            {
                contadorImagen = lex.getListaImg().Count() - 1;
            }

            if (mostrarAFN)
            {
                imaAFN.Image = lex.getListaImg()[contadorImagen];
            }
            else if (mostrarAFD)
            {
                imaAFN.Image = lex.getListaImgAFD()[contadorImagen];
            }
            else if (mostrarTT)
            {
                imaAFN.Image = lex.getListaImgTT()[contadorImagen];
            }


        }

       

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "xml files (*.xml)|*.xml";
            if (guardar.ShowDialog() == DialogResult.OK)
            {

                String fileName = guardar.FileName;

                try
                {

                    Token[] l = lex.getListaTok().ToArray();

                    if (l.Count() > 0)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlElement root = doc.CreateElement("ListaTokens");
                        doc.AppendChild(root);

                        for (int i = 0; i < l.Count(); i++)
                        {
                            XmlElement token = doc.CreateElement("token" + (i + 1));
                            root.AppendChild(token);

                            XmlElement nombre = doc.CreateElement("nombre");
                            nombre.AppendChild(doc.CreateTextNode(l[i].getToken()));
                            token.AppendChild(nombre);

                            XmlElement valor = doc.CreateElement("valor");
                            valor.AppendChild(doc.CreateTextNode(l[i].getLexema()));
                            token.AppendChild(valor);

                            XmlElement fila = doc.CreateElement("fila");
                            fila.AppendChild(doc.CreateTextNode(l[i].getFila().ToString()));
                            token.AppendChild(fila);


                            XmlElement columna = doc.CreateElement("columna");
                            columna.AppendChild(doc.CreateTextNode(l[i].getColumna().ToString()));
                            token.AppendChild(columna);
                        }


                        doc.Save(fileName);
                    }
                }
                catch (System.ArgumentNullException)
                {
                    MessageBox.Show("Lista de Tokens vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void eRRORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "xml files (*.xml)|*.xml";
            if (guardar.ShowDialog() == DialogResult.OK)
            {

                String fileName = guardar.FileName;

                try
                {

                    Error[] l = lex.getListaEr().ToArray();

                    if (l.Count() > 0)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlElement root = doc.CreateElement("ListaErrores");
                        doc.AppendChild(root);

                        for (int i = 0; i < l.Count(); i++)
                        {
                            XmlElement error = doc.CreateElement("Error" + (i + 1));
                            root.AppendChild(error);



                            XmlElement valor = doc.CreateElement("valor");
                            valor.AppendChild(doc.CreateTextNode(l[i].getLexema()));
                            error.AppendChild(valor);

                            XmlElement fila = doc.CreateElement("fila");
                            fila.AppendChild(doc.CreateTextNode(l[i].getFila().ToString()));
                            error.AppendChild(fila);
                            int a = 2;

                            XmlElement columna = doc.CreateElement("columna");
                            columna.AppendChild(doc.CreateTextNode(l[i].getColumna().ToString()));
                            error.AppendChild(columna);
                        }


                        doc.Save(fileName);
                    }
                }
                catch (System.ArgumentNullException)
                {
                    MessageBox.Show("Lista de Errores vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mostrarAFN = false;
            mostrarAFD = false;
            mostrarTT = true;
            mostrarImagen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mostrarAFN = false;
            mostrarAFD = true;
            mostrarTT = false;
            mostrarImagen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostrarAFN = true;
            mostrarAFD = false;
            mostrarTT = false;
            mostrarImagen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contadorImagen++;
            mostrarImagen();
        }
    }
    }

