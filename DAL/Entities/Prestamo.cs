using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Prestamo
{
    public DateOnly? FechaPrestamo { get; set; }

    public int IdPrestamo { get; set; }
}
