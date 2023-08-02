using MediatR;
using Notes.Aplication.Common.Exception;
using Notes.Aplication.Interfaces;
using Notes.Domain;

namespace Notes.Aplication.Notes.Commands.DeleteNote
{
    internal class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INotesDbContext _dbcontext;

        public DeleteNoteCommandHandler(INotesDbContext dbcontext) => _dbcontext = dbcontext;

        public async Task<Unit> Handle(DeleteNoteCommand requst, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes.FindAsync(new object[] { requst.Id }, cancellationToken);

            if (entity == null || entity.UserId != requst.UserId)
            {
                throw new NotFoundException(nameof(Note), requst.Id);
            }

            _dbcontext.Notes.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
