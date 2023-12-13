using Caliburn.Micro;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class PizzaPickerMainViewModel : Conductor<Screen>.Collection.OneActive
    {
        public PizzaPickerMainViewModel(
            TableViewModel<IPizza> pizzaViewModel,
            TableViewModel<IPizzeria> pizzeriaViewModel)
        {
            Items.Add(pizzaViewModel); 
            Items.Add(pizzeriaViewModel);
        }
    }
}
