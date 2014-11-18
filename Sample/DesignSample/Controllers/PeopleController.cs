using SupportMe.Service;
using SupportMe.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignSample.Controllers
{
    public class PeopleController : Controller
    {
        #region Constructor 

        /// <summary>
        /// Creates a new people controller with dependancies
        /// </summary>
        /// <param name="service">The person service</param>
        public PeopleController(IPersonService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            this.service = service;
        }

        #endregion 

        #region Fields 

        private readonly IPersonService service; 

        #endregion 

        #region Actions 

        //
        //GET : Add 

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Person());
        }

        //
        //POST: Add

        [HttpPost]
        public ActionResult Add(Person p, string action)
        {
            if (action.ToLower() == "create")
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ErrorMessage = "An error has been detected!";
                    return View(p);
                }

                service.InsertPerson(p);

                TempData.Add("SuccessNotice", "Person has been added!");
                return RedirectToAction("Index");
            }

            return HttpNotFound();
        }

        #endregion 

    }
}