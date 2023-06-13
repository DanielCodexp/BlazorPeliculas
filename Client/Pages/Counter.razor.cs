using BlazorPeliculas.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        [CascadingParameter]
        private Task<AuthenticationState>
            authenticationStateTask { get; set; } = null!;
        private async void IncrementCount()
        {

            var arreglo = new double[] { 1, 2, 3, 4, 5 };

            var authenticationState = await authenticationStateTask;
            var usuarioEstaAutenticado = authenticationState.User.Identity!.IsAuthenticated;

            if (usuarioEstaAutenticado)
            {
                currentCount += 1;
            }
            else
            {
                
                currentCount -= 1;  
            }



        }

        

    }
}