using Machine.Specifications;
using NSubstitute;
using SupportMe.Data;
using SupportMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = SupportMe.Data.Model; 
using ServiceModel = SupportMe.Service.Model; 

namespace Unit.SupportMe.Services.PeopleServiceTests
{
    class Context
    {
        public static IUnitOfWork unitOfWork; 
        public static PersonService service; 

        Establish context = () =>
        {
            unitOfWork = Substitute.For<IUnitOfWork>();
            service = new PersonService(unitOfWork); 
        };
    }

    #region .RetrieveIndividual

    class when_I_call_RetrieveIndividual: Context
    {
        static Guid personId;
        static DataModel.Person dataPerson;
        static ServiceModel.Person result;

        Establish context = () =>
        {
            dataPerson = new DataModel.Person() { Id = personId, Name = "Test", EmailAddress = "test", Address = new DataModel.Address() { AddressLine1 = "Test" } };

            var personList = new List<DataModel.Person>();
            personList.Add(dataPerson); 
            unitOfWork.PersonRepository.Items.Returns(personList.AsQueryable()); 

        };

        Because of = () => result = service.RetrieveIndividual(personId);

        It returns_a_person = () => result.ShouldNotBeNull();
        It has_the_correct_name = () => result.Name.ShouldEqual("Test");
        It has_the_email_address = () => result.EmailAddress.ShouldEqual("test");
        It has_the_address_line_one = () => result.Address.AddressLine1.ShouldEqual("Test");
    }

    class when_I_call_RetrieveIndividual_and_the_person_isnt_found : Context
    {
        static Guid personId;
        static DataModel.Person dataPerson;
        static Exception result; 

        Establish context = () =>
        {
            dataPerson = new DataModel.Person() { Id = personId, Name = "Test", EmailAddress = "test", Address = new DataModel.Address() { AddressLine1 = "Test" } };

            var personList = new List<DataModel.Person>();
            personList.Add(dataPerson);
            unitOfWork.PersonRepository.Items.Returns(personList.AsQueryable());

        };

        Because of = () => result = Catch.Exception(() => 
        { 
            service.RetrieveIndividual(Guid.NewGuid()); 
        });

        It throws_an_argument_null_exception = () => result.ShouldBeOfType<ArgumentException>();
    }

    #endregion 
}
