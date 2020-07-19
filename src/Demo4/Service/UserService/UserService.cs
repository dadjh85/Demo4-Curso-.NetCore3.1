using Service.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserService
{
    public class UserService : IUserService
    {

        public async Task<List<DtoUserGet>> GetList(bool isRolUser)
        {
            await Task.Delay(2);
            List<DtoUserGet> users = new List<DtoUserGet>();
            for(int i = 1; i<= 10; i++)
            {
                users.Add(new DtoUserGet
                {
                    Id = i,
                    Email = $"email{i}@email.com",
                    Password = "pass",
                    Name = $"testName{i}",
                    StartDate = DateTime.Now
                });
            }

            if (isRolUser)
               return new List<DtoUserGet> { users.FirstOrDefault() };
            else
                return users;
        }
    }
}
