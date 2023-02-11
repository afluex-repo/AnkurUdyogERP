using System;

namespace AnkurUdyogERP.Controllers
{
    internal class OnActionAttribute : Attribute
    {
        public string ButtonName { get; set; }
    }
}