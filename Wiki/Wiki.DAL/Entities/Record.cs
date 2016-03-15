using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.DAL.Entities
{
    public class Record
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Header { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsDeleted{ get; set; }
    }
}
