using Rusada.Common.CommenModel;
using Rusada.Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.Mappers
{
    public class ServiceErrorWithReturnMapper : IMapper<(IList<Message>, object), ServiceResponse>
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public ServiceResponse Map((IList<Message>, object) input) => new()
        {
            IsError = true,
            Messages = input.Item1,
            ReturnObject = input.Item2
        };
    }
}