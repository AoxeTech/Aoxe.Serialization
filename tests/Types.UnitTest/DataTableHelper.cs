namespace Types.UnitTest;

public static class DataTableHelper
{
    public static void AssertEqual(DataTable? dt1, DataTable? dt2)
    {
        Assert.NotNull(dt1);
        Assert.NotNull(dt2);
        Assert.Equal(dt1.Columns.Count, dt2.Columns.Count);
        Assert.Equal(dt1.Rows.Count, dt2.Rows.Count);
        for (var i = 0; i < dt1.Columns.Count; i++)
        {
            Assert.Equal(dt1.Columns[i].ColumnName, dt2.Columns[i].ColumnName);
            // Assert.Equal(dt1.Columns[i].DataType, dt2.Columns[i].DataType);
        }

        for (var i = 0; i < dt1.Rows.Count; i++)
        {
            for (var j = 0; j < dt1.Columns.Count; j++)
            {
                Assert.Equal(dt1.Rows[i][j].ToString(), dt2.Rows[i][j].ToString());
            }
        }
    }
}