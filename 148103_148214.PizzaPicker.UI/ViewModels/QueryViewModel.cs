using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;
using Caliburn.Micro;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class QueryViewModel<T> : Screen where T : class
    {
        public BindableCollection<SingleQueryViewModel<T>> Queries { get; set; } = new BindableCollection<SingleQueryViewModel<T>>();
        public QueryViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddQuery();
        }

        public void AddQuery()
        {
            Queries.Add(new SingleQueryViewModel<T>(this));
        }

        public void ExecuteQuery()
        {
            var queries = ReadData();
            if (queries == null)
                return;

            _eventAggregator.PublishOnUIThreadAsync(new DisplayRefreshRequested()
            {
                Queries = queries,
                TargetType = typeof(T) 
            });
        }

        public IEnumerable<IQueryElement> ReadData()
        {
            List<IQueryElement> data = new List<IQueryElement>();
            Queries.ToList().ForEach(q => data.Add(q.ReadQuery()));
            return data;
        }

        public void ClearQuery()
        {
            Queries.Clear();
            AddQuery();
            _eventAggregator.PublishOnUIThreadAsync(new DisplayRefreshRequested() { TargetType = typeof(T) });
        }

        public void Delete(SingleQueryViewModel<T> queryViewModel)
        {
            Queries.Remove(queryViewModel);
        }

        private IEventAggregator _eventAggregator;
    }
}
