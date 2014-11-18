using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data.Model
{
    public class Address: BaseEntity
    {
        /// <summary>
        /// Gets or sets AddressLine1
        /// </summary>
        public virtual string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine2
        /// </summary>
        public virtual string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine3
        /// </summary>
        public virtual string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets Town
        /// </summary>
        public virtual string Town { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// Gets or sets County
        /// </summary>
        public virtual string County { get; set; }
    }
}
