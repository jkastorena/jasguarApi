using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class Device
{
    [Key]
    public int DeviceId { get; set; }
    [ForeignKey("DeviceType")]
    public int DeviceTypeId {get; set;}
    public string? Brand {get; set;}
    public string? Description {get; set;}
    [ForeignKey("ACAdapter")]
    public int AcAdapterId {get; set;}
    [ForeignKey("Display")]
    public int DisplayId {get; set;}

    public ACAdapter ACAdapter {get; set;} = default!;
    public DeviceType DeviceType {get; set;} = default!;
    public Display Display {get; set;} = default!;
}
