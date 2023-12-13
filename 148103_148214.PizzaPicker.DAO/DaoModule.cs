using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace _148103_148214.PizzaPicker.DAO
{
    public class DaoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = new PizzaPickerContext();
                return new UnitOfWork(context);
            }).As<IUnitOfWork>()
                .InstancePerLifetimeScope();

        }
    }
}
