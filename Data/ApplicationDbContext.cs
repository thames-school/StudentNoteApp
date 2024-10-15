using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Models;

namespace StudentNoteApp.Data;
public class ApplicationDbContext : IdentityDbContext<Teacher>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Define relationships between Note, Teacher, Student, and Subject
        builder.Entity<Note>()
            .HasOne(n => n.Teacher)
            .WithMany()
            .HasForeignKey(n => n.TeacherId);

        builder.Entity<Note>()
            .HasOne(n => n.Student)
            .WithMany()
            .HasForeignKey(n => n.StudentId);

        builder.Entity<Note>()
            .HasOne(n => n.Subject)
            .WithMany()
            .HasForeignKey(n => n.SubjectId);
    }
}