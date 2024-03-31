using System.Net;

namespace BuberDinner.Application.Common.Interfaces;

public interface IError
{
     public HttpStatusCode StatusCode { get; }
     public string ErrorMessage { get; }
}