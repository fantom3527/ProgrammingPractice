using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Aplication.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
