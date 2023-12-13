using _148103_148214.PizzaPicker.Commands;
using _148103_148214.PizzaPicker.ViewModels;
using Autofac;
using Caliburn.Micro;
using System.Windows.Input;

namespace _148103_148214.PizzaPicker
{
    public class UiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>()
                .SingleInstance();
            builder.RegisterType<PizzaPickerMainViewModel>()
                .SingleInstance();
            builder.RegisterGeneric(typeof(TableViewModel<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DataDisplayViewModel<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(QueryViewModel<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AddItemViewModel<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<EditRowCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<DeleteRowCommand>()
               .As<ICommand>()
               .SingleInstance();
        }
    }
}
