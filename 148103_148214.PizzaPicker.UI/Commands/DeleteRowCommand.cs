using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using Caliburn.Micro;
using System.Windows.Input;

namespace _148103_148214.PizzaPicker.Commands
{
    public class DeleteRowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public DeleteRowCommand(
            IEventAggregator eventAggregator,
            IUnitOfWork deleteItem)
        {
            _eventAggregator = eventAggregator;
            _deleteItem = deleteItem;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Type type = null;
            var interfaces = parameter.GetType().GetInterfaces();
            if (interfaces.Contains(typeof(IPizza)))
            {
                type = typeof(IPizza);
                var id = (int)parameter.GetType().GetProperty("Id").GetValue(parameter);
                _deleteItem.DeletePizza(id);
            }
            else if (interfaces.Contains(typeof(IPizzeria)))
            {
                type = typeof(IPizzeria);
                var id = (int)parameter.GetType().GetProperty("Id").GetValue(parameter);
                _deleteItem.DeletePizzeria(id);
            }

            _eventAggregator.PublishOnUIThreadAsync(new DisplayRefreshRequested() { TargetType = type});
        }

        private readonly IEventAggregator _eventAggregator;
        private readonly IUnitOfWork _deleteItem;
    }
}
