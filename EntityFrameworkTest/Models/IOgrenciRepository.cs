using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public interface IOgrenciRepository
    {
        void Create(Ogrenci entity);
        void Update(Ogrenci entity);
        void Delete(int id);
        Ogrenci Get(int id);
        List<Ogrenci> GetAll();

    }
}
