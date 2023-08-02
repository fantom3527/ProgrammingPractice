using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Aplication.Common.Exception;
using Notes.Aplication.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Aplication.Notes.Commands.UpdateNote
{
    internal class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INotesDbContext _dbcontext;

        public UpdateNoteCommandHandler(INotesDbContext dbcontext) => _dbcontext = dbcontext;

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
