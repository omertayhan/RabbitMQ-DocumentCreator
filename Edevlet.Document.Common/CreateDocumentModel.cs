﻿namespace Edevlet.Document.Common
{
    public class CreateDocumentModel
    {
        public int UserId { get; set; }
        public string Url { get; set; }

        public DocumentType Document { get; set; }
    }
    public enum DocumentType
    {
        Pdf,
        Html,
        Png
    }
}
