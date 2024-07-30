using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class ACAdapter 
{
    [Key]
    public int ACAdapterId { get; set; }
    public string? Brand { get; set; }
    public float InputVoltaje { get; set; }
    public float OutputVoltaje { get; set; }
    [ForeignKey("ConnectorType")]
    public int AcadapterConnectorTypeId { get; set; }

    public ConnectorType ConnectorType { get; set; } = default!;
}
