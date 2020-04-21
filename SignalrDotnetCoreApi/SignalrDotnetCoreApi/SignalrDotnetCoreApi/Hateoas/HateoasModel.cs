using System.Collections.Generic;
using SignalrDotnetCoreApi.Database.Entities;

namespace SignalrDotnetCoreApi.Hateoas
{
    public class HateoasModel<T> where T : class
    {
        public T Data { get; set; }
        public List<Link> Links { get; set; }
    }
}
