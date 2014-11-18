using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Service.Model
{
    public class Address
    {
        /// <summary>
        /// Gets or sets AddressLine1
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine2
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine3
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets Town
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets County
        /// </summary>
        public string County { get; set; }
    }
}
