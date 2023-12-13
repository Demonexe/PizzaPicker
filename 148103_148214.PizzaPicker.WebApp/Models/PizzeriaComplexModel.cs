using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.WebApp.Models
{
    public class PizzeriaComplexModel
    {
        public PagingModel Paging { get; set; }
        public PizzeriaFilterModel Filter { get; set; }
        public List<IPizzeria> Pizzerias { get; set; }
    }
}
