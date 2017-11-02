using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ActtypeBs
    {
        private ActTypeDb objDb;

        public ActtypeBs()
        {
            objDb = new ActTypeDb();
        }

        public IEnumerable<tblactType> GetAll()
        {
            return objDb.GetAll();
        }

        public tblactType GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblactType op)
        {
            objDb.Insert(op);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblactType op)
        {
            objDb.Update(op);
        }

    }
}



