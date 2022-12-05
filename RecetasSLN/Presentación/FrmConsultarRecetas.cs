using RecetasSLN.Domino;
using RecetasSLN.Servicios;
using RecetasSLN.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private receta recetasN;
        private IServicio service;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            recetasN = new receta();
            service = new serviceFactoryImpl().crearServicio();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            proximoID();
            cargarCombo();
        }

        private void cargarCombo()
        {
            cboIngrediente.DataSource = service.obtenerNombre();
            cboIngrediente.ValueMember = "ingredienteID"; //Atributos de la clase q cargo en combo
            cboIngrediente.DisplayMember = "ingredienteName"; //Atributo nombre de la clase
        }

        private void proximoID()
        {
            int next = service.proximoID();
            if (next > 0)
            {
                lblNro.Text = "Numero#: " + next.ToString();
            }
            else
            {
                MessageBox.Show("No se pudieron obtener datos del numero", "Error", MessageBoxButtons.OK);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //PARA VALIDAR DE QUE NO SE PUEDA INGRESAR OTRA VEZ UN DATO INGRESADO
            //foreach (DataGridViewRow row in dgvDetalles.Rows)
            //{
            //    //Nombre de la columna del nombre 
            //    if (row.Cells["ColIngrediente"].Value.ToString().Equals(cboIngrediente.Text))
            //    {
            //        MessageBox.Show("No puede agregar un mismo ingrediente", "Error", MessageBoxButtons.OK);
            //        return;
            //    }
            //}
            recetasN.nombre = txtNombre.Text;
            recetasN.nombreChef = txtCheff.Text;
            recetasN.tipoReceta = Convert.ToInt32(cboTipo.SelectedValue);
            ingrediente ingr = (ingrediente)cboIngrediente.SelectedItem;
            int cantidadN = (int)nudCantidad.Value;
            detalleReceta detalleN = new detalleReceta(ingr, cantidadN);
            recetasN.agregarDetalle(detalleN);
            dgvDetalles.Rows.Add(new object[] { ingr.ingredienteID,ingr.ingredienteName, detalleN.cantidad});

            calcularTotal();
        }

        private void calcularTotal()
        {
            lblTotalIngredientes.Text = "Total ingredientes: " + dgvDetalles.Rows.Count.ToString();
        }
        //METODO PARA CALCULAR SUBTOTAL EN CASO DE QUE HAYA UNO
        //public int Subtotal()
        //{
        //    int subtotal = 0;
        //    foreach (DataGridViewRow dr in dgvDetalles.Rows)
        //    {
        //        subtotal = Convert.ToInt32(dr.Cells["precio"].Value) * Convert.ToInt32(dr.Cells["cantidad"].Value);
        //    }
        //    return subtotal;
        //}

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //posicion del boton quitar
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                recetasN.quitarDetalle(dgvDetalles.CurrentRow.Index);

                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                calcularTotal();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            recetasN.nombreChef = txtCheff.Text;
            recetasN.nombre = txtNombre.Text;
            recetasN.tipoReceta = cboIngrediente.SelectedIndex + 1;

            if (service.guardarAlta(recetasN))
            {
                MessageBox.Show("Datos insertados con éxito", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            proximoID();
        }

        private void lblTotalIngredientes_Click(object sender, EventArgs e)
        {

        }
    }
}
