using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Share.ApiResults
{
    public class ApiSuccessResult<T> : ApiResultBase<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }
        public ApiSuccessResult(string message)
        {
            IsSuccessed = true;
            Message = message;
        }
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
        public ApiSuccessResult(string message, T resultObj)
        {
            IsSuccessed = true;
            Message = message;
            ResultObj = resultObj;
        }
    }
}
