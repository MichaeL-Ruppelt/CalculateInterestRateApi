using CalculateInterestRateApi.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateApi.Tests.HttpClients
{
    public interface ICalculateInterestRateApi
    {
        [Post("calculajuros?initialvalue={initialValue}&mounts={mounths}")]
        Task<ApiResponse<CalculateResponse>> PostAsync(decimal initialValue, int mounths);

    }
}
