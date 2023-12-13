namespace _148103_148214.PizzaPicker.WebApp.Models
{
    public class PagingModel
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int RecordCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)RecordCount / PageSize);

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
    }
}
