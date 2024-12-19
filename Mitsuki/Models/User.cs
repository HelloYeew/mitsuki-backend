using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Mitsuki.Models;

public class User : IdentityUser
{
    public int ProfileId { get; set; }
    
    public Profile? Profile { get; set; }
}