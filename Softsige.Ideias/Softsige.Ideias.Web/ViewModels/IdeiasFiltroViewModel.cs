using System;

namespace Softsige.Ideias.App.ViewModels
{
    public class IdeiasFiltroViewModel
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AspNetUsersId { get; set; }
        public string Descricao { get; set; }
        public int StatusId { get; set; }
    }
}