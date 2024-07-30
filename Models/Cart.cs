using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class Cart
{
    public int CartItemId { get; set; }
    public int ItemId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = default!;

}
