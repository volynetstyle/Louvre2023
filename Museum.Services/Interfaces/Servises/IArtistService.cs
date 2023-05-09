using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;

namespace Museum.App.Services.Interfaces.Repositories
{
    internal interface IArtistService : IBasicService<ArtistAdapter>
    {
    }
}
