using System;
using System.Collections.Generic;
using System.ComponentModel;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.App.ViewModels
{
    public class ReuniaoViewModel
    {
        public int Id { get; set; }

        public int IdeiaId { get; set; }

        [DisplayName("Data Reunião")]
        public DateTime Data { get; set; }

        public IdeiasModel Ideia { get; set; }

        public ICollection<ReuniaoParticipantesViewModel> ReuniaoParticipantes { get; set; }
    }
}