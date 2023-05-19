
using BlazorPeliculas.Shared.Entidades;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> ObtenerPeliculas()
        {
        return new List<Pelicula> ()
            {
            new Pelicula{   Titulo = "Rapidos y Furiosos 9",  FechaLanzamiento = new DateTime(2023 , 05, 11)},
            new Pelicula{   Titulo = "Cars",  FechaLanzamiento = new DateTime(2002 , 05, 01)},
            new Pelicula{   Titulo = "Zombiland",  FechaLanzamiento = new DateTime(2020 , 05, 11)},
            new Pelicula{   Titulo = "Rapidos y Furiosos 5",  FechaLanzamiento = new DateTime(2010 , 05, 09)},
            new Pelicula{   Titulo = "Rapidos",  FechaLanzamiento = new DateTime(2023 , 05, 12)}
            };
        }
     

        }
    }