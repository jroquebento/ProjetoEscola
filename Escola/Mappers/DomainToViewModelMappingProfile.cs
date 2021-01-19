using AutoMapper;
using Escola.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entidades.Aluno, Aluno>();
                cfg.CreateMap<Entidades.Pessoa, Pessoa>();
            }).CreateMapper();
        }        
    }
}
