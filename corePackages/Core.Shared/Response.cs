using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared;
public class Response<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}
