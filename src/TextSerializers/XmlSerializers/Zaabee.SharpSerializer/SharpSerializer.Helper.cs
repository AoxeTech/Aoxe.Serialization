namespace Zaabee.SharpSerializer;

public static partial class SharpSerializerHelper
{
    private static readonly SharpSerializerXmlSettings DefaultSettings =
        new()
        {
            IncludeAssemblyVersionInTypeName = true,
            IncludeCultureInTypeName = true,
            IncludePublicKeyTokenInTypeName = true
        };
}
