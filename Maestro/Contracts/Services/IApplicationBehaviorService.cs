using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maestro.Contracts.Services;
public interface IApplicationBehaviorService
{

    bool IsAlwaysOnTop
    {
        get;
    }

    Task SetAlwaysOnTop(bool alwaysOnTop);

}
