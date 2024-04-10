using Domain.Core;
using System;

namespace Domain.ViewModels
{
    public class CreateViagemViewModel
    {
        public int IdViagem { get; set; }
        public DateTime DataHoraViagem { get; set; }
        public string Entrega { get; set; }
        public string Saida { get; set; }
        public int KmPercurso { get; set; }
        public int PesoCarga { get; set; }
        public int MotoristaId { get; set; }

        public Notification Validate()
        {
            var notifications = new Notification();

            if (MotoristaId == 0)
                notifications.SendMessage.Add("Id do motorista é obrigatório");

            return notifications;
        }
    }
}