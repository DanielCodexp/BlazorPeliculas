using BlazorPeliculas.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServicioSingleton singleton { get; set; } = null!;

        [Inject] ServicioTransient transient { get; set; } = null!;
      
        [Inject] protected IJSRuntime JS {get; set;} = null!;
        [CascadingParameter] protected AppState appState { get; set; } = null!;

        IJSObjectReference modulo;
        
        private int currentCount = 0;
        private static int currentCountStatic = 0;

        private async Task IncrementCount()
        {

            modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await modulo.InvokeVoidAsync("mostrarAlerta", "Hola Mundo");

            currentCount++;
            currentCountStatic = currentCount;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }

         [JSInvokable]
         public static Task<int> ObtenerCurrentCount()
         {
             return Task.FromResult(currentCountStatic);
         }

        private async Task IncrementCountJavaScript()
        {
            await JS.InvokeVoidAsync("pruebaPuntoNetInstancia",
                DotNetObjectReference.Create(this)            
            );
        }

    }
}