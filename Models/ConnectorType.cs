using System.ComponentModel.DataAnnotations;

namespace jasguarApi;

public class ConnectorType
{
    [Key]
    public int ConnectorTypeId { get; set; }
    public string? ConnectorName { get; set;}
    public string? Polarity { get; set;}
    public int ConnectorWidth {get; set; }
}
