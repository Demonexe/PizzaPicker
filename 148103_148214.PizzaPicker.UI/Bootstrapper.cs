using _148103_148214.PizzaPicker.ViewModels;
using Autofac;
using Caliburn.Micro;
using System.IO;
using System.Reflection;
using System.Windows;

namespace _148103_148214.PizzaPicker
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var daoPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "148103_148214.PizzaPicker.DAO\\bin\\Debug\\net6.0\\148103_148214.PizzaPicker.DAO.dll"); 
            var daoAssembly = Assembly.LoadFrom(daoPath);

            var builder = new ContainerBuilder();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            //Find Autofac modules in
            builder.RegisterAssemblyModules(GetType().Assembly); // this assembly
            builder.RegisterAssemblyModules(daoAssembly);// DaoAssembly
            _container = builder.Build();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var enumTypes = typeof(IEnumerable<>).MakeGenericType(service);
            return (IEnumerable<object>)_container.Resolve(enumTypes);
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync(typeof(PizzaPickerMainViewModel));
        }

        protected override object GetInstance(Type service, string key)
        {
            return key == null ? _container.Resolve(service) : _container.ResolveKeyed(key, service);
        }

        protected override void BuildUp(object instance)
        {
            _container.InjectProperties(instance);
        }

        private static IContainer _container;
    }
}
