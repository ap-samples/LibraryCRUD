using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryCRUD.DA
{
    public class LibraryInitializer : CreateDatabaseIfNotExists<LibraryCRUDContext>
    {

    }
}
