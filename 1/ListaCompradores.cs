using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class ListaCompradores
    {
        List<Comprador> lista = new List<Comprador>();
        char sep = 'þ';
        public ListaCompradores()
        {
            using (StreamReader sr = new StreamReader("./ListaCompradores.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] campos = sr.ReadLine().Split(sep);
                    Comprador comprador = new Comprador();
                    comprador.nombre = campos[0];
                    comprador.apellido = campos[1];
                    comprador.dni = int.Parse(campos[2]);
                    comprador.fechaCompra = DateTime.Parse(campos[3]);
                    comprador.archivotxt = campos[4];
                    lista.Add(comprador);
                }
            }
            for (int i = 0; i < lista.Count; i++)
            {
                using (StreamReader sr = new StreamReader(lista[i].archivotxt))
                {
                    while (sr.Peek() >= 0)
                    {
                        string[] campos = sr.ReadLine().Split(sep);
                        Producto producto = new Producto();
                        int cantidad = int.Parse(campos[0]);
                        producto.nombre = campos[1];
                        producto.categoria = campos[2];
                        producto.precioC = double.Parse(campos[3]);
                        producto.precioV = double.Parse(campos[4]);
                        lista[i].AgregarProducto(producto, cantidad);
                    }
                }
            }
        }
        public void AgregarComprador(Comprador comprador)
        {
            comprador.fechaCompra = DateTime.Now;
            comprador.archivotxt = ArchivoTexto(comprador);
            lista.Add(comprador);
            GuardarArchivoComprador(comprador);
            ActualizarArchivo();
        }
        public void EliminarComprador(int indice)
        {
            File.Delete(lista[indice].archivotxt);
            lista.RemoveAt(indice);
            ActualizarArchivo();
        }
        public void LimpiarRegistro()
        {
            while (lista.Count != 0)
            {
                File.Delete(lista[0].archivotxt);
                lista.RemoveAt(0);
            }
            ActualizarArchivo();
        }
        public List<Comprador> ObtenerLista()
        {
            return lista;
        }
        public double CostoTotal()
        {
            double total = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                total += lista[i].CostoTotal();
            }
            return total;
        }
        public double VentaTotal()
        {
            double total = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                total += lista[i].VentaTotal();
            }
            return total;
        }
        public double GananciaTotal()
        {
            return VentaTotal() - CostoTotal();
        }
        public int CantidadCompradores()
        {
            return lista.Count;
        }
        void ActualizarArchivo()
        {
            using (StreamWriter sw = new StreamWriter("./ListaCompradores.txt"))
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Comprador comprador = lista[i];
                    sw.WriteLine(comprador.nombre + sep + comprador.apellido + sep + comprador.dni + sep + comprador.fechaCompra + sep + comprador.archivotxt);
                }
            }
        }
        void GuardarArchivoComprador(Comprador comprador)
        {
            using (StreamWriter sw = new StreamWriter(comprador.archivotxt))
            {
                List<Producto> listaProductos = comprador.ObtenerListaProductos();
                List<int> listaCantidades = comprador.ObtenerListaCantidades();
                for (int i = 0; i < comprador.CantidadProductos(); i++)
                {
                    sw.WriteLine(listaCantidades[i].ToString() + sep + listaProductos[i].nombre + sep + listaProductos[i].categoria + sep + listaProductos[i].precioC + sep + listaProductos[i].precioV);
                }
            }
        }
        string ArchivoTexto(Comprador comprador)
        {
            string txt = comprador.fechaCompra.ToString();
            txt = txt.Replace("/", "");
            txt = txt.Replace(":", "");
            txt = txt.Replace("AM", "");
            txt = txt.Replace("PM", "");
            txt = txt.Replace(" ", "");
            txt = "./Comprador" + txt + ".txt";
            return txt;
        }
    }
}
