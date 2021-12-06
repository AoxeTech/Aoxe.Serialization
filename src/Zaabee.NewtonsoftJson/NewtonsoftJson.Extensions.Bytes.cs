using System;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static TValue? FromBytes<TValue>(this byte[] bytes, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Deserialize<TValue>(bytes, settings, encoding);

        public static object? FromBytes(this byte[] bytes, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Deserialize(type, bytes, settings, encoding);
    }
}