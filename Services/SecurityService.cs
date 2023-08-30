using Communal1.Models;
using Communal1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Communal1.Services
{
    public class SecurityService : ISecurityService
    {
        private Communal1Entities1 _context = null;
        public SecurityService() 
        {
            _context = new Communal1Entities1();
        }

        public bool IsValidUser(LogonViewModel model)
        {
            UserDetails user = null;
            user = _context.UserDetails.SingleOrDefault(c=>c.Email.Equals(model.UserName) && c.Password.Equals(model.Password));
            if (user == null)
                return false;
            else
                return true;

        }

        public void SaveUserToDB(RegisterViewModel model)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.FirstName = model.FirstName;
            userDetails.LastName = model.LastName;
            userDetails.Email = model.Email;
            userDetails.Password = model.Password;

            _context.UserDetails.Add(userDetails);
            _context.SaveChanges();
        }

        
        
    }
}