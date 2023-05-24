using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorPeliculas.Shared.Entidades
{
public class Genero 
{
	public int Id { get; set; }

	[Required (ErrorMessage = "El Campo Nombre es requerido")]
	public string Nombre { get; set; } = null!;
}
}

