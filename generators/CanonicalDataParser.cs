using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Generators
{
    public static class CanonicalDataParser
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static CanonicalData Parse(string exercise)
        {
            var canonicalDataJson = DownloadCanonicalDataJson(exercise);
            var canonicalData = JsonConvert.DeserializeObject<CanonicalData>(canonicalDataJson);

            Validator.ValidateObject(canonicalData, new ValidationContext(canonicalData));

            return canonicalData;
        }

        private static string DownloadCanonicalDataJson(string exercise)
            => httpClient.GetStringAsync(GetCanonicalDataUrl(exercise)).GetAwaiter().GetResult();

        private static Uri GetCanonicalDataUrl(string exercise)
            => new Uri($"https://raw.githubusercontent.com/exercism/x-common/master/exercises/{exercise}/canonical-data.json");
    }
}