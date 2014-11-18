using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data
{
    /// <summary>
    /// Provides a method by which models of a particular type can be manipulated via a unit of work.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {

        /// <summary>
        /// Inserts a new item into the repository.
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        /// Removes the item from the repository 
        /// </summary>
        /// <param name="id"></param>
        void Delete(T item);

        /// <summary>
        /// Gets the items in the repository. 
        /// </summary>
        IQueryable<T> Items { get; }
    }
}
