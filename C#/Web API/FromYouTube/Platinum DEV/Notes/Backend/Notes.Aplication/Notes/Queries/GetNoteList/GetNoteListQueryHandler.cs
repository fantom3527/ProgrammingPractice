using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Aplication.Notes.Queries.GetNoteList
{
    internal class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INotesDbContext dbcontext, IMapper mapper) => (_dbcontext, _mapper) = (dbcontext, mapper);


        public async Task<NoteListVm> Handle(GetNoteListQuery requst, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbcontext.Notes
                .Where(note => note.UserId == requst.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
