using System.ComponentModel.DataAnnotations.Schema;

namespace Mitsuki.Models;

public class Profile
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("User")]
    public string UserId { get; set; }
    
    public User User { get; set; } = null!;
    
}