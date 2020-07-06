using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Models.Bops
{
    public class BopsListingModel
    {
        public IEnumerable<BopsDetailModel> BopsDetailsList { get; set; }
    }
}
