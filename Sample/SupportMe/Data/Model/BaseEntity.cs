using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data.Model
{
    /// <summary>
    /// A class from which all entities are based
    /// </summary>
    public abstract class BaseEntity
    {
        #region Constructor 

        /// <summary>
        /// Instances a new BaseEntity
        /// </summary>
        public BaseEntity()
        {
            Id = Guid.NewGuid(); 
        }

        #endregion 

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public virtual DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets Updated
        /// </summary>
        public virtual DateTime Updated { get; set; }
    }
}
