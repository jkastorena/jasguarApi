using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Device")]
    public int DeviceId { get; set; }
    public DateTime TicketOpenDate { get; set; }
    public DateTime TicketCloseDate { get; set; }

    public Device Device {get; set; } = default!;
    public User User { get; set; } = default!;
}
