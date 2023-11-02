namespace Zaabee.Serializer.Types.UnitTest.Models;

public static class Comparer
{
    public static bool Compare(DateTimeModel? first, DateTimeModel? second) =>
        first is not null
        && second is not null
        && first.DateTime == second.DateTime;

    public static bool Compare(EnumModel? first, EnumModel? second) =>
        first is not null
        && second is not null
        && first.Color == second.Color;

    public static bool Compare(GuidModel? first, GuidModel? second) =>
        first is not null
        && second is not null
        && first.Id == second.Id;
}