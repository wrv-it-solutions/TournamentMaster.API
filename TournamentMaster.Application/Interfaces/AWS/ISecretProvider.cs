namespace TournamentMaster.Application.Interfaces.AWS
{
    public interface ISecretProvider
    {
        public Task<string> GetSecretAsync(string secretName);
    }
}
