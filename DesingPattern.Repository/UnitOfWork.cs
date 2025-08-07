using DesingPattern.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Repository
{
    public class UnitOfWork
    {
        private DesignPatternsContext _context;
        public IRepository<Beer> _beers;
        public IRepository<Brand> _brands;

        public UnitOfWork(DesignPatternsContext context)
        {
            _context = context;
        }

        public IRepository<Beer> Beers
        {
            get { return _beers ?? new Repository<Beer>(_context); }
        }

        public IRepository<Brand> Brands
        {
            get { return _brands ?? new Repository<Brand>(_context); }
        }

        public void Save() => _context.SaveChanges();
    }
}
