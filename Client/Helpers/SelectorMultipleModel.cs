using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Helpers
{
    public class SelectorMultipleModel
    {
        public SelectorMultipleModel(string llave, string valor)
        {
            Llave = llave;
            Valor = valor;
        }
        public string Llave { get; set; } = null!;
        public string Valor { get; set; } = null!;
    }
}