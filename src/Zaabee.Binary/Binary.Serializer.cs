namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    [ThreadStatic] private static BinaryFormatter? _binaryFormatter;
}