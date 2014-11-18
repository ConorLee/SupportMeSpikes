using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Service.Model
{
    /// <summary>
    /// Represents an individual person in the Database
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the person ID
        /// </summary>
        public Guid PersonID { get; set; }

        /// <summary>
        /// Gets or sets the persons name 
        /// </summary>
        [Required]
        [Display(Name = "Name", Description = "Enter the person's full name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [Display(Name = "Telephone number")]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        [EmailAddress]
        [UIHint("String")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the image for this contact
        /// </summary>
        [Display(Name = "Image")]
        public string Image { get; set; }


    }
}
