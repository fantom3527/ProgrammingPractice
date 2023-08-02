using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Notes.Aplication.Notes.Commands.CreateNote
{
    /// <summary>
    /// Содержит информацию что необходиом для создания заметки.
    /// </summary>
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
