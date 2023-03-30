﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using HotChocolate.Authorization;
using SharedModal.Modals;

namespace UserService.Service
{
    public class Query
    {
        #region User

#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<List<SharedModal.Modals.User>> GetUser([Service] DataContext _context)
        {
            return  await _context.Users.Include(u => u.City).ToListAsync();          
        }

#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<SharedModal.Modals.User> GetUserByID([Service] DataContext _context, int userID)
        {
            var result = await _context.Users.Include(u => u.City).FirstOrDefaultAsync(u => u.UserID == userID);

            if (result == null) { return new SharedModal.Modals.User(); }
            return result;
        }
        #endregion

        #region City
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public  IQueryable<City> GetCity([Service] DataContext _context)
        {
            return  _context.Cities.Include(u => u.Division).AsQueryable();
        }

#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<City> GetCityByID([Service] DataContext _context, int cityID)
        {
            var result = await _context.Cities.Include(u => u.Division).FirstOrDefaultAsync(u => u.CityID == cityID);

            if (result == null) { return new City(); }
            return result;
        }

        #endregion

        #region Devision

        #endregion

    }
}
