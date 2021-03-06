using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CpmLib.Web.Core.Session
{
    public static class SessionExtensions
    {
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);

            if (data == null) {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
