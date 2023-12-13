using Caliburn.Micro;
using System.Windows.Input;

namespace _148103_148214.PizzaPicker.Commands
{
    public class EditRowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public EditRowCommand(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _eventAggregator.PublishOnUIThreadAsync(new EditRowMessage()
            { Type = parameter.GetType(), Object = parameter }) ;

        }

        private IEventAggregator _eventAggregator;
    }
}
