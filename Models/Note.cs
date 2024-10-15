namespace StudentNoteApp.Models;

public class Note
{
    public int Id { get; set; }

    // Change TeacherId to string to match IdentityUser's Id type
    public string TeacherId { get; set; }
    public Teacher Teacher { get; set; } // Navigation property

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public DateTime Date { get; set; }
    public string DetailsOfEvent { get; set; }
    public string Description { get; set; }
}
