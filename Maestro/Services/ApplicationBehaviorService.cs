using Maestro.Contracts.Services;

namespace Maestro.Services;
internal class ApplicationBehaviorService : IApplicationBehaviorService
{
    public bool IsAlwaysOnTop => throw new NotImplementedException();

    public Task SetAlwaysOnTop(bool alwaysOnTop) => throw new NotImplementedException();
}
