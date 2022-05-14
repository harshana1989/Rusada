using Rusada.Common.CommenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.Managers
{
    public interface ISpotterManager
    {
        ServiceResponse GeModel();
        ServiceResponse GetMake();
        ServiceResponse GetSpotter();
    }
}
