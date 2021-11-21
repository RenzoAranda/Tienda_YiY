using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class ListaInventario
    {
        List<Producto>[] lista = new List<Producto>[5];
        char sep = 'þ';
        public ListaInventario()
        {
            for (int i = 0; i < 5; i++)
            {
                lista[i] = new List<Producto>();
            }
            using (StreamReader sr = new StreamReader("./Inventario.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] campo = sr.ReadLine().Split(sep);
                    Producto producto = new Producto();
                    producto.nombre = campo[0];
                    producto.numCategoria = int.Parse(campo[1]);
                    producto.categoria = campo[2];
                    producto.precioC = double.Parse(campo[3]);
                    producto.precioV = double.Parse(campo[4]);
                    producto.stock = int.Parse(campo[5]);
                    lista[producto.numCategoria].Add(producto);
                }
            }
        }
        public void AgregarProducto(Producto producto)
        {
            switch (producto.numCategoria)
            {
                case 0:
                    producto.categoria = "Recreación";
                    break;
                case 1:
                    producto.categoria = "Limpieza";
                    break;
                case 2:
                    producto.categoria = "Librería";
                    break;
                case 3:
                    producto.categoria = "Cocina";
                    break;
                case 4:
                    producto.categoria = "Otro";
                    break;
            }
            lista[producto.numCategoria].Add(producto);
            ActualizarArchivo();
        }
        public void EliminarProducto(Producto producto)
        {
            lista[producto.numCategoria].RemoveAt(IndiceProducto(producto));
            ActualizarArchivo();
        }
        public void ModificarProducto(Producto antProducto, int variable, string valor)
        {
            Producto producto = lista[antProducto.numCategoria][IndiceProducto(antProducto)];
            lista[antProducto.numCategoria].RemoveAt(IndiceProducto(antProducto));
            switch (variable)
            {
                case 0:
                    producto.nombre = valor;
                    break;
                case 1:
                    producto.numCategoria = int.Parse(valor);
                    break;
                case 2:
                    producto.precioC = double.Parse(valor);
                    break;
                case 3:
                    producto.precioV = double.Parse(valor);
                    break;
                case 4:
                    producto.stock = int.Parse(valor);
                    break;
            }
            AgregarProducto(producto);
        }
        public List<Producto>[] ObtenerLista()
        {
            return lista;
        }
        public Producto ObtenerProducto(string nombre, int categoria)
        {
            Producto producto = new Producto();
            for (int i = 0; i < lista[categoria].Count; i++)
            {
                Producto productoAux = lista[categoria][i];
                if (nombre == productoAux.nombre)
                {
                    producto = productoAux;
                }
            }
            return producto;
        }
        public int CantidadProductos()
        {
            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                total += lista[i].Count;
            }
            return total;
        }
        void ActualizarArchivo()
        {
            using (StreamWriter sw = new StreamWriter("./Inventario.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int e = 0; e < lista[i].Count; e++)
                    {
                        Producto producto = lista[i][e];
                        sw.WriteLine(producto.nombre + sep + producto.numCategoria + sep + producto.categoria + sep + producto.precioC + sep + producto.precioV + sep + producto.stock);
                    }
                }
            }
        }
        int IndiceProducto(Producto producto)
        {
            int resp = -1;
            int cont = 0;
            do
            {
                Producto productoLista = lista[producto.numCategoria][cont];
                if (producto.nombre == productoLista.nombre & producto.stock == productoLista.stock)
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
