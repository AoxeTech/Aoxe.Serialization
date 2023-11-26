namespace Zaabee.Serializer.Types.UnitTest.Models;

#if !NET48
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class DateTimeModel
{
    [Key(0)]
    [ProtoMember(1)]
    [Index(0)]
    public virtual DateTime DateTime { get; set; } = DateTime.UtcNow;

    public static DateTimeModel Instance(bool isUtc = true)
    {
        var dateTimeModel = new DateTimeModel { DateTime = isUtc ? DateTime.UtcNow : DateTime.Now };
        return dateTimeModel;
    }
}
