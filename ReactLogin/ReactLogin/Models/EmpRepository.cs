using MongoDB.Driver;
using ReactLogin.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReactLogin.Models
{
    public class EmpRepository
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<SignUp> _collection;

        public EmpRepository()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["connectionString"].ToString());
            _database = _client.GetDatabase("Employees");
            _collection = _database.GetCollection<SignUp>("SignUp");
        }


        public async Task<SignUp> GetEmployee(string email,string pwd)
        {
            var filter = Builders<SignUp>.Filter.Eq(e => e.Email, email);
            filter = filter & Builders<SignUp>.Filter.Eq(e => e.Password, pwd);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<SignUp> CheckEmployee(string name)
        {
            var filter = Builders<SignUp>.Filter.Eq(e => e.EmployeeName, name);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task CreateEmployee(SignUp employee)
        {
            await _collection.InsertOneAsync(new SignUp
            {
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
                Department = employee.Department,
                Email = employee.Email,
                Password = employee.Password,
                City = employee.City
            });
        }

    }
}