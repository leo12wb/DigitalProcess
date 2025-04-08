namespace DigitalProcess.Models
{
    public class ProcessType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TemplateDocumentId { get; set; }

        public Document Template { get; set; }
    }
}
