using Rusada.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.Interfases
{

    public interface ISpotterRepositories
    {
        /// <summary>
        /// GetSpotters
        /// </summary>
        /// <returns></returns>
        Task<List<SpotterEntity>> GetSpotters();
        /// <summary>
        /// GetModel
        /// </summary>
        /// <returns></returns>
        Task<List<ModelEntity>> GetModel();
        /// <summary>
        /// GetMake
        /// </summary>
        /// <returns></returns>
        Task<List<MakeEntity>> GetMake();
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="clientNote"></param>
        /// <returns></returns>
        Task<SpotterEntity> Save(SpotterEntity clientNote);
        
    }
}
