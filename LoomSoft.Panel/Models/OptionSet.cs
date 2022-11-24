namespace LoomSoft.Panel.Models
{
    public class OptionSet : BaseEntity
    {
        public string Name { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int OptionValue { get; set; }
        public string OptionString { get; set; }
        public string? OptionStringDetail { get; set; }
    }
}
