using SupportMe.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data
{
    public interface IUnitOfWork
    {
        
        /// <summary>
        /// Gets or sets the person repository
        /// </summary>
        IRepository<Person> PersonRepository { get; }

        /// <summary>
        /// Commits any outstanding changes carried out through this unit of work to the underlaying data store.  
        /// </summary>
        void Commit(); 
    }
}
