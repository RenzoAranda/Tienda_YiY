using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class frmPrincipal : Form
    {
        ListaInventario listaInventario = new ListaInventario();
        ListaCompradores listaCompradores = new ListaCompradores();
        Comprador comprador = new Comprador();
        int indiceInventario = -1;
        int indiceBoleta = -1;
        public frmPrincipal()
        {
            InitializeComponent();
            MostrarInventario();
            ActualizarCompradoresVenta();
        }
        //Pestaña de inventario
        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {
            if (!Validar(txtNombreInventario.Text, "Nombre"))
            {
                txtNombreInventario.Focus();
            }
            else if (cmbCategoriaInventario.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha completado el campo de 'Categoría'.");
            }
            else if (!Validar(txtPrecioCInventario.Text, "Precio de compra"))
            {
                txtPrecioCInventario.Text = "";
                txtPrecioCInventario.Focus();
            }
            else if (!Validar(txtPrecioVInventario.Text, "Precio de venta"))
            {
                txtPrecioVInventario.Text = "";
                txtPrecioVInventario.Focus();
            }
            else if (!Validar(txtStockInventario.Text, "Stock"))
            {
                txtStockInventario.Text = "";
                txtStockInventario.Focus();
            }
            else
            {
                Producto producto = new Producto();
                producto.nombre = txtNombreInventario.Text;
                producto.numCategoria = cmbCategoriaInventario.SelectedIndex;
                producto.precioC = double.Parse(txtPrecioCInventario.Text);
                producto.precioV = double.Parse(txtPrecioVInventario.Text);
                producto.stock = int.Parse(txtStockInventario.Text);
                listaInventario.AgregarProducto(producto);
                MostrarInventario();
                ActualizarNombreBoleta();
                txtNombreInventario.Text = "";
                txtPrecioCInventario.Text = "";
                txtPrecioVInventario.Text = "";
                txtStockInventario.Text = "";
                txtBuscarInventario.Text = "";
                txtNombreInventario.Focus();
            }
        }
        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            if (listaInventario.CantidadProductos() == 0)
            {
                MessageBox.Show("Inventario vacío");
            }
            else if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Seleccionar un producto");
                txtBuscarInventario.Text = "";
            }
            else
            {
                Producto producto = new Producto();
                producto.nombre = dataGridView1.Rows[indiceInventario].Cells[0].Value.ToString();
                producto.stock = int.Parse(dataGridView1.Rows[indiceInventario].Cells[4].Value.ToString());
                string categoria = dataGridView1.Rows[indiceInventario].Cells[1].Value.ToString();
                if (categoria == "Recreación")
                {
                    producto.numCategoria = 0;
                }
                else if (categoria == "Limpieza")
                {
                    producto.numCategoria = 1;
                }
                else if (categoria == "Librería")
                {
                    producto.numCategoria = 2;
                }
                else if (categoria == "Cocina")
                {
                    producto.numCategoria = 3;
                }
                else
                {
                    producto.numCategoria = 4;
                }
                listaInventario.EliminarProducto(producto);
                MostrarInventario();
                ActualizarNombreBoleta();
                txtBuscarInventario.Text = "";
            }
        }
        private void btnEditarInventario_Click(object sender, EventArgs e)
        {
            if (listaInventario.CantidadProductos() == 0)
            {
                MessageBox.Show("Inventario vacío");
            }
            else if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Seleccionar un producto");
                txtBuscarInventario.Text = "";
            }
            else if (txtModificadorInventario.Visible == true)
            {
                if (!Validar(txtModificadorInventario.Text, "Modificador"))
                {
                    txtModificadorInventario.Text = "";
                    txtModificadorInventario.Focus();
                }
                else
                {
                    Producto producto = new Producto();
                    producto.nombre = dataGridView1.Rows[indiceInventario].Cells[0].Value.ToString();
                    producto.stock = int.Parse(dataGridView1.Rows[indiceInventario].Cells[4].Value.ToString());
                    string categoria = dataGridView1.Rows[indiceInventario].Cells[1].Value.ToString();
                    if (categoria == "Recreación")
                    {
                        producto.numCategoria = 0;
                    }
                    else if (categoria == "Limpieza")
                    {
                        producto.numCategoria = 1;
                    }
                    else if (categoria == "Librería")
                    {
                        producto.numCategoria = 2;
                    }
                    else if (categoria == "Cocina")
                    {
                        producto.numCategoria = 3;
                    }
                    else
                    {
                        producto.numCategoria = 4;
                    }
                    listaInventario.ModificarProducto(producto, cmbVariableInventario.SelectedIndex, txtModificadorInventario.Text);
                    MostrarInventario();
                    ActualizarNombreBoleta();
                    txtModificadorInventario.Text = "";
                    txtBuscarInventario.Text = "";
                    txtModificadorInventario.Focus();
                }
            }
            else if (cmbModificadorInventario.Visible == true)
            {
                if (cmbModificadorInventario.SelectedIndex == -1)
                {
                    MessageBox.Show("No se ha completado el campo de 'Modificador'.");
                }
                else
                {
                    Producto producto = new Producto();
                    producto.nombre = dataGridView1.Rows[indiceInventario].Cells[0].Value.ToString();
                    producto.stock = int.Parse(dataGridView1.Rows[indiceInventario].Cells[4].Value.ToString());
                    string categoria = dataGridView1.Rows[indiceInventario].Cells[1].Value.ToString();
                    if (categoria == "Recreación")
                    {
                        producto.numCategoria = 0;
                    }
                    else if (categoria == "Limpieza")
                    {
                        producto.numCategoria = 1;
                    }
                    else if (categoria == "Librería")
                    {
                        producto.numCategoria = 2;
                    }
                    else if (categoria == "Cocina")
                    {
                        producto.numCategoria = 3;
                    }
                    else
                    {
                        producto.numCategoria = 4;
                    }
                    listaInventario.ModificarProducto(producto, 1, cmbModificadorInventario.SelectedIndex.ToString());
                    MostrarInventario();
                    ActualizarNombreBoleta();
                    txtBuscarInventario.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No se ha completado el campo de 'Variable'.");
            }
        }
        private void cmbVariableInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblModificadorInventario.Visible = true;
            txtModificadorInventario.Text = "";
            if (cmbVariableInventario.SelectedIndex == 1)
            {
                txtModificadorInventario.Visible = false;
                cmbModificadorInventario.Visible = true;
            }
            else
            {
                txtModificadorInventario.Visible = true;
                cmbModificadorInventario.Visible = false;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                indiceInventario = dataGridView1.SelectedRows[0].Index;
            }
            catch (Exception) { }
        }
        private void txtNombreInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreInventario.Text != "")
            {
                txtNombreInventario.CharacterCasing = CharacterCasing.Upper;
            }
        }
        private void txtPrecioCInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioCInventario.Text != "")
            {
                while (!double.TryParse(txtPrecioCInventario.Text, out _) & txtPrecioCInventario.Text != "")
                {
                    string aux = txtPrecioCInventario.Text;
                    txtPrecioCInventario.Text = aux.Remove(aux.Length - 1, 1);
                }
                txtPrecioCInventario.Select(txtPrecioCInventario.Text.Length, 0);
            }
        }
        private void txtPrecioVInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioVInventario.Text != "")
            {
                while (!double.TryParse(txtPrecioVInventario.Text, out _) & txtPrecioVInventario.Text != "")
                {
                    string aux = txtPrecioVInventario.Text;
                    txtPrecioVInventario.Text = aux.Remove(aux.Length - 1, 1);
                }
                txtPrecioVInventario.Select(txtPrecioVInventario.Text.Length, 0);
            }
        }
        private void txtStockInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtStockInventario.Text != "")
            {
                while (!int.TryParse(txtStockInventario.Text, out _) & txtStockInventario.Text != "")
                {
                    string aux = txtStockInventario.Text;
                    txtStockInventario.Text = aux.Remove(aux.Length - 1, 1);
                }
                txtStockInventario.Select(txtStockInventario.Text.Length, 0);
            }
        }
        private void txtModificadorInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtModificadorInventario.Text != "")
            {
                if (cmbVariableInventario.SelectedIndex == 0)
                {
                    txtModificadorInventario.CharacterCasing = CharacterCasing.Upper;
                }
                else if (cmbVariableInventario.SelectedIndex == 2 | cmbVariableInventario.SelectedIndex == 3)
                {
                    while (!double.TryParse(txtModificadorInventario.Text, out _) & txtModificadorInventario.Text != "")
                    {
                        string aux = txtModificadorInventario.Text;
                        txtModificadorInventario.Text = aux.Remove(aux.Length - 1, 1);
                    }
                    txtModificadorInventario.Select(txtModificadorInventario.Text.Length, 0);
                }
                else if (cmbVariableInventario.SelectedIndex == 4)
                {
                    while (!int.TryParse(txtModificadorInventario.Text, out _) & txtModificadorInventario.Text != "")
                    {
                        string aux = txtModificadorInventario.Text;
                        txtModificadorInventario.Text = aux.Remove(aux.Length - 1, 1);
                    }
                    txtModificadorInventario.Select(txtModificadorInventario.Text.Length, 0);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarInventario.Text != "")
            {
                txtBuscarInventario.CharacterCasing = CharacterCasing.Upper;
            }
            BuscarInventario(txtBuscarInventario.Text);
        }
        void MostrarInventario()
        {
            dataGridView1.Rows.Clear();
            List<Producto>[] lista = listaInventario.ObtenerLista();
            for (int i = 0; i < 5; i++)
            {
                for (int e = 0; e < lista[i].Count; e++)
                {
                    Producto producto = lista[i][e];
                    dataGridView1.Rows.Add(producto.nombre, producto.categoria, "S/. " + producto.precioC, "S/. " + producto.precioV, producto.stock);
                }
            }
        }
        void BuscarInventario(string texto)
        {
            dataGridView1.Rows.Clear();
            List<Producto>[] lista = listaInventario.ObtenerLista();
            for (int i = 0; i < 5; i++)
            {
                for (int e = 0; e < lista[i].Count; e++)
                {
                    Producto producto = lista[i][e];
                    if (producto.nombre.Length >= texto.Length)
                    {
                        if (producto.nombre.Substring(0, texto.Length) == texto)
                        {
                            dataGridView1.Rows.Add(producto.nombre, producto.categoria, "S/. " + producto.precioC, "S/. " + producto.precioV, producto.stock);
                        }
                    }
                }
            }
        }
        //Pestaña de boleta
        private void btnAgregarBoleta_Click(object sender, EventArgs e)
        {
            if (cmbCategoriaBoleta.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha completado el campo de 'Categoría'.");
            }
            else if (cmbNombreBoleta.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha completado el campo de 'Nombre del producto'.");
            }
            else if (!Validar(txtCantidadBoleta.Text, "Cantidad"))
            {
                txtCantidadBoleta.Text = "";
                txtCantidadBoleta.Focus();
            }
            else if (ExisteNombreBoleta())
            {
                MessageBox.Show("El producto seleccionado ya está en la boleta.");
            }
            else
            {
                Producto producto = listaInventario.ObtenerProducto(cmbNombreBoleta.SelectedItem.ToString(), cmbCategoriaBoleta.SelectedIndex);
                int cantidad = int.Parse(txtCantidadBoleta.Text);
                comprador.AgregarProducto(producto, cantidad);
                MostrarBoleta();
                txtCantidadBoleta.Text = "";
                txtCantidadBoleta.Focus();
            }
        }
        private void btnEliminarBoleta_Click(object sender, EventArgs e)
        {
            if (comprador.CantidadProductos() == 0)
            {
                MessageBox.Show("No hay productos.");
            }
            else
            {
                Producto producto = new Producto();
                producto.nombre = dataGridView2.Rows[indiceBoleta].Cells[1].Value.ToString();
                comprador.EliminarProducto(producto);
                MostrarBoleta();
            }
        }
        private void btnFinalizarBoleta_Click(object sender, EventArgs e)
        {
            if (!Validar(txtNombreBoleta.Text, "Nombre del comprador"))
            {
                txtNombreBoleta.Focus();
            }
            else if (!Validar(txtApellidoBoleta.Text, "Apellido del comprador"))
            {
                txtApellidoBoleta.Focus();
            }
            else if (!Validar(txtDNIBoleta.Text, "DNI"))
            {
                txtDNIBoleta.Text = "";
                txtDNIBoleta.Focus();
            }
            else if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos.");
            }
            else
            {
                comprador.nombre = txtNombreBoleta.Text;
                comprador.apellido = txtApellidoBoleta.Text;
                comprador.dni = int.Parse(txtDNIBoleta.Text);
                listaCompradores.AgregarComprador(comprador);
                List<Producto> listaProductos = comprador.ObtenerListaProductos();
                List<int> listaCantidades = comprador.ObtenerListaCantidades();
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    listaInventario.ModificarProducto(listaProductos[i], 4, "" + (listaProductos[i].stock - listaCantidades[i]));
                }
                comprador = new Comprador();
                MostrarInventario();
                MostrarBoleta();
                ActualizarNombreBoleta();
                ActualizarCompradoresVenta();
                txtNombreBoleta.Text = "";
                txtApellidoBoleta.Text = "";
                txtDNIBoleta.Text = "";
                txtNombreBoleta.Focus();
            }
        }
        private void cmbCategoriaBoleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombreBoleta();
        }
        private void cmbNombreBoleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrecioBoleta.Visible = true;
            lblStockBoleta.Visible = true;
            Producto producto = listaInventario.ObtenerProducto(cmbNombreBoleta.SelectedItem.ToString(), cmbCategoriaBoleta.SelectedIndex);
            lblNumPrecioBoleta.Text = "S/. " + producto.precioV;
            lblNumStockBoleta.Text = producto.stock + "";
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                indiceBoleta = dataGridView2.SelectedRows[0].Index;
            }
            catch (Exception) { }
        }
        private void txtNombreBoleta_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreBoleta.Text != "")
            {
                txtNombreBoleta.CharacterCasing = CharacterCasing.Upper;
            }
        }
        private void txtApellidoBoleta_TextChanged(object sender, EventArgs e)
        {
            if (txtApellidoBoleta.Text != "")
            {
                txtApellidoBoleta.CharacterCasing = CharacterCasing.Upper;
            }
        }
        private void txtDNIBoleta_TextChanged(object sender, EventArgs e)
        {
            if (txtDNIBoleta.Text != "")
            {
                while (!int.TryParse(txtDNIBoleta.Text, out _) & txtDNIBoleta.Text != "")
                {
                    string aux = txtDNIBoleta.Text;
                    txtDNIBoleta.Text = aux.Remove(aux.Length - 1, 1);
                }
                txtDNIBoleta.Select(txtDNIBoleta.Text.Length, 0);
            }
            if (txtDNIBoleta.Text.Length > 8)
            {
                string aux = txtDNIBoleta.Text;
                txtDNIBoleta.Text = aux.Substring(0, 8);
                txtDNIBoleta.Select(txtDNIBoleta.Text.Length, 0);
            }
        }
        private void txtCantidadBoleta_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidadBoleta.Text != "")
            {
                while (!int.TryParse(txtCantidadBoleta.Text, out _) & txtCantidadBoleta.Text != "")
                {
                    string aux = txtCantidadBoleta.Text;
                    txtCantidadBoleta.Text = aux.Remove(aux.Length - 1, 1);
                }
                txtCantidadBoleta.Select(txtCantidadBoleta.Text.Length, 0);
            }
        }
        void ActualizarNombreBoleta()
        {
            if (cmbCategoriaBoleta.SelectedIndex != -1)
            {
                cmbNombreBoleta.Items.Clear();
                lblPrecioBoleta.Visible = false;
                lblStockBoleta.Visible = false;
                lblNumPrecioBoleta.Text = "";
                lblNumStockBoleta.Text = "";
                List<Producto>[] lista = listaInventario.ObtenerLista();
                for (int i = 0; i < lista[cmbCategoriaBoleta.SelectedIndex].Count; i++)
                {
                    cmbNombreBoleta.Items.Add(lista[cmbCategoriaBoleta.SelectedIndex][i].nombre);
                }
            }
        }
        void MostrarBoleta()
        {
            dataGridView2.Rows.Clear();
            List<Producto> listaProductos = comprador.ObtenerListaProductos();
            List<int> listaCantidades = comprador.ObtenerListaCantidades();
            for (int i = 0; i < listaProductos.Count; i++)
            {
                Producto producto = listaProductos[i];
                int cantidad = listaCantidades[i];
                dataGridView2.Rows.Add(cantidad, producto.nombre, producto.categoria, "S/. " + producto.precioV, "S/. " + (cantidad * producto.precioV));
            }
            lblPrecioTotalBoleta.Text = "S/. " + comprador.VentaTotal();
        }
        bool ExisteNombreBoleta()
        {
            bool resp = false;
            List<Producto> productos = comprador.ObtenerListaProductos();
            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].nombre == cmbNombreBoleta.SelectedItem.ToString())
                {
                    resp = true;
                }
            }
            return resp;
        }
        //Pestaña de registro de ventas
        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (listaCompradores.CantidadCompradores() == 0)
            {
                MessageBox.Show("Lista de compradores vacía.");
            }
            else if (lstCompradoresVenta.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccionar un comprador");
            }
            else
            {
                listaCompradores.EliminarComprador(lstCompradoresVenta.SelectedIndex);
                ActualizarCompradoresVenta();
            }
        }
        private void btnLimpiarVenta_Click(object sender, EventArgs e)
        {
            listaCompradores.LimpiarRegistro();
            ActualizarCompradoresVenta();
        }
        private void lstCompradoresVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCompradoresVenta.SelectedIndex != -1)
            {
                Comprador comp = listaCompradores.ObtenerLista()[lstCompradoresVenta.SelectedIndex];
                lblFechaVenta.Text = comp.fechaCompra.ToString();
                lblDNIVenta.Text = comp.dni.ToString();
                lblTotalVenta.Visible = true;
                lblNumTotalVenta.Text = "S/. " + comp.VentaTotal();
                listView1.Items.Clear();
                for (int i = 0; i < comp.CantidadProductos(); i++)
                {
                    Producto producto = comp.ObtenerListaProductos()[i];
                    int cantidad = comp.ObtenerListaCantidades()[i];
                    ListViewItem list = new ListViewItem(cantidad.ToString());
                    list.SubItems.Add(producto.nombre);
                    list.SubItems.Add(producto.categoria);
                    list.SubItems.Add("S/. " + producto.precioV);
                    list.SubItems.Add("S/. " + (producto.precioV * cantidad));
                    listView1.Items.Add(list);
                }
            }
        }
        void ActualizarCompradoresVenta()
        {
            lstCompradoresVenta.Items.Clear();
            listView1.Items.Clear();
            lblFechaVenta.Text = "";
            lblDNIVenta.Text = "";
            lblTotalVenta.Visible = false;
            lblNumTotalVenta.Text = "";
            lblNumCostoVenta.Text = "S/. " + listaCompradores.CostoTotal();
            lblNumVentaVenta.Text = "S/. " + listaCompradores.VentaTotal();
            lblNumGananciaVenta.Text = "S/. " + listaCompradores.GananciaTotal();
            List<Comprador> lista = listaCompradores.ObtenerLista();
            for (int i = 0; i < lista.Count; i++)
            {
                lstCompradoresVenta.Items.Add(lista[i].nombre + " " + lista[i].apellido);
            }
        }
        //Validación
        bool Validar(string valor, string nombre)
        {
            bool resp = true;
            if (valor == "")
            {
                resp = false;
                MessageBox.Show("El campo '" + nombre + "' está vacío.");
            }
            else if (nombre == "Precio de compra" | nombre == "Precio de venta")
            {
                double i = 0;
                if (!double.TryParse(valor, out i) | i <= 0)
                {
                    resp = false;
                    MessageBox.Show("El campo '" + nombre + "' no es válido.");
                }
            }
            else if (nombre == "Stock")
            {
                int i = 0;
                if (!int.TryParse(valor, out i) | i <= 0)
                {
                    resp = false;
                    MessageBox.Show("El campo '" + nombre + "' no es válido.");
                }
            }
            else if (nombre == "Cantidad")
            {
                int i = 0;
                if (!int.TryParse(valor, out i) | i <= 0)
                {
                    resp = false;
                    MessageBox.Show("El campo '" + nombre + "' no es válido.");
                }
                else if (i > int.Parse(lblNumStockBoleta.Text))
                {
                    resp = false;
                    MessageBox.Show("La cantidad sobrepasó el stock.");
                }
            }
            else if (nombre == "DNI")
            {
                int i = 0;
                if (!int.TryParse(valor, out i) | i < 0 | i.ToString().Length != 8)
                {
                    resp = false;
                    MessageBox.Show("El campo '" + nombre + "' no es válido.");
                }
            }
            else if (nombre == "Modificador")
            {
                if (cmbVariableInventario.SelectedIndex == 2 | cmbVariableInventario.SelectedIndex == 3)
                {
                    double i = 0;
                    if (!double.TryParse(valor, out i) | i <= 0)
                    {
                        resp = false;
                        MessageBox.Show("El campo '" + nombre + "' no es válido.");
                    }
                }
                else if (cmbVariableInventario.SelectedIndex == 4)
                {
                    int i = 0;
                    if (!int.TryParse(valor, out i) | i <= 0)
                    {
                        resp = false;
                        MessageBox.Show("El campo '" + nombre + "' no es válido.");
                    }
                }
            }
            return resp;
        }
    }
}
