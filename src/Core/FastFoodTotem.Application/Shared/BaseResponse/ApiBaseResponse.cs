using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.Shared.BaseResponse
{
    public class ApiBaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public List<KeyValuePair<string, List<string>>>? Errors { get; set; } = new List<KeyValuePair<string, List<string>>>();
    }

    public class ApiBaseResponse<T> : ApiBaseResponse
    {
        public T? Data { get; set; }
    }
}
