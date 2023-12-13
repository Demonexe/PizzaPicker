using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using Caliburn.Micro;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class TableViewModel<T> 
        : Conductor<Screen>.Collection.AllActive where T : class
    {
        public TableViewModel(
            DataDisplayViewModel<T> dataDisplayViewModel,
            QueryViewModel<T> queryViewModel,
            AddItemViewModel<T> addItemViewModel)
        {
            Items.Add(queryViewModel);
            Items.Add(dataDisplayViewModel);
            Items.Add(addItemViewModel);
            DisplayName = $"Tabela '{typeof(T).Name.Substring(1)}'";
        }
    }
}
