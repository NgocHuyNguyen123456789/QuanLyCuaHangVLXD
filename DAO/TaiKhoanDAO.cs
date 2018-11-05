﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entity;
namespace DAO
{
    public class TaiKhoanDAO
    {
        VLXD db = new VLXD();
        public int DangNhapDAO(string uName, string pass)
        {
            var user = db.TaiKhoan
                .Where(p => p.TenTaiKhoan == uName)
                .FirstOrDefault();
            if (user != null)
            {
                if (user.MatKhau == pass)
                {
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;

            }
        }

        public List<TaiKhoan> LoadUserDAO()
        {
            var r = db.TaiKhoan.ToList();
            return db.TaiKhoan.ToList();
        }

        public void AddUserDAO(TaiKhoan user)
        {
            db.TaiKhoan.Add(user);
            db.SaveChanges();
        }

        public void DeleteUserDAO(int idToDelete)
        {
            TaiKhoan user = db.TaiKhoan.Find(idToDelete);
            db.TaiKhoan.Remove(user);
            db.SaveChanges();
        }

        public void UpdateUserDAO(TaiKhoan userToUpdate)
        {
            TaiKhoan user = db.TaiKhoan.Find(userToUpdate.MaTaiKhoan);
            user.TenTaiKhoan = userToUpdate.TenTaiKhoan;
            user.MatKhau = userToUpdate.MatKhau;
            db.SaveChanges();
        }

        public List<TaiKhoan> SearchMaUserDAO(int key)
        {
            List<TaiKhoan> result = new List<TaiKhoan>();
            result = db.TaiKhoan.Where(p => p.MaTaiKhoan == key).ToList();
            return result;
        }

        public List<TaiKhoan> SearchTenDangNhapDAO(string key)
        {
            List<TaiKhoan> result = new List<TaiKhoan>();
            result = db.TaiKhoan.Where(p => p.TenTaiKhoan == key).ToList();
            return result;
        }
    }
}
