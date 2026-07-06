using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
namespace SitioWebPwa.Helpers
{
    public static class SessionsHelper
    {
        public static void setobjectasjson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        } 
    } 
}
