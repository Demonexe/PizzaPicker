using _148103_148214.PizzaPicker.CORE;

namespace _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces
{
    public interface IPizza
    {
        int Id { get; set; }
        string Name { get; set; }
        string Ingridients { get; set; }
        DoughType Dough { get; set; }
        int PizzeriaId { get; set; }

        IPizza DeepCopy();
    }
}
