using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace jasguarApi;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string? Phone { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Lastname { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? Salt { get; set; }
    public bool IsActive { get; set; } = true;
    public bool ValidatedAccount { get; set; } = false;
    public DateTime Createdon { get; set; } = DateTime.UtcNow;
    [ForeignKey("Role")]
    public int RoleId { get; set; } = 1;


    public Role Role { get; set; } = default!;
    public void EncryptPw()
    {
        if (this.Password == null) this.Password = "Pending";

        StringBuilder sb = new StringBuilder();
        using (var md5 = SHA512.Create())
        {
            byte[] Md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(this.Password));

            foreach (byte b in Md5HashBytes)
            {
                sb.Append(b.ToString("X2"));
            }
        }
        this.Password = sb.ToString();
    }

    public void AddSalt(){

        var r = new Random();
        int A = r.Next(10000, 90000);
        this.Salt = A.ToString("X2");
    }

    

}

