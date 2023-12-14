using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class RelPrestamoVajilla
{
    public int PrestamoIdFk { get; set; }

    public int VajillaIdFk { get; set; }

    public virtual Prestamo PrestamoIdFkNavigation { get; set; } = null!;

    public virtual Vajilla VajillaIdFkNavigation { get; set; } = null!;
}
