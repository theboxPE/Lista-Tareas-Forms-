using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objNeg = new ClassNegocio();
        

        void mantenimiento(string accion)
        {
            objent.codigo = txtcod.Text;
            objent.titulo = txttitulo.Text;
            objent.desci = txtdescri.Text;

            objent.accion = accion;
            string men = objNeg.N_Mantenimiento(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            txtcod.Text = "";
            txttitulo.Text = "";
            txtdescri.Text = "";
            dataGridView1.DataSource = objNeg.N_Listado();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objNeg.N_Listado();
        }  
                
        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void guardarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (txtcod.Text == "")
            {
                if (MessageBox.Show("Deseas registrar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    dataGridView1.ForeColor = Color.Red;
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (txtcod.Text != "")
            {
                if (MessageBox.Show("Deseas modificar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (txtcod.Text != "")
            {
                if (MessageBox.Show("Deseas eliminar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcod.Text = dataGridView1[0, fila].Value.ToString();
            txttitulo.Text = dataGridView1[1, fila].Value.ToString();
            txtdescri.Text = dataGridView1[2, fila].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.ForeColor = Color.Green;
                }
            }
        }
    }
}
