using _148103_148214.PizzaPicker.CORE;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.DAO
{
    public class Pizza : IPizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingridients { get; set; }
        public DoughType Dough { get; set; }
        public int PizzeriaId { get; set; }

        public IPizza DeepCopy()
        {
            return new Pizza()
            {
                Id= Id,
                Name = Name,
                Ingridients = Ingridients,
                Dough = Dough,
                PizzeriaId = PizzeriaId
            };
        }
    }
}
