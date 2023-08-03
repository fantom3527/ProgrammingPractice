﻿namespace Notes.Aplication.Common.Exception
{
    public class NotFoundException : IOException
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key} not found)") { }
    }
}
