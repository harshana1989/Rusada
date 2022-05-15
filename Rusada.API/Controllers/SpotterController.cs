using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rusada.Common.CommenModel;
using Rusada.Common.Entities;
using Rusada.Common.Interfases;
using Rusada.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusada.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotterController : ControllerBase
    {
        private ISpotterManager spotterManager;
       
        private readonly IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper;

        private readonly IErrorMessages errorMessages;

        private readonly ILogger logger;

        public SpotterController(ISpotterManager spotterManager, IMapper<IList<Message>,ServiceResponse> serviceResponseErrorMapper
            , IErrorMessages errorMessages,ILogger<SpotterController> logger)
        {
           // this.serviceResponseMapper = serviceResponseMapper;
            this.spotterManager = spotterManager;
            this.serviceResponseErrorMapper = serviceResponseErrorMapper;
            this.errorMessages = errorMessages;
            this.logger = logger;
        }
        /// <summary>
        /// GetMake
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMake")]
        public async Task<ServiceResponse> GetMake()
        {
            try
            {
                return spotterManager.GetMake();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
        /// <summary>
        /// GetModel
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetModel")]
        public async Task<ServiceResponse> GetModel()
        {
            try
            {
                return spotterManager.GeModel();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
        /// <summary>
        /// GetSpotter
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSpotter")]
        public async Task<ServiceResponse> GetSpotter()
        {
            try
            {
                var res = spotterManager.GetSpotter();
                return res;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }

        [HttpGet("SaveSpotter")]
        public async Task<ServiceResponse> SaveSpotter(SpotterEntity spotterEntity)
        {
            try
            {
                var res = spotterManager.SaveSpotter(spotterEntity);
                return res;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
    }
}
