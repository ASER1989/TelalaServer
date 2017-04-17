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
                    userId = userid
                };
                edm.customerinfo.Add(model);
                edm.SaveChanges();
            }
        }

        public List<customerinfo> GetList(int page = 0, int size = 100)
        {
            using (var edm = new appEntities())
            {
                return edm.customerinfo.OrderByDescending(p => p.id).Skip((page - 1) * size).Take(size).ToList();
            }
        }

        public int GetCount()
        {
            using (var edm = new appEntities())
            {
                return edm.customerinfo.Count();
            }
        }
    }
}
