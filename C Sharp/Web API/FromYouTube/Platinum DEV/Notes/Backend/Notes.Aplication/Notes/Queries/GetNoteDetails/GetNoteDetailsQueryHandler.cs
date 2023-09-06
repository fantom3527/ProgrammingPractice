using AutoMapper;
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

namespace Notes.Aplication.Notes.Queries.GetNoteDetails
{
    internal class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (dbContext, mapper) = (dbContext, mapper);

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery requst, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == requst.Id, cancellationToken);

            if (entity == null || entity.UserId != requst.UserId)
            {
                throw new NotFoundException(nameof(Note), requst.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
