namespace ExcelImporter.Editor.Processing
{
    public class ExcelColumn
    {
        public string Name { get; }
        public ColumnValueType Type { get; }

        public ExcelColumn(string name, ColumnValueType type)
        {
            Name = name;
            Type = type;
        }
    }
}
