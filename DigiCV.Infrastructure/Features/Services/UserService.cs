using DigiCV.Application.Features.DTOs;
using DigiCV.Application.Features.Training.Services;
using DigiCV.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiCV.Infrastructure.Features.Services
{
    public class UserService : IUserService
    {
        private readonly IAdoNetUtility _adoNetUtility;

        public UserService(IAdoNetUtility adoNetUtility)
        {
            _adoNetUtility = adoNetUtility;
        }

        public async Task<(IList<UserDTO> records, int total, int totalDisplay)>
            GetPagedUsersAsync(int pageIndex,
            int pageSize, string searchText, string orderBy)
        {
            var outParameters = new Dictionary<string, Type>()
            {
                { "Total", typeof(int) },
                { "TotalDisplay", typeof(int) }
            };

            var result = await _adoNetUtility.QueryWithStoredProcedureAsync<UserDTO>("GetPagedUserData",
                    new Dictionary<string, object>
                    {
                        { "PageIndex", pageIndex},
                        { "PageSize", pageSize },
                        { "SearchText", searchText},
                        { "OrderBy", orderBy }
                    },
                    outParameters);

            return (result.result, int.Parse(result.outValues.ElementAt(0).Value.ToString()), int.Parse(result.outValues.ElementAt(1).Value.ToString()));
        }
    }
}
