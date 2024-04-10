using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("Motorista", Schema = "dbo")]
    public class Motorista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Eixos { get; set; }
    }
}