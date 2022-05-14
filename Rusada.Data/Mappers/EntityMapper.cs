using AutoMapper;
using Rusada.Common.Entities;
using Rusada.Common.Interfases;
using Rusada.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Data.Mappers
{
    public class EntityMapper : IEntityMapper
    {
        private MapperConfiguration _config;
        private IMapper _mapper;

        public EntityMapper()
        {
            Configure();
            Create();
            
        }
        private void Configure()
        {
            _config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Make, MakeEntity>();
                cfg.CreateMap<AirlineModel, ModelEntity>();
                cfg.CreateMap<Spotter, SpotterEntity>();

            });
        }
        private void Create()
        {
            _mapper=_config.CreateMapper();
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
       
    }
}
