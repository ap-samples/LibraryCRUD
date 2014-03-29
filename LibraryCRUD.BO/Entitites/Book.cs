using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD.BO.Entitites
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
