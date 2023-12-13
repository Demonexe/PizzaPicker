using _148103_148214.PizzaPicker.INTERFACES.BlcInterfaces;

namespace _148103_148214.PizzaPicker
{
    public class EditRowMessage : IEditRowMessage
    {
        public object Object { get; set; }
        public Type Type { get; set; }
    }
}
