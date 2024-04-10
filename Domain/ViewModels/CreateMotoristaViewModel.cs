using Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class CreateMotoristaViewModel
    {
        public int MotoristaId { get; set; }
        public string Nome { get; set; }        
        public string Sobrenome { get; set; }       
        public string Endereco { get; set; }              
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Eixos { get; set; }
        public string Marca { get; set; }

        public Notification Validade()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(Nome))
                notifications.SendMessage.Add("Nome é obrigatório");

            if (string.IsNullOrEmpty(Endereco))
                notifications.SendMessage.Add("Endereço é obrigatório");

            if (string.IsNullOrEmpty(Placa))
                notifications.SendMessage.Add("Placa do Caminhão é obrigatório");

            if (string.IsNullOrEmpty(Modelo))
                notifications.SendMessage.Add("Modelo do Caminhão é obrigatório");

            if (string.IsNullOrEmpty(Eixos))
                notifications.SendMessage.Add("Quantidade de eixos é obrigatorio");

            return notifications;
        }
    }
}