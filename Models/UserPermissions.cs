using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasguarApi;

public class UserPermissions
{
    [Key]
    public int UserPermissionsId { get; set; }
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    [ForeignKey("ScreenApp")]
    public int ScreenId { get; set; }

    public User User { get; set; } = default!;
    public ScreenApp ScreenApp { get; set; } = default!;
}
