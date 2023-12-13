using _148103_148214.PizzaPicker.CORE;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using _148103_148214.PizzaPicker.Services;
using _148103_148214.PizzaPicker.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _148103_148214.PizzaPicker.WebApp.Controllers
{
    public class PizzasController : Controller
    {
        public PizzasController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PizzaModel newPizza)
        {
            _context.AddPizza(newPizza);
            return RedirectToAction("ViewCombined");
        }

        [HttpGet]
        public IActionResult ViewCombined()
        {
            var jsonFilter = HttpContext.Session.GetString("pizzasFilter");
            var filterModel = string.IsNullOrEmpty(jsonFilter)
                ? new PizzaFilterModel()
                : JsonSerializer.Deserialize<PizzaFilterModel>(jsonFilter);
            var lambda = CompileFilters(filterModel);
            var allPizzas = _context.GetPizzas(lambda, -1, -1).ToList();

            var jsonPaging = HttpContext.Session.GetString("pizzasPaging");
            var pagingModel = string.IsNullOrEmpty(jsonPaging)
                ? new PagingModel()
                : JsonSerializer.Deserialize<PagingModel>(jsonPaging);
            pagingModel.RecordCount = allPizzas.Count();

            var complexModel = new PizzaComplexModel()
            {
                Pizzas = _context.GetPizzas(lambda, pagingModel.CurrentPage - 1, pagingModel.PageSize).ToList(),
                Filter = filterModel,
                Paging = pagingModel
            };
            return View(complexModel);
        }

        [HttpPost]
        public IActionResult ViewCombinedPaging(PagingModel model)
        {
            HttpContext.Session.LoadAsync().Wait();
            HttpContext.Session.SetString("pizzasPaging", JsonSerializer.Serialize(model));
            return RedirectToAction("ViewCombined");
        }

        [HttpPost]
        public IActionResult ViewCombinedFilter(PizzaFilterModel model)
        {
            HttpContext.Session.LoadAsync().Wait();
            HttpContext.Session.SetString("pizzasFilter", JsonSerializer.Serialize(model));
            return RedirectToAction("ViewCombined");
        }
        public ActionResult FilterPizzerias(PizzeriaFilterModel filter)
        {
            var filteredPizzerias = _context.GetPizzerias(null, 0, 100);
            return View("ViewCombined", filteredPizzerias);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pizza = _context.GetPizzas((p => p.Id == id), 0, 1).First();
            if(pizza == null)
                return RedirectToAction("ViewCombined");
            var pizzaModel = new PizzaModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Ingridients = pizza.Ingridients,
                Dough = pizza.Dough,
                PizzeriaId = pizza.PizzeriaId
            };
            return await Task.Run(()=>View("ViewCombined", pizzaModel));
        }

        [HttpPost]
        public IActionResult Edit(PizzaModel newPizza)
        {
            _context.EditPizza(newPizza);
            return RedirectToAction("ViewCombined");
        }

        public IActionResult Delete(int id)
        {
            _context.DeletePizza(id);
            return RedirectToAction("ViewCombined");
        }

        private Func<IPizza, bool> CompileFilters(PizzaFilterModel model)
        {
            bool set = false;
            var builder = new QueryBuilder<IPizza>();

            if (model.LowerIdBound != null)
            {
                builder.OnProperty("Id")
                    .AddValue(model.LowerIdBound)
                    .AddOperation(QueryBuilderOperation.Greater);
                if (model.UpperIdBound != null)
                {
                    builder.OnProperty("Id")
                        .AddValue(model.UpperIdBound)
                        .AddOperation(QueryBuilderOperation.Less)
                        .AddOperation(QueryBuilderOperation.And);
                }
                set = true;
            }
            else if (model.UpperIdBound != null)
            {
                builder.OnProperty("Id")
                    .AddValue(model.UpperIdBound)
                    .AddOperation(QueryBuilderOperation.Less);
                set = true;
            }
            if (!string.IsNullOrEmpty(model.Name))
            {

                builder.OnProperty("Name")
                    .AddValue(model.Name)
                    .AddOperation(QueryBuilderOperation.Contains);
                if (set)
                    builder.AddOperation(QueryBuilderOperation.Or);
                set = true;
            }
            if (!string.IsNullOrEmpty(model.Ingridients))
            {

                builder.OnProperty("Ingridients")
                    .AddValue(model.Ingridients)
                    .AddOperation(QueryBuilderOperation.Contains);
                if (set)
                    builder.AddOperation(QueryBuilderOperation.Or);
                set = true;
            }
            if (model.Dough != null)
            {
                builder.OnProperty("Dough")
                    .AddValue(model.Dough)
                    .AddOperation(QueryBuilderOperation.Equal);
                if (set)
                    builder.AddOperation(QueryBuilderOperation.Or);
                set = true;
            }
            var secondBuilder = new QueryBuilder<IPizza>();
            if (model.LowerPizzeriaIdBound != null)
            {
                secondBuilder.OnProperty("PizzeriaId")
                    .AddValue(model.LowerPizzeriaIdBound)
                    .AddOperation(QueryBuilderOperation.Greater);
                if (model.UpperPizzeriaIdBound != null)
                {
                    secondBuilder.OnProperty("PizzeriaId")
                        .AddValue(model.UpperPizzeriaIdBound)
                        .AddOperation(QueryBuilderOperation.Less)
                        .AddOperation(QueryBuilderOperation.And);
                }
            }
            else if (model.UpperPizzeriaIdBound != null)
            {
                secondBuilder.OnProperty("PizzeriaId")
                    .AddValue(model.UpperPizzeriaIdBound)
                    .AddOperation(QueryBuilderOperation.Less);
            }
            if(secondBuilder.GetExpression() != null)
            {
                builder.AddExternalExpression(secondBuilder.GetExpression(), QueryBuilderOperation.Or);
            }
            return builder.Build();
        }

        private readonly IUnitOfWork _context;
    }
}
