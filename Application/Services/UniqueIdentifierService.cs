using Application.Interfaces.IServices;

namespace Application.Services
{
    public class UniqueIdentifierService : IUniqueIdentifier
    {
        public async Task<string> GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

       
    }
}
