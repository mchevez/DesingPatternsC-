using DesingPattern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Repository
{
    public class BeerRepository : IBeer
    {
        private DesignPatternsContext _context;

        public BeerRepository(DesignPatternsContext context) { 
            _context = context;
        }

        public void Add(Beer data) => _context.Add(data);

        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id) => _context.Beers.Find(id);

        public void Update(Beer data) => _context.Entry(data).State = EntityState.Modified;
        public void Delete(int id)
        {
            var data = _context.Beers.Find(id);
            _context.Beers.Remove(data);
        }
        public void Save() => _context.SaveChanges();
    }
}
