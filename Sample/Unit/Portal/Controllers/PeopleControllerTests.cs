using DesignSample.Controllers;
using Machine.Specifications;
using NSubstitute;
using SupportMe.Data;
using SupportMe.Service;
using SupportMe.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ServiceModel = SupportMe.Service.Model;

namespace Unit.Portal.Controllers.PeopleControllerTests
{
    class Context
    {
        public static IPersonService service;
        public static PeopleController controller;

        Establish context = () =>
        {
            service = Substitute.For<IPersonService>();
            controller = new PeopleController(service); 
        };
    }

    #region .Get() 

    class when_I_call_Add: Context
    {
        static ActionResult result;

        Because of = () => result = controller.Add();

        It should_return_a_view_result = () => result.ShouldBeOfType<ViewResult>();
        It should_a_new_model = () => (result as ViewResult).Model.ShouldNotBeNull(); 


    }

    #endregion 

    #region .Add(Person P, string action) 

    class when_I_post_with_wrong_action: Context
    {
        static ActionResult result;

        Because of = () => result = controller.Add(new Person(), "WRONG");

        It should_return_a_404 = () => result.ShouldBeOfType<HttpNotFoundResult>(); 
    }

    class when_I_post_an_invalid_model: Context 
    {
        static ActionResult result; 
        static Person invalidPerson;

        Establish context = () =>
        {
            invalidPerson = new Person() { EmailAddress = "Test" };
            controller.ModelState.AddModelError("Name", "Name is required");
        };

        Because of = () => result = controller.Add(invalidPerson, "create");

        It should_return_a_view = () => result.ShouldBeOfType<ViewResult>();
        It should_return_the_model = () => (result as ViewResult).Model.ShouldEqual(invalidPerson); 
    }

    class when_I_post_an_valid_model : Context
    {
        static ActionResult result;
        static Person validPerson;

        Establish context = () =>
        {
            validPerson = new Person() { EmailAddress = "Test", Name = "Test" };
        };

        Because of = () => result = controller.Add(validPerson, "create");

        It should_return_a_redirect = () => result.ShouldBeOfType<RedirectToRouteResult>();
        It should_call_the_service_layer = () => service.Received().InsertPerson(validPerson);
    }

    #endregion 
}
