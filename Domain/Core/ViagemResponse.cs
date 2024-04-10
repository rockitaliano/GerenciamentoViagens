using System;

namespace Domain.Core
{
    public class ViagemResponse
    {
        public int ViagemId { get; set; }
        public DateTime DataHoraViagem { get; set; }
        public string Entrega { get; set; }
        public string Saida { get; set; }
        public int KmPercurso { get; set; }
        public int PesoCarga { get; set; }
        public int MotoristaId { get; set; }
    }
}