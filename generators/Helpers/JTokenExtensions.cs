using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Helpers
{
    public static class JTokenExtensions
    {
        public static IEnumerable<JToken> ParentsAndSelf(this JToken jToken)
        {
            while (jToken != null)
            {
                yield return jToken;
                jToken = jToken.Parent;
            }
        }
    }
}