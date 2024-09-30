using SbLeaderboards.Resources.Models;
using SbLeaderboards.Resources.Interfaces.IRepository;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
    public class ProfileService : DirectDbService<Profile>
    {
        public ProfileService(IProfileRepository repository) : base(repository)
        {
        }
    }
}
