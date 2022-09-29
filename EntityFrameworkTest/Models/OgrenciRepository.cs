using EntityFrameworkTest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityFrameworkTest.Models
{
    public class OgrenciRepository : IOgrenciRepository
    {
        //protected readonly ApplicationDbContext _context;
        //public OgrenciRepository(ApplicationDbContext context) 
        //{
        //    _context = context;
        //}


        public void Create(Ogrenci entity)
        {
            using (var _context = new ApplicationDbContext())
            {
                _context.Ogrenciler.Add(entity);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {

            using (var _context = new ApplicationDbContext())
            {
                var entity = _context.Ogrenciler.Find(id);
                if (entity != null)
                {
                    _context.Ogrenciler.Remove(entity);
                    _context.SaveChanges();
                }
            }
        }

        public Ogrenci Get(int id)
        {
            using (var _context = new ApplicationDbContext())
            {
                return _context.Ogrenciler.Find(id);
            }
        }

        public List<Ogrenci> GetAll()
        {
            using (var _context = new ApplicationDbContext())
            {
                return _context.Set<Ogrenci>().ToList();
            }
        }

        public void Update(Ogrenci entity)
        {
            using (var _context = new ApplicationDbContext())
            {
                _context.Ogrenciler.Update(entity);
                _context.SaveChanges();
            }

        }
    }
}
