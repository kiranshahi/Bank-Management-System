using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ChqCancellationBs
    {
        private ChqCancellationDb objDb;

        public ChqCancellationBs()
        {
            objDb = new ChqCancellationDb();
        }

        public IEnumerable<tblChqCancellation> GetAll()
        {
            return objDb.GetAll();
        }

        public tblChqCancellation GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblChqCancellation op)
        {
            objDb.Insert(op);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblChqCancellation op)
        {
            objDb.Update(op);
        }

    }
}

