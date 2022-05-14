using Rusada.Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.CommenModel
{
    public class ErrorMessages : IErrorMessages
    {
        /// <summary>
        /// Gets the invalid reference data.
        /// </summary>
        /// <returns></returns>
        public Message GetInvalidReferenceData()
        {
            return new Message
            {
                Code = "E0001",
                Description = "Error.E0001"
            };
        }

        /// <summary>
        /// Gets the service error message.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <returns></returns>
        public Message GetServiceErrorMessage(string desc) => new Message
        {
            Code = "E0002",
            Description = string.Format("Error.E0002", desc)
        };

    }
}
