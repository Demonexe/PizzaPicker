using _148103_148214.PizzaPicker.CORE;

namespace _148103_148214.PizzaPicker.WebApp.Models
{
    public class PizzaFilterModel
    {
        public int? LowerIdBound { get; set; }
        public int? UpperIdBound { get; set; }
        public string? Name { get; set; }
        public string? Ingridients { get; set; }
        public DoughType? Dough { get; set; }
        public int? LowerPizzeriaIdBound { get; set; }
        public int? UpperPizzeriaIdBound { get; set; }
    }
}
