using System.ComponentModel.DataAnnotations;

namespace jasguarApi;

public class Display
{
    [Key]
    public int DisplayId { get; set; }
    public string? BacklightType { get; set; }
    public int PinNumber { get; set; }
}
