using Rusada.Common.CommenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.Interfases
{
    public interface IErrorMessages
    {
        /// <summary>
        /// Gets the invalid reference data.
        /// </summary>
        /// <returns></returns>
        Message GetInvalidReferenceData();

        /// <summary>
        /// Gets the service error message.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <returns></returns>
        Message GetServiceErrorMessage(string desc);

    }
}