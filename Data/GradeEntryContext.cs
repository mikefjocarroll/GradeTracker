using Microsoft.EntityFrameworkCore;
using gradeTracker.Models;

namespace gradeTracker.Data;

public class GradeEntryContext : DbContext
{
    public GradeEntryContext(DbContextOptions<GradeEntryContext> options) :
        base(options)
    {
    }
    
    public DbSet<GradeEntry> GradeEntries { get; set; }
}