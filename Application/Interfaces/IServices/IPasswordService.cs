namespace Application.Interfaces.IServices
{
    public interface IPasswordService
    {
        Task<string> GenerateSaltAsync();
        Task<string> HashPasswordAsync(string password, string salt);
         Task<bool> VerifyPasswordAsync(string password, string hashedPassword, string salt);
    }
}
