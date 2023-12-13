namespace _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces
{
    public interface IPizzeria
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string SupportedPostalCodes { get; set; }

        IPizzeria DeepCopy();
    }
}
