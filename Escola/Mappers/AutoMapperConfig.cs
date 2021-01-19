using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            var mapper = config.CreateMapper();            
        }
    }
}
