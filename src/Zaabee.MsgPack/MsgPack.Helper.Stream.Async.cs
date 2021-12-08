namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    public static async Task<MemoryStream> PackAsync<TValue>(TValue value) =>
        value is null
            ? new MemoryStream()
            : await MsgPackSerializer.PackAsync(value);

    public static async Task PackAsync<TValue>(TValue value, Stream? stream)
    {
        if (value is not null && stream is not null)
            await MsgPackSerializer.PackAsync(value, stream);
    }

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : await MsgPackSerializer.UnpackAsync<TValue>(stream!);
}