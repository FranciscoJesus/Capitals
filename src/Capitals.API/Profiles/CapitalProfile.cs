using AutoMapper;
using Capitals.API.ViewModels;
using Capitals.Core.Entities;

namespace Capitals.API.Profiles
{
    public class CapitalProfile : Profile
    {
        public CapitalProfile()
        {
            CreateMap<Capital, CapitalViewModel>();
        }
    }
}
