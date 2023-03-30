using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  MyEshop.Models;
using MyEshop.Data;
namespace MyEshop.Data.Repositories;

public interface IUserRepository
{
    void AddUser(Users user);
    bool IsExistUserByEmail(string email);
    Users GetUserForLogin(string email, string password);
}

public class UserRepository : IUserRepository
{
    #nullable disable
    private MyEshopContext _context;
    public UserRepository(MyEshopContext context)
    {
        _context = context;
    }
    public void AddUser(Users user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool IsExistUserByEmail(string email)
    {
        return _context.Users.Any(p => p.Email == email);
    }

    public Users GetUserForLogin(string email, string password)
    {
        return _context.Users.SingleOrDefault(p => p.Email.ToLower() == email && p.Password == password);
    }

}