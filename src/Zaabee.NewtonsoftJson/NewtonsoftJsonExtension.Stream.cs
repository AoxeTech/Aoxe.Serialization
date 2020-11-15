using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtension
    {
        public static void PackBy<T>(this Stream stream, T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(t, stream, settings, encoding);

        public static void PackBy(this Stream stream, Type type, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(type, obj, stream, settings, encoding);

        public static T Unpack<T>(this Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Unpack<T>(stream, settings, encoding);

        public static object Unpack(this Stream stream, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Unpack(type, stream, settings, encoding);
    }
}