using System;
using System.Collections.Generic;
using System.Linq;

public class Categoria
{
    public string Nombre { get; set; }
    public List<Categoria> SubCategorias { get; set; }
    public List<Producto> Productos { get; set; }

    public Categoria(string nombre)
    {
        Nombre = nombre;
        SubCategorias = new List<Categoria>();
        Productos = new List<Producto>();
    }

    public void AgregarSubCategoria(Categoria subCategoria)
    {
        SubCategorias.Add(subCategoria);
    }

    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }

    public List<Producto> BuscarProducto(string nombreProducto)
    {
        List<Producto> productosEncontrados = new List<Producto>();

        productosEncontrados.AddRange(Productos.Where(p => p.Nombre.Contains(nombreProducto, StringComparison.OrdinalIgnoreCase)));

        foreach (var subCategoria in SubCategorias)
        {
            productosEncontrados.AddRange(subCategoria.BuscarProducto(nombreProducto));
        }

        return productosEncontrados;
    }
}
