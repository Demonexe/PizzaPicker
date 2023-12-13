using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;

namespace _148103_148214.PizzaPicker
{
    public class DisplayRefreshRequested : IDisplayRefreshRequested
    {
        public IEnumerable<IQueryElement> Queries { get; set; }
        public Type TargetType { get; set; }
    }
}
