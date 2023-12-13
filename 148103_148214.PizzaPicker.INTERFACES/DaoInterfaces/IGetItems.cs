namespace _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces
{
    public interface IGetItems
    {
        IEnumerable<IPizza> GetPizzas(Func<IPizza, bool> lambda);
        IEnumerable<IPizzeria> GetPizzerias(Func<IPizzeria, bool> lambda);
    }
}
