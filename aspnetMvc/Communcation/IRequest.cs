using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communcation
{
    public interface IRequest<T> where T : new()
    {
        T Get(string resourceUrl);
        Task<T> GetAsync(string resourceUrl);
        T PostAsJson(string resourceUrl, object obj);
        Task<T> PostAsJsonAsync(string resourceUrl, object obj);
    }
}
