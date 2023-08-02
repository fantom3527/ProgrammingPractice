using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Aplication.Notes.Queries.GetNoteList
{
    internal class NoteListVm
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
