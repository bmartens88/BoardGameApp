using System.Threading.Tasks;

namespace BoardGameApp.Core.Application.Interfaces
{
    public interface ITokenClaimService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
