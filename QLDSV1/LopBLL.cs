using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV1
{
    class LopBLL
    {
        LopDAL dal;
        public LopBLL()
        {
            dal = new LopDAL();
        }
        public DataTable getAllLop()
        {
            return dal.getAllLop();
        }
        public int CheckMaLop(string malop)
        {
            return dal.CheckMaLop(malop);
        }
        public int checkDeleteLop(string malop)
        {
            return dal.checkDeleteLop(malop);
        }
        public bool InsertLop(Lop l)
        {
            return dal.InsertLop(l);
        }
        public bool Delete(Lop l)
        {
            return dal.Delete(l);
        }
        public bool UpdateLop(Lop l)
        {
            return dal.UpdateLop(l);
        }
    }
}
