using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using TournamentMaster.Application.Interfaces.AWS;

namespace TournamentMaster.Infrastructure.AWS
{
    public class AwsSecretProvider : ISecretProvider
    {
        private readonly IAmazonSecretsManager _secretsManager;

        public AwsSecretProvider(IAmazonSecretsManager secretsManager)
        {
            _secretsManager = secretsManager;
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            if (secretName is null)
            {
                throw new ArgumentNullException(nameof(secretName));
            }

            var request = new GetSecretValueRequest
            {
                SecretId = secretName
            };

            var response = await _secretsManager.GetSecretValueAsync(request);

            return response.SecretString;
        }
    }
}
