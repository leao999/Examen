using System.Collections.Generic;
using WebLuisArrieta.Model;

namespace WebLuisArrieta.Tests.Controllers
{
    internal class PartialViewResult
    {
        public IEnumerable<Customer> Model { get; internal set; }
        public object ViewName { get; internal set; }
    }
}