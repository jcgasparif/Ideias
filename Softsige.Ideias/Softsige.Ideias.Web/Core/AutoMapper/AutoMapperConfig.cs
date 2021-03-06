using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Softsige.Ideias.App.Models;
using Softsige.Ideias.App.ViewModels;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.App.Core.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Ideias / Anexos
            CreateMap<IdeiasModel, IdeiasViewModel>().ReverseMap();
            CreateMap<IdeiasModel, IdeiasFiltroViewModel>().ReverseMap();
            CreateMap<IdeiasModel, ComiteFiltroViewModel>().ReverseMap();
            CreateMap<AnexosModel, AnexosViewModel>().ReverseMap();
            CreateMap<ReuniaoModel, ReuniaoViewModel>().ReverseMap();
            CreateMap<ReuniaoParticipantesModel, ReuniaoParticipantesViewModel>().ReverseMap();

            // Comite
            CreateMap<ComiteModel, ComiteViewModel>().ReverseMap();
            CreateMap<AnalisesModel, ComiteViewModel>().ReverseMap();
            CreateMap<AnalisesModel, ComiteFiltroViewModel>().ReverseMap();
            CreateMap<AvaliacoesModel, AvaliacoesViewModel>().ReverseMap();

            // Usuarios
            CreateMap<AppUser, UserManager<AppUser>>().ReverseMap();
            CreateMap<AppUser, UsuariosFiltroViewModel>().ReverseMap();

            // Claims / Roles
            CreateMap<Claim, ClaimViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<RoleClaimModel, RoleClaimViewModel>().ReverseMap();
        }
    }
}