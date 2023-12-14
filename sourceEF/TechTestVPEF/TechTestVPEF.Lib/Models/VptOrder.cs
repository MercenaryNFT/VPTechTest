namespace TechTestVPEF.Data;

public partial class VptOrder
{
    /// <summary>
    /// Guid
    /// </summary>
    public Guid OrdGuid { get; set; }

    /// <summary>
    /// Created
    /// </summary>
    public DateTime OrdCreated { get; set; }

    /// <summary>
    /// CustomerRef
    /// </summary>
    public string OrdCustomerRef { get; set; } = null!;

    /// <summary>
    /// OrderNumber
    /// </summary>
    public int OrdOrderNum { get; set; }

    /// <summary>
    /// CustomerGuid
    /// </summary>
    public Guid OrdCusGuid { get; set; }

    /// <summary>
    /// RequiredDate
    /// </summary>
    public DateTime OrdRequiredDate { get; set; }

    /// <summary>
    /// IsShipped
    /// </summary>
    public bool OrderIsShipped { get; set; }

    public virtual VptCustomer OrdCus { get; set; } = null!;

    public virtual ICollection<VptOrderLine> VptOrderLines { get; set; } = new List<VptOrderLine>();


}
