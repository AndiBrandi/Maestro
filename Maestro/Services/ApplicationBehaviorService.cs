using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maestro.Contracts.Services;

namespace Maestro.Services;
internal class ApplicationBehaviorService : IApplicationBehaviorService
{
    public bool IsAlwaysOnTop => throw new NotImplementedException();

    public Task SetAlwaysOnTop(bool alwaysOnTop) => throw new NotImplementedException();
}
