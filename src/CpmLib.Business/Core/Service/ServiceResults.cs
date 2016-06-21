using CpmLib.Business.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Service
{
    public enum GetResultEnum { Success, Error, NotFound }
    public enum ProcessResultEnum { Success, Error, Validation}

    public class ServiceResultBase
    {
        public Exception Error { get; set; }
        public string ErrorDescription
        {
            get
            {
                if (Error.InnerException == null)
                    return Error.Message;
                else
                    //return string.Format("{0}/n/n{1}", Error.Message, Error.InnerException.Message);
                    return $"{Error.Message}/n/n{Error.InnerException.Message}";
            }
        }
    }

    public class GetListResult<T> : ServiceResultBase
    {
        public GetResultEnum Result { get; set; }
        public List<T> List { get; set; }
    }

    public class GetItemResult<T> : ServiceResultBase
    {
        public GetResultEnum Result { get; set; }
        public T Item { get; set; }
    }

    public class GetDictionaryResult<TKey, TValue> : ServiceResultBase
    {
        public GetResultEnum Result { get; set; }
        public Dictionary<TKey, TValue> Dictionary { get; set; }
    }

    public class ProcessResult : ServiceResultBase
    {
        public ProcessResultEnum Result { get; set; }
        public ValidationList Validations { get; set; }
        public MessageList Messages { get; set; }
    }
}
