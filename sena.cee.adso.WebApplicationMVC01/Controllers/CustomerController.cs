﻿using Microsoft.AspNetCore.Mvc;
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
    public ActionResult Details(int customerId) //CustomerId
    {
        var customer = _context.Customers.Find(customerId);
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
        try
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            TempData["ResultOk"] = "¡Recorded added successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return View();
        }
    }
    
    //GET: CustomerController/Edit/5
    [HttpGet]
    public ActionResult Edit(int customerId)
    {
        if (customerId == null || customerId==0)
        {
            return NotFound();
        }

        var customerfromdb = _context.Customers.Find(customerId);
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
    public ActionResult Delete(int customerId)
    {
        if (customerId == null || customerId <=0)
        {
            return NotFound();
        }

        var customerfromdb = _context.Customers.Find(customerId);
        if (customerfromdb == null)
        {
            return NotFound();
        }

        return View(customerfromdb);
    }
    
    //POST: CustomerController/Delete/5
    [HttpPost]
    public ActionResult Delete(int? customerId)
    {
        try
        {
            var customerfromdb = _context.Customers.Find(customerId);
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
    


}