using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD.BO.Entitites
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public DateTime? FoundationDate { get; set; }
    }
}
