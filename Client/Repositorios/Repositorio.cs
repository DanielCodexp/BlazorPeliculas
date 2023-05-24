
using BlazorPeliculas.Shared.Entidades;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> ObtenerPeliculas()
        {
        return new List<Pelicula> ()
            {
            new Pelicula{   Titulo = "Rapidos y Furiosos 9", Lanzamiento = new DateTime(2021 , 05, 11),
             Poster ="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRq6_4OeNfendbg5EM1mL-CcwQnREi8vDozw4ESryy4gdJ9jqFm"},
            new Pelicula{   Titulo = "Cars", Lanzamiento = new DateTime(2006 , 05, 01),
             Poster="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcS3_Bu8aJaA_DE7bOSQ7bz3o9Y6whQ7_0PxNnBfGXQ82nE1xVRh"},
            new Pelicula{   Titulo = "Zombieland",  Lanzamiento = new DateTime(2009 , 05, 11),
            Poster="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFq-3wneGydZFFqKUVZbGPSon3lV7CSqbrP_rlb-uu&usqp=CAE&s"},
            new Pelicula{   Titulo = "Rapidos y Furiosos 5",  Lanzamiento = new DateTime(2011 , 05, 09),
            Poster="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQCVsIH_fzlUD2m4v-O3IDF_YxD724OGFlniSWoP7vr4NMWWXXm" },
            new Pelicula{   Titulo = "Zombieland: tiro de gracia",  Lanzamiento = new DateTime(2019 , 05, 12),
            Poster="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRxW1i5hr1h2jh9cfFe9fv0yR_Ut18JYEd89jS9GP5CxGb-96nI"}
            };
        }
     

        }
    }