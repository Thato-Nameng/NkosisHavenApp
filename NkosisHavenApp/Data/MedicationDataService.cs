using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Data
{
    public class MedicationDataService
    {
        private static readonly HttpClient _client = new HttpClient();  // Reuse HttpClient instance
        private readonly string apiUrl = "https://localhost:7069/api/Medication";
        private readonly ILogger<MedicationDataService> _logger;


        public MedicationDataService(ILogger<MedicationDataService> logger)
        {
            _logger = logger;
        }


        public async Task<IEnumerable<T>> Get<T>(CancellationToken cancellationToken = default) where T : class
        {
            var returnResponse = new List<T>();

            try
            {
                // Create a custom HttpClientHandler that disables SSL validation (for development purposes)
                var handler = new HttpClientHandler
                {
                    // WARNING: Disabling SSL verification is risky and should only be used in development environments
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };

                var client = new HttpClient(handler);

                // Log the URL for debugging purposes
                _logger.LogInformation("Sending request to URL: {Url}", apiUrl);

                var apiResponse = await client.GetAsync(apiUrl, cancellationToken);

                // Check if the response is successful
                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();

                    // If the response is empty, log and return an empty list
                    if (string.IsNullOrEmpty(response))
                    {
                        _logger.LogWarning("API response was empty for URL: {Url}", apiUrl);
                        return returnResponse;
                    }

                    try
                    {
                        // Deserialize the JSON response to a List<T>
                        returnResponse = JsonConvert.DeserializeObject<List<T>>(response);
                    }
                    catch (JsonException jsonEx)
                    {
                        // Log errors during deserialization
                        _logger.LogError(jsonEx, "Error deserializing JSON response from URL: {Url}", apiUrl);
                    }
                }
                else
                {
                    // Log if the API call fails (non-successful status code)
                    _logger.LogWarning("API call failed with status code: {StatusCode} for URL: {Url}", apiResponse.StatusCode, apiUrl);
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Log network-related errors (e.g., unable to reach the server)
                _logger.LogError(httpEx, "Error occurred while making the HTTP request.");
            }
            catch (Exception ex)
            {
                // Log any other unexpected errors
                _logger.LogError(ex, "An unexpected error occurred while fetching entities.");
            }

            return returnResponse;
        }
    }
}
