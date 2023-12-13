using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using Caliburn.Micro;
using System.IO;
using System.Reflection;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class AddItemViewModel<T> : Screen, IHandle<IEditRowMessage>
    {
        public BindableCollection<object> ChosenSlot { get; set; } = new BindableCollection<object>();
        public AddItemViewModel(
            IEventAggregator eventAggregator,
            IUnitOfWork unitOfWork)
        {
            _eventAggregator = eventAggregator;
            _unitOfWork = unitOfWork;
            eventAggregator.SubscribeOnUIThread(this);
            string assemblyPath =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "148103_148214.PizzaPicker.DAO.dll");
            Assembly assembly;
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var existingAssembly = loadedAssemblies.FirstOrDefault(a =>
                a.GetName().Name.Equals("148103_148214.PizzaPicker.DAO", StringComparison.OrdinalIgnoreCase));
            if (existingAssembly != null)
            {
                assembly = existingAssembly;
            }
            else
            {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            _baseType = assembly.GetTypes()
    .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .FirstOrDefault();
            Reset();
        }

        public void SaveRow()
        {
            var record = ChosenSlot.First();
            if (typeof(T) == typeof(IPizza) || typeof(T).GetInterfaces().Contains(typeof(IPizza)))
            {
                _unitOfWork.EditPizza((IPizza)record);
            }
            else if (typeof(T) == typeof(IPizzeria) || typeof(T).GetInterfaces().Contains(typeof(IPizzeria)))
            {
                _unitOfWork.EditPizzeria((IPizzeria)record);
            }
            Reset();
            _eventAggregator.PublishOnUIThreadAsync(new DisplayRefreshRequested() { TargetType = typeof(T) });
        }

        public void AddRow()
        {
            var record = ChosenSlot.First();
            if (typeof(T) == typeof(IPizza) || typeof(T).GetInterfaces().Contains(typeof(IPizza)))
            {
                _unitOfWork.AddPizza((IPizza)record);
            }
            else if (typeof(T) == typeof(IPizzeria) || typeof(T).GetInterfaces().Contains(typeof(IPizzeria)))
            {
                _unitOfWork.AddPizzeria((IPizzeria)record);
            }
            Reset();
            _eventAggregator.PublishOnUIThreadAsync(new DisplayRefreshRequested() { TargetType = typeof(T) });
        }

        public Task HandleAsync(IEditRowMessage message, CancellationToken cancellationToken)
        {
            if (!message.Type.GetInterfaces().Contains(typeof(T)))
                return Task.CompletedTask;
            ChosenSlot.Clear();
            var obj = message.Object.GetType().GetMethod("DeepCopy").Invoke(message.Object, null);
            ChosenSlot.Add(obj);
            return Task.CompletedTask;
        }

        private void Reset()
        {
            ChosenSlot.Clear();
            ChosenSlot.Add(Activator.CreateInstance(_baseType));
        }

        private readonly Type _baseType;
        private IEventAggregator _eventAggregator;
        private IUnitOfWork _unitOfWork;
    }
}
