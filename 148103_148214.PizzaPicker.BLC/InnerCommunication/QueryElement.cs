using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;

namespace _148103_148214.PizzaPicker
{
    public class QueryElement : IQueryElement
    {
        public string ColumnName { get; set; }
        public string CompareOperation { get; set; }
        public object Value { get; set; }
        public string LogicOperator { get; set; }
    }
}
