using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class Job
{
    [Key]
    public int JobId { get; set; }
    [ForeignKey("Ticket")]
    public int TicketId { get; set; }
    public float JobCost { get; set; }
    
    public Ticket Ticket { get; set; } = default!;
}
