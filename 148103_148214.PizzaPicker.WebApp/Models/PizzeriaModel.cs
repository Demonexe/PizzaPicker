using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.WebApp.Models
{
    public class PizzeriaModel : IPizzeria
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SupportedPostalCodes { get; set; }

        public IPizzeria DeepCopy()
        {
            return new PizzeriaModel() { Id = Id, Name = Name, Address =Address, SupportedPostalCodes =SupportedPostalCodes};
            
        }
    }
}
