using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess {get;set;}

        public T Data {get;set;}
        public string Error {get;set;}
        public static Result<T> Success(T data) => new Result<T>{IsSuccess=true,Data=data};
        public static Result<T> Failure(string  error) => new Result<T>{IsSuccess=false,Error=error};
    }
}