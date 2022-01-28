﻿using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.App.ViewModels
{
    public class ReuniaoParticipantesViewModel
    {
        public int Id { get; set; }
        public int ReuniaoId { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        public virtual ReuniaoModel Reuniao { get; set; }
    }
}