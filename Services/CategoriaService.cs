using webapi.Models;

namespace webapi.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.AddRange(categoria);
        await context.SaveChangesAsync();  
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaAcual = context.Categorias.Find(id);
        
        if (categoriaAcual != null)
        {
            categoriaAcual.Nombre = categoria.Nombre;
            categoria.Descripcion = categoriaAcual.Descripcion;
            categoria.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }


    public async Task Delete(Guid id)
    {
        var categoriaAcual = context.Categorias.Find(id);
        
        if (categoriaAcual != null)
        {
            context.Remove(categoriaAcual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}