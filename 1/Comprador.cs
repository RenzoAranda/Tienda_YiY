using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Comprador
    {
        List<Producto> listaProductos = new List<Producto>();
        List<int> listaCantidades = new List<int>();
        public DateTime fechaCompra;
        public string nombre, apellido, archivotxt;
        public int dni;
        public void AgregarProducto(Producto producto, int cantidad)
        {
            listaProductos.Add(producto);
            listaCantidades.Add(cantidad);
        }
        public void EliminarProducto(Producto producto)
        {
            int indice = indiceProducto(producto);
            listaProductos.RemoveAt(indice);
            listaCantidades.RemoveAt(indice);
        }
        public List<Producto> ObtenerListaProductos()
        {
            return listaProductos;
        }
        public List<int> ObtenerListaCantidades()
        {
            return listaCantidades;
        }
        public double CostoTotal()
        {
            double total = 0;
            for (int i = 0; i < listaProductos.Count; i++)
            {
                total += listaProductos[i].precioC * listaCantidades[i];
            }
            return total;
        }
        public double VentaTotal()
        {
            double total = 0;
            for (int i = 0; i < listaProductos.Count; i++)
            {
                total += listaProductos[i].precioV * listaCantidades[i];
            }
            return total;
        }
        public int CantidadProductos()
        {
            return listaProductos.Count;
        }
        int indiceProducto(Producto producto)
        {
            int resp = -1;
            int cont = 0;
            do
            {
                if (listaProductos[cont].nombre == producto.nombre)
                {
                    resp = cont;
                }
                cont++;
            }
            while (resp == -1);
            return resp;
        }
    }
}
