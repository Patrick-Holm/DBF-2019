using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DB_IO_DBF_2019_
{
    class ClassContext : DbContext
    {

        public ClassContext() : base(@"Data Source=cv-bb-5681;Initial Catalog=NameForDataBase;Integrated Security=True")
        {
            Database.SetInitializer<ClassContext>(new CreateDatabaseIfNotExists<ClassContext>());
        }


    }
}
