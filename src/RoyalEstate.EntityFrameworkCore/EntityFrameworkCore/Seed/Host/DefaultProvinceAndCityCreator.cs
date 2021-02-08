using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RoyalEstate.Entities;

namespace RoyalEstate.EntityFrameworkCore.Seed.Host
{
    public class DefaultProvinceAndCityCreator
    {
        private readonly RoyalEstateDbContext _context;
        private readonly string _defaultProvinceName = "آذربایجان شرقی";
        private readonly string _defaultCityName = "تبریز";
        public DefaultProvinceAndCityCreator(RoyalEstateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if (!_context.Provinces.IgnoreQueryFilters().Any(p=>p.Name.Equals(_defaultProvinceName)))
            {
                _context.Provinces.Add(new Province
                {
                    Name = _defaultProvinceName,
                    IsActive = true,
                    Cities = new List<City>()
                    {
                        new City{Name = _defaultCityName,IsActive = true}
                    }
                });
                _context.SaveChanges();
                return;
            }

            if (!_context.Cities.IgnoreQueryFilters().Any(p => p.Name.Equals(_defaultCityName)))
            {
                var ea = _context.Provinces.First(p => p.Name.Equals(_defaultProvinceName));
                ea.Cities.Add(new City
                {
                    Name = _defaultCityName,
                    IsActive = true
                });
                _context.SaveChanges();
                return;
            }
        }
    }
}
