using SupportMe.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = SupportMe.Data.Model;

namespace SupportMe.Service
{
    /// <summary>
    /// Outlines a service to manage people 
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Fetches an individual person from the data store
        /// </summary>
        /// <param name="personId">The person ID</param>
        /// <returns>A person</returns>
        Person RetrieveIndividual(Guid personId);

        /// <summary>
        /// Fetches everyone
        /// </summary>
        /// <returns></returns>
        ICollection<Person> RetrieveAll();

        /// <summary>
        /// Removes a person
        /// </summary>
        /// <param name="personId">Their ID</param>
        void RemovePerson(Guid personId);

        /// <summary>
        /// Inserts a new person
        /// </summary>
        /// <param name="servicePerson"></param>
        /// <returns></returns>
        Guid InsertPerson(Person servicePerson); 
    }
}
