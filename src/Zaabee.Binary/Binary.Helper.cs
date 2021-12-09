namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    [ThreadStatic] private static BinaryFormatter? _binaryFormatter;
}