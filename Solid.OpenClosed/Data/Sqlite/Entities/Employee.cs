using System;
using System.Collections.Generic;

namespace Solid.OpenClosed.Data.Sqlite.Entities
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
