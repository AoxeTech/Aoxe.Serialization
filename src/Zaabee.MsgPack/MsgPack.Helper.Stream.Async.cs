namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    public static Task<MemoryStream> PackAsync<TValue>(TValue value) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : MsgPackSerializer.PackAsync(value);

    public static Task PackAsync<TValue>(TValue value, Stream? stream) =>
        value is null || stream is null
            ? Task.CompletedTask
            : MsgPackSerializer.PackAsync(value, stream);

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : await MsgPackSerializer.UnpackAsync<TValue>(stream!);
}