namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
     public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value,
          IJsonFormatterResolver? resolver = null) =>
          Utf8JsonHelper.ToStreamAsync(value, resolver);

     public static Task<MemoryStream> ToStreamAsync(this object? value,
          IJsonFormatterResolver? resolver = null) =>
          Utf8JsonHelper.ToStreamAsync(value, resolver);

     public static Task<MemoryStream> ToStreamAsync(this object? value, Type type,
          IJsonFormatterResolver? resolver = null) =>
          Utf8JsonHelper.ToStreamAsync(type, value, resolver);
}