using SupportMe.Data;
using SupportMe.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = SupportMe.Data.Model;
using SupportMe.Extensions;

namespace SupportMe.Service
{
    /// <summary>
    /// A service for managing people
    /// </summary>
    public class PersonService: IPersonService
    {
        #region Constructor 

        /// <summary>
        /// Builds a new Person Service
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public PersonService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
        }

        #endregion 

        #region Fields 

        private readonly IUnitOfWork unitOfWork; 

        #endregion 

        #region Methods 

        /// <summary>
        /// Fetches an individual person
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns></returns>
        public Person RetrieveIndividual(Guid personId)
        {
            var dataPerson = unitOfWork.PersonRepository.Items.SingleOrDefault(p => p.Id == personId);
            if (dataPerson == null) throw new ArgumentException("personId");

            return mapDataToService(dataPerson); 
        }

        /// <summary>
        /// Fetches everyone
        /// </summary>
        /// <returns>All people</returns>
        public ICollection<Person> RetrieveAll()
        {
            var allPeople = unitOfWork.PersonRepository.Items.ToList();
            var servicePeople = from p in allPeople
                                select mapDataToService(p);

            return servicePeople.ToList();
        }

        /// <summary>
        /// Removes a person
        /// </summary>
        /// <param name="personId"></param>
        public void RemovePerson(Guid personId)
        {
            var person = unitOfWork.PersonRepository.Items.Single(p => p.Id == personId);
            unitOfWork.PersonRepository.Delete(person);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Insers a new person
        /// </summary>
        /// <param name="servicePerson">The person</param>
        /// <returns></returns>
        public Guid InsertPerson(Model.Person servicePerson)
        {
            var dataAddress = new DataModel.Address
            {
                AddressLine1 = servicePerson.Address.AddressLine1,
                AddressLine2 = servicePerson.Address.AddressLine2,
                AddressLine3 = servicePerson.Address.AddressLine3,
                Country = servicePerson.Address.Country,
                County = servicePerson.Address.County,
                Town = servicePerson.Address.Town
            };
            var dataPerson = new DataModel.Person
            {
                Address = dataAddress,
                EmailAddress = servicePerson.EmailAddress,
                Image = servicePerson.Image,
                Name = servicePerson.Name,
                TelephoneNumber = servicePerson.TelephoneNumber
            };

            unitOfWork.PersonRepository.Insert(dataPerson);
            unitOfWork.Commit();

            return dataPerson.Id;
        }

        #endregion 

        #region Helper Methods 

        /// <summary>
        /// Maps a data person to a service person
        /// </summary>
        /// <param name="dataPerson"></param>
        /// <returns></returns>
        private Person mapDataToService(DataModel.Person dataPerson)
        {
            var servicePerson = new Person
            {
                Address = dataPerson.Address.ToServiceAddress(),
                EmailAddress = dataPerson.EmailAddress,
                Image = dataPerson.Image,
                Name = dataPerson.Name,
                PersonID = dataPerson.Id,
                TelephoneNumber = dataPerson.TelephoneNumber

            };

            return servicePerson;
        }

        #endregion 
    }
}
