using Maestro.Core.Models;

namespace Maestro.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<Song>> GetListDetailsDataAsync();

    Task<IEnumerable<Song>> GetContentGridDataAsync();
}
