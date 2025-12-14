using System;
using System.Collections.Generic;
using System.Linq;

namespace Erp.Application.Common.Models
{
    //public class Result
    //{
    //    internal Result(bool succeeded, IEnumerable<string> errors, string success)
    //    {
    //        Succeeded = succeeded;
    //        Errors = errors.ToArray();
    //        Message = success;
    //    }

    //    public bool Succeeded { get; set; }

    //    public string Message { get; set; }

    //    public string[] Errors { get; set; }

    //    public static Result Success(string success = "Process successfully completed")
    //    {
    //        return new Result(true, new string[] { }, success);
    //    }


    //    public static Result Failure(IEnumerable<string> errors)
    //    {
    //        return new Result(false, errors, null);
    //    }


    //public List<Result> ToList()
    //{
    //    throw new NotImplementedException();
    //}

    //internal static Result Failure(string v)
    //{
    //    throw new NotImplementedException();
    //}

    //public static implicit operator int(Result v)
    //{
    //    throw new NotImplementedException();
    //}

    //public static implicit operator Result(List<Result> v)
    //{
    //    throw new NotImplementedException();
    //}
    // }
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors, string success)
        {
            Succeeded = succeeded;
            Errors = errors?.ToArray() ?? Array.Empty<string>();
            Message = success;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }

        public static Result Success(string success = "Process successfully completed")
        {
            return new Result(true, Array.Empty<string>(), success);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors, null);
        }
    }

}
