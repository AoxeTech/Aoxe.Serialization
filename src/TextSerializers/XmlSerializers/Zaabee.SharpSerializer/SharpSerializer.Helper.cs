namespace Zaabee.SharpSerializer;

public static partial class SharpSerializerHelper
{
    private static SharpSerializerXmlSettings _defaultSettings =
        new()
        {
            IncludeAssemblyVersionInTypeName = true,
            IncludeCultureInTypeName = true,
            IncludePublicKeyTokenInTypeName = true
        };
}
