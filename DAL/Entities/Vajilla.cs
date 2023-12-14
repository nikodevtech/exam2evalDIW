using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Vajilla
{
    public int? Cantidad { get; set; }

    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Nombre { get; set; }


    public void MostrarDatos()
    {
        Console.WriteLine("\n\t---Datos de la vajilla---\n\tNombre: {0}\n\tCodigo: {1}\n\tCantidad: {2}", Nombre, Codigo, Cantidad);
    }
}
