using _148103_148214.PizzaPicker.Commands;
using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using _148103_148214.PizzaPicker.Services;
using Caliburn.Micro;
using System.Windows.Input;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class DataDisplayViewModel<T>
        : Screen, IHandle<IDisplayRefreshRequested> where T : class
    {
        public object SelectedItem { get; set; }
        public BindableCollection<object> Data { get; set; }
            = new BindableCollection<object>();
        public BindableCollection<int> PageSizes { get; set; }
            = new BindableCollection<int> { 5, 10, 15, 20, 25 };

        public int SelectedPagingSize
        {
            get => _selectedPagingSize;
            set
            {
                _selectedPagingSize = value;
                DataReloadRequested();
            }
        }
        public ICommand EditRow { get; set; }
        public ICommand DeleteRow { get; set; }

        public bool CanDecreasePage => _currentPage > 0;
        public bool CanIncreasePage { get; set; }

        public DataDisplayViewModel(
            IEventAggregator eventAggregator,
            IUnitOfWork dbContext,
            IEnumerable<ICommand> commands)
        {
            _dbContext = dbContext;
            eventAggregator.SubscribeOnUIThread(this);
            EditRow = commands.FirstOrDefault(c => c.GetType() == typeof(EditRowCommand));
            DeleteRow = commands.FirstOrDefault(c => c.GetType() == typeof(DeleteRowCommand));
            CanIncreasePage = true;
            DataReloadRequested();
        }

        public void DecreasePage()
        {
            _currentPage -= 1;
            DataReloadRequested();
            NotifyOfPropertyChange(nameof(CanDecreasePage));
        }

        public void IncreasePage()
        {
            _currentPage += 1;
            DataReloadRequested();
            NotifyOfPropertyChange(nameof(CanDecreasePage));
        }

        public Task HandleAsync(IDisplayRefreshRequested message, CancellationToken cancellationToken)
        {
            if (message.TargetType != typeof(T))
                return Task.CompletedTask;
            if (message.Queries == null || !message.Queries.Any())
            {
                _lambda = null;
                DataReloadRequested();
                return Task.CompletedTask;
            }
            var builder = new QueryBuilder<T>();
            var list = message.Queries.ToList();
            IQueryElement lastElem = null;
            foreach (var elem in list)
            {
                if (elem == null)
                    continue;
                builder = builder.OnProperty(elem.ColumnName)
                    .AddValue(elem.Value)
                    .AddOperation(OperationsGenerator.StringToEnum(elem.CompareOperation));
                if (lastElem != null)
                {
                    builder = builder.AddOperation(OperationsGenerator.StringToEnum(lastElem.LogicOperator));
                }
                lastElem = elem;
            }
            /*if (list.Count > 1 && lastElem != null)
            {
                builder = builder.AddOperation(lastElem.LogicOperator);
            }*/
            _lambda = builder.Build();
            DataReloadRequested();
            return Task.CompletedTask;
        }

        private void DataReloadRequested()
        {
            Data.Clear();
            if (typeof(T) == typeof(IPizza) || typeof(T).GetInterfaces().Contains(typeof(IPizza)))
            {
                var displayedData = _dbContext.GetPizzas((Func<IPizza, bool>)_lambda, _currentPage, _selectedPagingSize);
                Data.AddRange(displayedData);
                CanIncreasePage = !(displayedData.Count() < _selectedPagingSize);
                NotifyOfPropertyChange(nameof(CanIncreasePage));
            }
            if (typeof(T) == typeof(IPizzeria) || typeof(T).GetInterfaces().Contains(typeof(IPizzeria)))
            {
                var displayedData = _dbContext.GetPizzerias((Func<IPizzeria, bool>)_lambda, _currentPage, _selectedPagingSize);
                Data.AddRange(displayedData);
                CanIncreasePage = !(displayedData.Count() < _selectedPagingSize);
                NotifyOfPropertyChange(nameof(CanIncreasePage));
            }

        }

        private int _selectedPagingSize = 5;
        private int _currentPage = 0;
        private Func<T, bool> _lambda;
        private readonly IUnitOfWork _dbContext;
    }
}
