using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;
using Caliburn.Micro;
using System.Windows;

namespace _148103_148214.PizzaPicker.ViewModels
{
    public class SingleQueryViewModel<T> : Screen where T : class
    {
        public List<string> Columns { get; set; }
        public Visibility ComboBoxVisibility { get; set; } = Visibility.Collapsed;
        public Visibility TextBoxVisibility { get; set; } = Visibility.Visible;
        public List<string> ComboBoxValues { get; set; } = new List<string>();
        public string SelectedColumn
        {
            get => _selectedColumn;
            set
            {
                _selectedColumn = value;
                var type = typeof(T).GetProperties().First(p => p.Name == _selectedColumn).PropertyType;
                if (Nullable.GetUnderlyingType(type) != null)
                {
                    type = Nullable.GetUnderlyingType(type);
                }
                CompareOperations = OperationsGenerator.GetOperationsForType(type);
                if(type.IsEnum)
                {
                    ComboBoxValues.Clear();
                    foreach(var val in type.GetEnumValues())
                    {
                        ComboBoxValues.Add(val.ToString());
                    }
                    QueryValue = ComboBoxValues.First();
                    NotifyOfPropertyChange(nameof(QueryValue));
                    ComboBoxVisibility = Visibility.Visible;
                    TextBoxVisibility = Visibility.Collapsed;
                }
                else
                {
                    ComboBoxVisibility = Visibility.Collapsed;
                    TextBoxVisibility = Visibility.Visible;
                }
                NotifyOfPropertyChange(nameof(ComboBoxVisibility));
                NotifyOfPropertyChange(nameof(TextBoxVisibility));
                NotifyOfPropertyChange(nameof(CompareOperations));
                SelectedCompareOperation = CompareOperations.First();
                NotifyOfPropertyChange(nameof(SelectedCompareOperation));
            }
        }
        public List<string> CompareOperations { get; set; }
        public string SelectedCompareOperation { get; set; }
        public List<string> LogicOperations { get; set; } = new List<string>() { "And", "Or" };
        public string SelectedLogicOperator { get; set; }
        public string QueryValue { get; set; }
        public SingleQueryViewModel(QueryViewModel<T> model)
        {
            _model = model;
            Init();
        }

        public IQueryElement ReadQuery()
        {
            object obj;
            var type = typeof(T).GetProperties().First(p => p.Name == SelectedColumn).PropertyType;
            if (Nullable.GetUnderlyingType(type) != null)
            {
                type = Nullable.GetUnderlyingType(type);
            }
            try
            {
                if(type.IsEnum)
                {
                    obj = Enum.Parse(type,QueryValue);
                }
                else
                {
                    obj = Convert.ChangeType(QueryValue, type);
                }
            }
            catch(Exception e)
            {
                return null;
            }
            return new QueryElement()
            {
                ColumnName = SelectedColumn,
                CompareOperation = SelectedCompareOperation,
                LogicOperator = SelectedLogicOperator,
                Value = obj
            };
        }

        public void Delete()
        {
            _model.Delete(this);
        }

        private QueryViewModel<T> _model;
        private string _selectedColumn;

        private void Init()
        {
            Columns = typeof(T).GetProperties().Select(p => p.Name).ToList();
            SelectedColumn = Columns.First();
            var type = typeof(T).GetProperties().First(p => p.Name == SelectedColumn).PropertyType;
            if (Nullable.GetUnderlyingType(type) != null)
            {
                type = Nullable.GetUnderlyingType(type);
            }
            if (type.IsEnum)
            {
                ComboBoxVisibility = Visibility.Visible;
                TextBoxVisibility = Visibility.Collapsed;
            }
            CompareOperations = OperationsGenerator.GetOperationsForType(type);
            SelectedCompareOperation = CompareOperations.First();

        }
    }
}
