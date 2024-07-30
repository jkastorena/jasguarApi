using System.ComponentModel.DataAnnotations;

namespace jasguarApi;

public class DeviceType
{
    [Key]
    public int DeviceTypeId { get; set; }
    public string? DeviceName { get; set; }
}
