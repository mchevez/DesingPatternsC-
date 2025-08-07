using DesingPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DesignPatternsContext _context;
        private DbSet<TEntity> _dbset;

        public Repository(DesignPatternsContext context) {
            _context = context;
            _dbset= _context.Set<TEntity>();
        }
        public void Add(TEntity data) => _dbset.Add(data);

        public void Delete(int id)
        {
           var dataToRemove = _dbset.Find(id);
            if (dataToRemove != null)
            {
                _dbset.Remove(dataToRemove);
            }
        }

        public IEnumerable<TEntity> Get() => _dbset.ToList();

        public TEntity Get(int id) => _dbset.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(TEntity data)
        {
            _dbset.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
