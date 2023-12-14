using System;
using System.Collections.Generic;

namespace TechTestVPEF.Data;

public partial class VptProduct
{
    /// <summary>
    /// Guid
    /// </summary>
    public Guid PrdGuid { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    public string PrdId { get; set; } = null!;

    /// <summary>
    /// Description
    /// </summary>
    public string PrdDescription { get; set; } = null!;

    /// <summary>
    /// Price
    /// </summary>
    public decimal PrdPrice { get; set; }

    /// <summary>
    /// Cost
    /// </summary>
    public decimal PrdCost { get; set; }

    public virtual ICollection<VptOrderLine> VptOrderLines { get; set; } = new List<VptOrderLine>();
}
