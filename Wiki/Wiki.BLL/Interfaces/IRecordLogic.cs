using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.BLL.DTO;

namespace Wiki.BLL.Interfaces
{
    public interface IRecordLogic
    {
        IEnumerable<RecordDTO> GetAll();
        RecordDTO Get(int? id);
        void Add(RecordDTO recordDto);
        void Delete(int id);
        void Edit(RecordDTO recordDto);
        RecordDTO RateArticle(string url);
    }
}
