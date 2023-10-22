using DigiCV.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiCV.Application.Features.Training.Services
{
    public interface IUserService
    {
        Task<(IList<UserDTO> records, int total, int totalDisplay)> GetPagedUsersAsync(int pageIndex,
            int pageSize, string searchText, string orderBy);
    }
}
