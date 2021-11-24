using System;
using System.IO;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static void PackBy<T>(this Stream stream, T t) =>
            DataContractHelper.Pack(t, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            DataContractHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            DataContractHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            DataContractHelper.Unpack(type, stream);
    }
}