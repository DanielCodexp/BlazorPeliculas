
using Azure.Core.Pipeline;
using BlazorPeliculas.Shared.Entidades;
using System.Text;
using System.Text.Json;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private JsonSerializerOptions OpcionesPorDefectoJson => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public async Task<HttpResponseWrapper<T>> Get <T>(string url)
        {
            var respuestaHTTP = await httpClient.GetAsync(url);
            if(respuestaHTTP.IsSuccessStatusCode)
            {
                var respuesta = await DeserializarRespuesta<T>(respuestaHTTP, OpcionesPorDefectoJson);
                return new HttpResponseWrapper<T>(respuesta, error: false, respuestaHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, error: true, respuestaHTTP);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T> (string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null,
                !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var respone = await DeserializarRespuesta<TResponse>(responseHttp,
                    OpcionesPorDefectoJson);
                return new HttpResponseWrapper<TResponse>(respone, error: false, responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default,
                !responseHttp.IsSuccessStatusCode, responseHttp);   
        
        }
        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse,
            JsonSerializerOptions jsonSerializerOptions)
        {
            var respuestaString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaString, jsonSerializerOptions);
        }
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