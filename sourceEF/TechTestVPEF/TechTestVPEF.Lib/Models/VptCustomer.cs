namespace TechTestVPEF.Data;

public partial class VptCustomer
{
    /// <summary>
    /// Guid
    /// </summary>
    public Guid CusGuid { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    public string CusId { get; set; } = null!;

    /// <summary>
    /// Name
    /// </summary>
    public string CusName { get; set; } = null!;

    /// <summary>
    /// Address1
    /// </summary>
    public string CusAddress1 { get; set; } = null!;

    /// <summary>
    /// Address2
    /// </summary>
    public string CusAddress2 { get; set; } = null!;

    /// <summary>
    /// Town
    /// </summary>
    public string CusTown { get; set; } = null!;

    /// <summary>
    /// Postcode
    /// </summary>
    public string CusPostcode { get; set; } = null!;

    /// <summary>
    /// Country
    /// </summary>
    public string CusCountry { get; set; } = null!;

    /// <summary>
    /// LastTraded
    /// </summary>
    public DateTime? CusLastTraded { get; set; }

    public virtual ICollection<VptOrder> VptOrders { get; set; } = new List<VptOrder>();
}
