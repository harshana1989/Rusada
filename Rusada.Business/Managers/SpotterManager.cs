using Microsoft.Extensions.Configuration;
using Rusada.Common.CommenModel;
using Rusada.Common.Entities;
using Rusada.Common.Interfases;
using Rusada.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Business.Managers
{
    public class SpotterManager : ISpotterManager
    {
        private readonly IMapper<object, ServiceResponse> serviceResponseMapper;

        private readonly ISpotterRepositories spotterRepositories;

        private readonly IConfiguration configuration;
        public SpotterManager(IMapper<object, ServiceResponse> serviceResponseMapper, ISpotterRepositories spotterRepositories, IConfiguration configuration)
        {
            this.serviceResponseMapper = serviceResponseMapper;
            this.spotterRepositories = spotterRepositories;
            this.configuration = configuration;
        }
        public  ServiceResponse GeModel()
        {
            try
            {
                var result = spotterRepositories.GetModel();
                return new ServiceResponse { IsError=false,ReturnObject= result };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse GetMake()
        {

            try
            {
                var result = spotterRepositories.GetMake();
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse GetSpotter()
        {
            try
            {
                var result = spotterRepositories.GetSpotters();
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse SaveSpotter(SpotterEntity spotterEntity)
        {
            try
            {
                var result = spotterRepositories.Save(spotterEntity);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
