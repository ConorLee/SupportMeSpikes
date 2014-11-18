using SupportMe.Service.Model;
using DataModel = SupportMe.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Extensions
{
    /// <summary>
    /// Extensions to aid in inter-domain mapping
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Maps a data address to a service address
        /// </summary>
        /// <param name="dataAddress">The data address</param>
        /// <returns></returns>
        public static Address ToServiceAddress(this DataModel.Address dataAddress)
        {
            return new Address
            {
                AddressLine1 = dataAddress.AddressLine1,
                AddressLine2 = dataAddress.AddressLine2,
                AddressLine3 = dataAddress.AddressLine3,
                Country = dataAddress.Country,
                County = dataAddress.County,
                Town = dataAddress.Town
            };
        }

        
    }
}
