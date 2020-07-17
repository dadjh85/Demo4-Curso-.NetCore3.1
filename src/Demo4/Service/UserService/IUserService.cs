using Service.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.UserService
{
    public interface IUserService
    {
        Task<List<DtoUserGet>> GetList();
    }
}
