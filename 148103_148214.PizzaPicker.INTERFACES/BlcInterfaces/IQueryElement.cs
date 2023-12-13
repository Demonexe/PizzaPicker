namespace _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces
{
    public interface IQueryElement
    {
        string ColumnName { get; set; }
        string CompareOperation { get; set; }
        object Value { get; set; }
        string LogicOperator { get; set; }
    }
}
