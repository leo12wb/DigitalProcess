namespace DigitalProcess.Models
{
    public enum DocumentType
    {
        Internal,
        External
    }

    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DocumentType Type { get; set; }

        // Para arquivos externos (PDFs)
        public string? FilePath { get; set; }

        // Para documentos internos
        public string? Content { get; set; }

        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}
