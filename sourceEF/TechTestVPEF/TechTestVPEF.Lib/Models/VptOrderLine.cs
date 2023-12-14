using System;
using System.Collections.Generic;

namespace TechTestVPEF.Data;

public partial class VptOrderLine
{
    /// <summary>
    /// Guid
    /// </summary>
    public Guid OrlGuid { get; set; }

    /// <summary>
    /// OrderGuid
    /// </summary>
    public Guid OrlOrdGuid { get; set; }

    /// <summary>
    /// ProductGuid
    /// </summary>
    public Guid OrlPrdGuid { get; set; }

    /// <summary>
    /// Qty
    /// </summary>
    public int OrlQty { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    public decimal OrlPrice { get; set; }

    /// <summary>
    /// UOM
    /// </summary>
    public string OrlUom { get; set; } = null!;

    public virtual VptOrder OrlOrd { get; set; } = null!;

    public virtual VptProduct OrlPrd { get; set; } = null!;
}
