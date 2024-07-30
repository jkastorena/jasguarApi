using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace jasguarApi;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string? RoleDescription { get; set; }
}
