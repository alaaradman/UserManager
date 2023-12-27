namespace Application.Interfaces.IServices
{
    public interface IUniqueIdentifier
    {
         Task<string> GenerateUniqueId();
        
    }
}
