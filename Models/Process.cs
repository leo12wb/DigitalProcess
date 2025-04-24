namespace DigitalProcess.Models
{
    public class Process
    {
        // Identificador único do processo no banco de dados (chave primária)
        public int Id { get; set; }

        // Número de protocolo gerado para o processo (ex: 202404130001)
        public string? ProtocolNumber { get; set; }

        // Chave estrangeira indicando o tipo de processo (ex: "Solicitação", "Reclamação", "Projeto", "Oficio")
        public int? TypeId { get; set; }

        // Objeto de navegação para acessar os dados do tipo do processo
        public ProcessType? Type { get; set; }

        // Organização de origem do processo (opcional)
        public int? OriginOrganizationId { get; set; }

        // Objeto de navegação para acessar a organização de origem
        public Organization? OriginOrganization { get; set; }

        // Setor de origem do processo (opcional)
        public int? OriginSectorId { get; set; }

        // Objeto de navegação para acessar o setor de origem
        public Sector? OriginSector { get; set; }

        // Organização onde o processo se encontra atualmente (opcional)
        public int? CurrentOrganizationId { get; set; }

        // Objeto de navegação para acessar a organização atual
        public Organization? CurrentOrganization { get; set; }

        // Setor onde o processo se encontra atualmente (opcional)
        public int? CurrentSectorId { get; set; }

        // Objeto de navegação para acessar o setor atual
        public Sector? CurrentSector { get; set; }

        public int? UserCreateId { get; set; }
        public User? UserCreate { get; set; }
        
        //Prazo de Conclusao
        public DateTime? CompletionDeadline { get; set; }

        // Data de Encerramento
        public DateTime? ClosingDate { get; set; }

        // Nivel de Acesso
        public required string AccessLevel { get; set; } // Ex: "Público", "Restrito", "Sigiloso"

        public required string Status { get; set; }

        // Data de criação do processo. Definida automaticamente com a data/hora atual (UTC).
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Lista de documentos vinculados ao processo (internos ou anexados)
        public List<Document>? Documents { get; set; }

        // Lista de movimentações realizadas no processo (histórico de envio/recebimento)
        public List<ProcessMovement>? Movements { get; set; }
    }
}
