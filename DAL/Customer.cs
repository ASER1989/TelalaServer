using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Customer
    {
        public void add(string name, string sex, string ismarr, string cardNo, string address, string workunit, string workaddress, string job, string phone, string str, string username, int userid)
        {
            using (var edm = new appEntities())
            {
                var model = new customerinfo()
                {
                    name = name,
                    sex = sex,
                    ismarr = ismarr,
                    cardNo = cardNo,
                    address = address,
                    workaddress = workaddress,
                    workunit = workunit,
                    job = job,
                    phone = phone,
                    detail = str,
                    createTime = DateTime.Now,
                    user =username,
                    userId = userid,
                    isdel=0
                };
                edm.customerinfo.Add(model);
                edm.SaveChanges();
            }
        }

        public List<customerinfo> GetList(int page = 0, int size = 100)
        {
            using (var edm = new appEntities())
            {
                return edm.customerinfo.Where(p=>p.isdel==0).OrderByDescending(p => p.id).Skip((page - 1) * size).Take(size).ToList();
            }
        }
        public List<customerinfo> GetListByUser(int userid,int page = 0, int size = 100)
        {
            using (var edm = new appEntities())
            {
                return edm.customerinfo.Where(p => p.isdel == 0 && p.userId==userid).OrderByDescending(p => p.id).Skip((page - 1) * size).Take(size).ToList();
            }
        }

        public void DelCustomer(int id)
        {
            using (var edm = new appEntities())
            {
                var model = edm.customerinfo.FirstOrDefault(p => p.id == id);
                model.isdel = 1;
                model.delInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                edm.SaveChanges();
            }
        }

        public int GetCount(int usr=0)
        {
            using (var edm = new appEntities())
            {
                if (usr != 0)
                {
                    return edm.customerinfo.Where(p => p.isdel == 0 && p.userId==usr).Count();
                }
                return edm.customerinfo.Where(p => p.isdel == 0).Count();
            }
        }
    }
}
