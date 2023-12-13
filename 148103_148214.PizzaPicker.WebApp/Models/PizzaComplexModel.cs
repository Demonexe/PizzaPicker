using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.WebApp.Models
{
    public class PizzaComplexModel
    {
        public List<IPizza> Pizzas { get; set; }
        public PizzaFilterModel Filter { get; set; }
        public PagingModel Paging { get; set; }
    }
}
