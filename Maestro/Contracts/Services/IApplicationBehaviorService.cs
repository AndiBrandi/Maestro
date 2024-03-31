namespace Maestro.Contracts.Services;

public interface IApplicationBehaviorService
{
    bool IsAlwaysOnTop
    {
        get;
    }

    Task SetAlwaysOnTop(bool alwaysOnTop);
}