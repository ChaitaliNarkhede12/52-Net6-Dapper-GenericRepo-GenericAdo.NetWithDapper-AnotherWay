using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCS.Domain.Models
{
    public class DatabaseConnectionWithoutCredentials
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserIntegratedSecurity { get; set; }
        public string ConnectionStringTemplate { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
