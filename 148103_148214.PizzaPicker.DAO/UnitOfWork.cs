using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using System.Linq;

namespace _148103_148214.PizzaPicker.DAO
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(PizzaPickerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddPizza(IPizza newPizza)
        {
            var fkExists = _dbContext.Pizzas.Any(p => p.Id == newPizza.PizzeriaId);
            if (fkExists)
            {
                var pizza = new Pizza()
                {
                    Id = 0,
                    Name = newPizza.Name,
                    Ingridients = newPizza.Ingridients,
                    PizzeriaId = newPizza.PizzeriaId,
                    Dough = newPizza.Dough
                };
                _dbContext.Pizzas.Add(pizza);
                _dbContext.SaveChanges();
            }
        }

        public void AddPizzeria(IPizzeria newPizzeria)
        {
            var pizzeria = new Pizzeria()
            {
                Id = 0,
                Name = newPizzeria.Name,
                Address = newPizzeria.Address,
                SupportedPostalCodes = newPizzeria.SupportedPostalCodes
            };
            _dbContext.Pizzerias.Add(pizzeria);
            _dbContext.SaveChanges();
        }

        public void EditPizzeria(IPizzeria newPizzeria)
        {
            var record = _dbContext.Pizzerias.Find(newPizzeria.Id);
            if (record != null)
            {
                record.Name = newPizzeria.Name;
                record.Address = newPizzeria.Address;
                record.SupportedPostalCodes = newPizzeria.SupportedPostalCodes;
                _dbContext.SaveChanges();
            }
        }

        public void EditPizza(IPizza newPizza)
        {
            var record = _dbContext.Pizzas.Find(newPizza.Id);
            var pizzeriaFk = _dbContext.Pizzerias.Find(newPizza.PizzeriaId);
            if (record != null && pizzeriaFk != null)
            {
                record.Name = newPizza.Name;
                record.Dough = newPizza.Dough;
                record.Ingridients = newPizza.Ingridients;
                record.PizzeriaId = newPizza.PizzeriaId;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<IPizza> GetPizzas(Func<IPizza, bool> lambda, int currentPage, int recordPerPage)
        {
            if (currentPage == -1)
            {
                if (lambda != null)
                    return _dbContext.Pizzas.Where(lambda).ToList();
                return _dbContext.Pizzas.ToList();
            }
            if (lambda == null)
            {
                return _dbContext.Pizzas.ToList()
                    .Skip(currentPage * recordPerPage)
                    .Take(recordPerPage);
            }
            return _dbContext.Pizzas.Where(lambda)
                    .Skip(currentPage * recordPerPage)
                    .Take(recordPerPage);
        }

        public IEnumerable<IPizzeria> GetPizzerias(Func<IPizzeria, bool> lambda, int currentPage, int recordPerPage)
        {
            if (currentPage == -1)
            {
                if (lambda != null)
                    return _dbContext.Pizzerias.Where(lambda).ToList();
                return _dbContext.Pizzerias.ToList();
            }
                
            if (lambda == null)
            {
                return _dbContext.Pizzerias.ToList()
                    .Skip(currentPage*recordPerPage)
                    .Take(recordPerPage);
            }
            return _dbContext.Pizzerias.Where(lambda)
                    .Skip(currentPage * recordPerPage)
                    .Take(recordPerPage);
        }

        public void DeletePizza(int pizzaId)
        {
            var pizzaToDelete = _dbContext.Pizzas.Find(pizzaId);
            if (pizzaToDelete == null)
                return;
            _dbContext.Pizzas.Remove(pizzaToDelete);
            _dbContext.SaveChanges();
        }

        public void DeletePizzeria(int pizzeriaId)
        {
            var pizzeriaToDelete = _dbContext.Pizzerias.Find(pizzeriaId);
            if (pizzeriaToDelete == null)
                return;
            _dbContext.Pizzerias.Remove(pizzeriaToDelete);
            _dbContext.SaveChanges();
        }

        private readonly PizzaPickerContext _dbContext;
    }
}
