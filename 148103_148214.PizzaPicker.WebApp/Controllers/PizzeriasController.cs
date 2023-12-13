using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using _148103_148214.PizzaPicker.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using _148103_148214.PizzaPicker.Services;
using _148103_148214.PizzaPicker.CORE;
using System.Text.Json;

namespace _148103_148214.PizzaPicker.WebApp.Controllers
{
    public class PizzeriasController : Controller
    {
        public PizzeriasController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PizzeriaModel newPizzeria)
        {
            _context.AddPizzeria(newPizzeria);
            return RedirectToAction("ViewCombined");
        }

        [HttpGet]
        public IActionResult ViewCombined()
        {
            var jsonFilter = HttpContext.Session.GetString("pizzeriasFilter");
            var filterModel = string.IsNullOrEmpty(jsonFilter)
                ? new PizzeriaFilterModel()
                : JsonSerializer.Deserialize<PizzeriaFilterModel>(jsonFilter);
            var lambda = CompileFilters(filterModel);
            var allPizzerias = _context.GetPizzerias(lambda, -1, -1).ToList();

            var jsonPaging = HttpContext.Session.GetString("pizzeriasPaging");
            var pagingModel = string.IsNullOrEmpty(jsonPaging) 
                ? new PagingModel() 
                : JsonSerializer.Deserialize<PagingModel>(jsonPaging);
            pagingModel.RecordCount = allPizzerias.Count();
           
            var complexModel = new PizzeriaComplexModel()
            {
                Pizzerias = _context.GetPizzerias(lambda,pagingModel.CurrentPage-1, pagingModel.PageSize).ToList(),
                Filter = filterModel,
                Paging = pagingModel
            };
            return View(complexModel);
        }

        [HttpPost]
        public IActionResult ViewCombinedPaging(PagingModel model)
        {
            HttpContext.Session.LoadAsync().Wait();
            HttpContext.Session.SetString("pizzeriasPaging", JsonSerializer.Serialize(model));
            return RedirectToAction("ViewCombined");
        }

        [HttpPost]
        public IActionResult ViewCombinedFilter(PizzeriaFilterModel model)
        {
            HttpContext.Session.LoadAsync().Wait();
            HttpContext.Session.SetString("pizzeriasFilter", JsonSerializer.Serialize(model));
            return RedirectToAction("ViewCombined");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pizzeria = _context.GetPizzerias((p => p.Id == id), 0, 1).First();
            if (pizzeria == null)
                return RedirectToAction("ViewCombined");
            var pizzeriaModel = new PizzeriaModel()
            {
                Id = pizzeria.Id,
                Name = pizzeria.Name,
                Address = pizzeria.Address,
                SupportedPostalCodes = pizzeria.SupportedPostalCodes
            };
            return await Task.Run(() => View("Edit", pizzeriaModel));
        }

        [HttpPost]
        public IActionResult Edit(PizzeriaModel newPizzeria)
        {
            _context.EditPizzeria(newPizzeria);
            return RedirectToAction("ViewCombined");
        }

        public IActionResult Delete(int id)
        {
            _context.DeletePizzeria(id);
            return RedirectToAction("ViewCombined");
        }

        private Func<IPizzeria,bool> CompileFilters(PizzeriaFilterModel model)
        {
            bool set = false;
            var builder = new QueryBuilder<IPizzeria>();

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
            if (!string.IsNullOrEmpty(model.Address))
            {

                builder.OnProperty("Address")
                    .AddValue(model.Address)
                    .AddOperation(QueryBuilderOperation.Contains);
                if (set)
                    builder.AddOperation(QueryBuilderOperation.Or);
                set = true;
            }
            if (!string.IsNullOrEmpty(model.SupportedPostalCodes))
            {
                builder.OnProperty("SupportedPostalCodes")
                    .AddValue(model.SupportedPostalCodes)
                    .AddOperation(QueryBuilderOperation.Contains);
                if (set)
                    builder.AddOperation(QueryBuilderOperation.Or);
                set = true;
            }

            return builder.Build();
        }

        private readonly IUnitOfWork _context;
    }
}
