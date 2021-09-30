using System;
using System.Data;
using System.Windows.Forms;

namespace EjercicioRepasoParcial2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            desabilitarComponentesCarga();
        }

        private void desabilitarComponentesCarga()
        {
            txtId.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtRubro.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void habilitarComponentesCarga()
        {
            txtId.Enabled = false;
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            txtRubro.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void desabilitarComponentesBusquedaYMuestraDatos()
        {
            txtBuscarCodigo.Enabled = false;
            txtBuscarDescripcion.Enabled = false;
            btnBuscarCodigo.Enabled = false;
            btnBuscarDescripcion.Enabled = false;
            btnBuscarTodos.Enabled = false;
            dgrProductos.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void habilitarComponentesBusquedaYMuestraDatos()
        {
            txtBuscarCodigo.Enabled = true;
            txtBuscarDescripcion.Enabled = true;
            btnBuscarCodigo.Enabled = true;
            btnBuscarDescripcion.Enabled = true;
            btnBuscarTodos.Enabled = true;
            dgrProductos.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void LlenarGrilla(DataTable dt)
        {
            dgrProductos.DataSource = null;
            dgrProductos.DataSource = dt;
        }

        private void ActualizarGrilla()
        {
            dgrProductos.DataSource = null;
            dgrProductos.DataSource = Producto.BuscarTodo();
        }

        private void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtRubro.Text = string.Empty;
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarCodigo.Text.Trim();
            DataTable dt = Producto.BuscarCodigo(texto);
            LlenarGrilla(dt);
        }

        private void btnBuscarDescripcion_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarDescripcion.Text.Trim();
            DataTable dt = Producto.BuscarDescripcion(texto);
            LlenarGrilla(dt);
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarComponentesCarga();
            desabilitarComponentesBusquedaYMuestraDatos();
            txtBuscarCodigo.Text = string.Empty;
            txtBuscarDescripcion.Text = string.Empty;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgrProductos.SelectedRows.Count == 1)
            {
                habilitarComponentesCarga();
                desabilitarComponentesBusquedaYMuestraDatos();
                txtId.Text = dgrProductos.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgrProductos.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dgrProductos.CurrentRow.Cells[2].Value.ToString();
                txtRubro.Text = dgrProductos.CurrentRow.Cells[3].Value.ToString();
                txtBuscarCodigo.Text = string.Empty;
                txtBuscarDescripcion.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún elemento.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgrProductos.SelectedRows.Count == 1)
            {
                int id = int.Parse(dgrProductos.CurrentRow.Cells[0].Value.ToString());
                Producto.Eliminar(id);
                MessageBox.Show("El elemento ha sido eliminado.");
                ActualizarGrilla();
                txtBuscarCodigo.Text = string.Empty;
                txtBuscarDescripcion.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una fila de la tabla.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                int id = int.Parse(txtId.Text);
                string codigo = txtCodigo.Text;
                string descripcion = txtDescripcion.Text;
                string rubro = txtRubro.Text;

                if (codigo != string.Empty)
                {
                    if (descripcion != string.Empty)
                    {
                        if (rubro != string.Empty)
                        {
                            Producto productoAmodificar = new Producto(id, codigo, descripcion, rubro);
                            if (productoAmodificar.Modificar())
                            {
                                MessageBox.Show("El producto fue guardado correctamente.");
                                LimpiarCampos();
                                ActualizarGrilla();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error. El producto no ha sido almacenado en la BD.");
                                LimpiarCampos();
                                ActualizarGrilla();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario que el cambo rubro no esté vacío.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario que el cambo descripción no esté vacío.");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario que el cambo código no esté vacío.");
                }

            }
            else
            {
                string codigo = txtCodigo.Text;
                string descripcion = txtDescripcion.Text;
                string rubro = txtRubro.Text;

                if (codigo != string.Empty)
                {
                    if (descripcion != string.Empty)
                    {
                        if (rubro != string.Empty)
                        {
                            Producto nuevoProducto = new Producto();
                            nuevoProducto.Codigo = codigo;
                            nuevoProducto.Descripcion = descripcion;
                            nuevoProducto.Rubro = rubro;

                            if (nuevoProducto.Nuevo())
                            {
                                MessageBox.Show("El producto fue guardado correctamente.");
                                LimpiarCampos();
                                ActualizarGrilla();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error. El producto no ha sido almacenado en la BD.");
                                LimpiarCampos();
                                ActualizarGrilla();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario que el cambo rubro no esté vacío.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario que el cambo descripción no esté vacío.");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario que el cambo código no esté vacío.");
                }
            }
            desabilitarComponentesCarga();
            habilitarComponentesBusquedaYMuestraDatos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ActualizarGrilla();
            desabilitarComponentesCarga();
            habilitarComponentesBusquedaYMuestraDatos();

        }
    }
}
