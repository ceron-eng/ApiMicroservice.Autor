using ApiMicroservice.Autor.Models;
using ApiMicroservice.Autor.Persistencia;
using FluentValidation;
using MediatR;

namespace ApiMicroservice.Autor.Aplication
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<int> // Implementa IRequest<int>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Nombre).NotEmpty();
                RuleFor(p => p.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, int> // Especifica IRequestHandler<Ejecuta, int>
        {
            private readonly ContextoAutor _context;
            public Manejador(ContextoAutor contexto)
            {
                _context = contexto;
            }

            public async Task<int> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _context.AutorLibros.Add(autorLibro);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return autorLibro.AutorLibroId; // Devolvemos el AutorLibroId
                }
                throw new Exception("No se pudo insertar el Autor del libro");
            }
        }
    }
}
