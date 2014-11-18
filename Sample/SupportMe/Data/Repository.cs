using SupportMe.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data
{
    /// <summary>
    /// Provides a repository for access to an underlaying data source. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        #region Constructor

        /// <summary>
        /// Constructs a new repository using the set of entities. 
        /// </summary>
        /// <param name="entities"></param>
        public Repository(IDbSet<T> entities)
        {
            EntityCollection = entities;
        }

        #endregion

        #region Private Vars

        /// <summary>
        /// Provides the underlaying data source for this repository. 
        /// </summary>
        private IDbSet<T> EntityCollection;

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a new item into the repository. 
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            EntityCollection.Add(item);
        }

        /// <summary>
        /// Removes an item 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(T item)
        {
            EntityCollection.Remove(item);
        }

        /// <summary>
        /// Returns the collection of entities in this repository
        /// </summary>
        public IQueryable<T> Items
        {
            get { return EntityCollection; }
        }

        #endregion 
    }
}
