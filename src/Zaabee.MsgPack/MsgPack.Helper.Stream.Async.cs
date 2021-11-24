namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    public static Task<MemoryStream> PackAsync<T>(T t) =>
        t is null
            ? Task.FromResult(new MemoryStream())
            : MsgPackSerializer.PackAsync(t);

    public static Task PackAsync<T>(T t, Stream stream) =>
        t is null || stream is null
            ? Task.CompletedTask
            : MsgPackSerializer.PackAsync(t, stream);

    public static Task<T> UnpackAsync<T>(Stream stream) =>
        stream.IsNullOrEmpty()
            ? Task.FromResult((T)typeof(T).GetDefaultValue())
            : MsgPackSerializer.UnpackAsync<T>(stream);
}