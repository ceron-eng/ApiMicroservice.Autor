using ApiMicroservice.Autor.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiMicroservice.Autor.Persistencia
{
    public class ContextoAutor : DbContext 
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> option):  base(option)
        {
        }

        public DbSet<AutorLibro> AutorLibros { get; set; }
        public DbSet<GradoAcademico> GradosAcademicos { get; set; }
    }
}
