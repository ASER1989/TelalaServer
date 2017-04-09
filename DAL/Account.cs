using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using Extends;

namespace DAL
{
    public class Account
    {
        public users Login(string name, string pwd)
        {
            try
            {
                using (var edm = new appEntities())
                {
                    pwd = pwd.ToMD5();
                    var model = edm.users.FirstOrDefault(p => p.UserName == name && p.PWd == pwd);
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public users Add(string name, string pwd, string nickname = "")
        {
            try
            {
                using (var edm = new appEntities())
                {
                    pwd = pwd.ToMD5();
                    var model = new users() { UserName = name, PWd = pwd, NickName = nickname, CreateTime = DateTime.Now, Type = 3 };
                    edm.users.Add(model);
                    edm.SaveChanges();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<users> GetUserList()
        {
            try
            {
                using (var edm = new appEntities())
                {
                    var users = edm.users.Where(p => p.Type > 0).ToList();
                    return users;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
