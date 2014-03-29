using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD.BO.Entitites
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }

        public DateTime DateBorn { get; set; }


        public virtual ICollection<Book> AutoredBooks { get; set; }
    }
}
