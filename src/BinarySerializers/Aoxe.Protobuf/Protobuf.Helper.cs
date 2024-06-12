namespace Aoxe.Protobuf;

public static partial class ProtobufHelper
{
    private static readonly Lazy<RuntimeTypeModel> Model =
        new(() =>
        {
            var typeModel = RuntimeTypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        });

    private static RuntimeTypeModel TypeModel => Model.Value;
}
