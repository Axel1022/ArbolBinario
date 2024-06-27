public class Catalogo
{
    public Categoria CategoriaRaiz { get; set; }

    public Catalogo(string nombreCategoriaRaiz)
    {
        CategoriaRaiz = new Categoria(nombreCategoriaRaiz);
    }

    public void AgregarCategoria(Categoria categoriaPadre, Categoria nuevaCategoria)
    {
        categoriaPadre.AgregarSubCategoria(nuevaCategoria);
    }

    public void AgregarProducto(Categoria categoria, Producto producto)
    {
        categoria.AgregarProducto(producto);
    }

    public List<Producto> BuscarProducto(string nombreProducto)
    {
        return CategoriaRaiz.BuscarProducto(nombreProducto);
    }

    public Categoria BuscarCategoriaPorNombre(string nombreCategoria, Categoria categoriaActual)
    {
        if (categoriaActual.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase))
        {
            return categoriaActual;
        }

        foreach (var subCategoria in categoriaActual.SubCategorias)
        {
            var categoriaEncontrada = BuscarCategoriaPorNombre(nombreCategoria, subCategoria);
            if (categoriaEncontrada != null)
            {
                return categoriaEncontrada;
            }
        }

        return null;
    }
}
