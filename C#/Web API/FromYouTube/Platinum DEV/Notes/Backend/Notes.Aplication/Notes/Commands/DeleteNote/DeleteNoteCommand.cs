using MediatR;

namespace Notes.Aplication.Notes.Commands.DeleteNote
{
    internal class DeleteNoteCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
