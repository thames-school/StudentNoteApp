using Microsoft.AspNetCore.Identity;

namespace StudentNoteApp.Models;

public class Teacher : IdentityUser
{
    public string FullName { get; set; }
}
