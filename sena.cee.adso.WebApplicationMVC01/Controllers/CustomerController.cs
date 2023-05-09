using Microsoft.AspNetCore.Mvc;
using sena.cee.adso.WebApplicationMVC01.Data;
using sena.cee.adso.WebApplicationMVC01.Models;

namespace sena.cee.adso.WebApplicationMVC01.Controllers;

public class CustomerController : Controller
{
    private readonly ApplicationDbContext _context;
    
    //Inyección de dependencias por medio del constructor
    public CustomerController(ApplicationDbContext context)
    {
        this._context = context;
    }
    
    // GET : CustomerController
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Customer> colCustomers = _context.Customers;
        return View(colCustomers);
    }
    
    //GET: CustomerController/Details/5
    [HttpGet]
    public ActionResult Details(int id) //CustomerId
    {
        var customer = _context.Customers.Find(id);
        return View(customer);
    }
    
    //GET: CustomerController/Create
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }
    
    //POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer)
    {
         if (!ModelState.IsValid)
            {
                return View(customer);
            }

         //Validar si el objeto cliente(customer) ya existe en la DB
         var resultValidacionDb = Validar2(customer.FirstName, customer.LastName);

        //+
        if (resultValidacionDb)
        {
            ViewBag.ResultFail = "Usuario Duplicado, no se puede guardar en la base de datos";
            return View(customer);
        }

         //-

        _context.Customers.Add(customer);
        _context.SaveChanges();
        ViewBag.ResultOk = "¡Recorded added successfully!";
        return RedirectToAction("Index");
        
    }
    
    //GET: CustomerController/Edit/5
    [HttpGet]
    public ActionResult Edit(int id)
    {

        if (id == default(int) || id < 0)
        {
            return NotFound();
        }

        var customerfromdb = _context.Customers.Find(id);
        if (customerfromdb  == null)
        {
            return NotFound();
        }

        return View(customerfromdb);
    }
    
    //POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Customer customer)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                TempData["ResultOk"] = "¡Recorded updated successfully!";
            }

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return View();
        }
    }
    
    //GET: CustomerController/Delete/5
    [HttpGet]
    public ActionResult Delete(int id)
    {
        if (id == default(int) || id <0)
        {
            return NotFound();
        }

        var customerfromdb = _context.Customers.Find(id);
        if (customerfromdb == null)
        {
            return NotFound();
        }

        return View(customerfromdb);
    }
    
    //POST: CustomerController/Delete/5
    [HttpPost]
    public ActionResult Delete(int? id)
    {
        try
        {
            var customerfromdb = _context.Customers.Find(id);
            if (customerfromdb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerfromdb);
            _context.SaveChanges();
            TempData["ResultOk"] = "¡Recorded deleted successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return View();
        }
    }

    //Métodos Auxiliares para hacer validaciones

    private bool Validar (string firstName, string lastName)
    {
        bool flag = false;
        var resultdb = _context.Customers
            .Where(c => c.FirstName == firstName && c.LastName == lastName)
            .FirstOrDefault();

        if (resultdb != null)
        {
            flag = true;
        }
        return flag;
    }

    private bool Validar2(string firstName, string lastName)
    {
        var resultdb = _context.Customers.Any(c => c.FirstName == firstName && c.LastName == lastName);
        return resultdb;
    }
    //private bool ValidarEmail(string email)
    //{
    //    var resultdb = _context.Customers.Any(c => c.Email == email);
    //    return resultdb;
    //}
}