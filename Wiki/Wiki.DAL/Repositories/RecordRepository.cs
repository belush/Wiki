using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.DAL.Context;
using Wiki.DAL.Entities;
using Wiki.DAL.Interfaces;

namespace Wiki.DAL.Repositories
{
    public class RecordRepository : IRepository<Record>
    {
        private WikiContext db;

        public RecordRepository(WikiContext context)
        {
            db = context;
        }

        public IEnumerable<Record> GetAll()
        {
            return db.Records.Where(r => r.IsDeleted == false);
        }

        public Record Get(int id)
        {
            return db.Records.Find(id);
        }

        public void Add(Record item)
        {
            item.Date = DateTime.Now;
            db.Records.Add(item);
            db.SaveChanges();
        }

        public void Edit(Record item)
        {
            var record = db.Records.Find(item.Id);
            record.IsSuccess = item.IsSuccess;
            record.Result = item.Result;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = db.Records.Find(id);
            if (record != null)
            {
                record.IsDeleted = true;
                db.SaveChanges();
            }
        }
    }
}
