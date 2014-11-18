using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data.Model
{
    /// <summary>
    /// Represents an individual person in the Database
    /// </summary>
    public class Person: BaseEntity
    {
        /// <summary>
        /// Gets or sets the persons name 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public virtual string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public virtual string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the image for this contact
        /// </summary>
        public virtual string Image { get; set; }

    }
}
