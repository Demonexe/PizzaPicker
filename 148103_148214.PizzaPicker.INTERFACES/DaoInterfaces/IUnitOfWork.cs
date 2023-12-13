using Microsoft.EntityFrameworkCore;

namespace _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces
{
    public interface IUnitOfWork
    {
        void AddPizza(IPizza newPizza);
        void AddPizzeria(IPizzeria newPizzeria);
        void EditPizzeria(IPizzeria newPizzeria);
        void EditPizza(IPizza newPizza);
        IEnumerable<IPizza> GetPizzas(Func<IPizza, bool> lambda, int currentPage, int recordPerPage);
        IEnumerable<IPizzeria> GetPizzerias(Func<IPizzeria, bool> lambda, int currentPage, int recordPerPage);
        void DeletePizza(int pizzaId);
        void DeletePizzeria(int pizzeriaId);
    }
}
