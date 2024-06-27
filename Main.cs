using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Catalogo catalogo = new Catalogo("Todos los Productos");

        bool ejecutando = true;
        while (ejecutando)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar Categoría");
            Console.WriteLine("2. Agregar Producto");
            Console.WriteLine("3. Buscar Producto");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    AgregarCategoria(catalogo);
                    break;
                case "2":
                    AgregarProducto(catalogo);
                    break;
                case "3":
                    BuscarProducto(catalogo);
                    break;
                case "4":
                    ejecutando = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor intenta de nuevo.");
                    break;
            }
        }
    }

    static void AgregarCategoria(Catalogo catalogo)
    {
        Console.Write("Ingrese el nombre de la categoría padre (o 'raiz' para la categoría raíz): ");
        string nombreCategoriaPadre = Console.ReadLine()!;
        Categoria categoriaPadre = nombreCategoriaPadre.ToLower() == "raiz" ? catalogo.CategoriaRaiz : catalogo.BuscarCategoriaPorNombre(nombreCategoriaPadre, catalogo.CategoriaRaiz);

        if (categoriaPadre != null)
        {
            Console.Write("Ingrese el nombre de la nueva categoría: ");
            string nombreNuevaCategoria = Console.ReadLine()!;
            Categoria nuevaCategoria = new Categoria(nombreNuevaCategoria);
            catalogo.AgregarCategoria(categoriaPadre, nuevaCategoria);
            Console.WriteLine($"Categoría '{nombreNuevaCategoria}' agregada bajo '{categoriaPadre.Nombre}'.");
        }
        else
        {
            Console.WriteLine("Categoría padre no encontrada.");
        }
    }

    static void AgregarProducto(Catalogo catalogo)
    {
        Console.Write("Ingrese el nombre de la categoría para agregar el producto: ");
        string nombreCategoria = Console.ReadLine()!;
        Categoria categoria = catalogo.BuscarCategoriaPorNombre(nombreCategoria, catalogo.CategoriaRaiz);

        if (categoria != null)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombreProducto = Console.ReadLine()!;
            Console.Write("Ingrese el precio del producto: ");
            if (decimal.TryParse(Console.ReadLine()!, out decimal precioProducto))
            {
                Producto producto = new Producto(nombreProducto, precioProducto);
                catalogo.AgregarProducto(categoria, producto);
                Console.WriteLine($"Producto '{nombreProducto}' agregado a la categoría '{categoria.Nombre}'.");
            }
            else
            {
                Console.WriteLine("Precio inválido. Por favor intenta de nuevo.");
            }
        }
        else
        {
            Console.WriteLine("Categoría no encontrada.");
        }
    }

    static void BuscarProducto(Catalogo catalogo)
    {
        Console.Write("Ingrese el nombre del producto a buscar: ");
        string nombreProducto = Console.ReadLine()!;
        List<Producto> resultadosBusqueda = catalogo.BuscarProducto(nombreProducto);

        if (resultadosBusqueda.Count > 0)
        {
            Console.WriteLine("Productos encontrados:");
            foreach (var producto in resultadosBusqueda)
            {
                Console.WriteLine($"- {producto.Nombre}, Precio: {producto.Precio}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron productos con ese nombre.");
        }
    }
}
