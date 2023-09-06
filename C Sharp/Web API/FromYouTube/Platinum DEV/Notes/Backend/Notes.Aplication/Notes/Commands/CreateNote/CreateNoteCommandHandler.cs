using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Notes.Aplication.Interfaces;
using Notes.Domain;

namespace Notes.Aplication.Notes.Commands.CreateNote
{
    /// <summary>
    /// Обработчик создания команды (логика создания команды).
    /// </summary>
    internal class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        //Внедрение зависимости на контекст БД в данный класс через конструктор (Для сохранения изменений В БД)
        public CreateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Формирование заметки из запроса и возвращение Id созданной заметки (логика обработки команды).
        /// </summary>
        /// <param name="requst"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> Handle(CreateNoteCommand requst, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                UserId = requst.UserId,
                Title = requst.Title,
                Details = requst.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
