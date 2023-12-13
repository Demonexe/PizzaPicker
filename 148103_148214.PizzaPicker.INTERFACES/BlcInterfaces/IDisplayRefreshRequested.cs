namespace _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces
{
    public interface IDisplayRefreshRequested
    {
        IEnumerable<IQueryElement> Queries { get; set; }
        Type TargetType { get; set; }
    }
}
