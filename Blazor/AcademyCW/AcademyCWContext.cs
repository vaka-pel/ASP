using Microsoft.EntityFrameworkCore;

public class AcademyCWContext(DbContextOptions<AcademyCWContext> options) : DbContext(options)
{
    public DbSet<AcademyCW.Models.Discipline> Disciplines { get; set; } = default!;
    public DbSet<AcademyCW.Models.Direction> Directions { get; set; } = default!;
    public DbSet<AcademyCW.Models.Group> Groups { get; set; } = default!;
    public DbSet<AcademyCW.Models.Student> Students { get; set; } = default!;
}
