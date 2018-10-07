using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EToken.DataContext;
using EToken.Models;
using Microsoft.AspNetCore.Mvc;

namespace EToken.Controllers
{
    public class CustomerController : Controller
    {
        //checking By Giri

        private readonly ETokenDBContext _OBJETokenDBContext;

        public CustomerController(ETokenDBContext OBJETokenDBContext)
        {
            _OBJETokenDBContext = OBJETokenDBContext;
        }


        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        } //End of public IActionResult Create()



        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer invCustomer)
        {
            if (ModelState.IsValid)
            {

                //adding the value for the primary key guidid
                invCustomer.CustomerID = new Guid();

                //Generating the next token no and saving for the customer
                //currently the logic getting the total no of customer and adding one, it may change in future if required
                invCustomer.CustomerTokenNumber = _OBJETokenDBContext.Customer.Count() + 1;
                _OBJETokenDBContext.Add(invCustomer);
                await _OBJETokenDBContext.SaveChangesAsync();
                return View("CreateConfirmation", invCustomer);
            } //End of  if (ModelState.IsValid)
            return View(invCustomer);
        } // End of public async Task<IActionResult> Create(Customer invCustomer)



    } // End of  public class CustomerController : Controller


} //End of namespace EToken.Controllers