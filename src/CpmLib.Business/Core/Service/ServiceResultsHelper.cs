using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Service
{
    public static class ServiceResultsHelper
    {
        public static GetListResult<T> FillGetListResult<T>(List<T> list) 
        {
            return new GetListResult<T>
            {
                Result = list.Count == 0 ? GetResultEnum.NotFound :
                                           GetResultEnum.Success,
                List = list
            };
        }

        public static GetListResult<T> FillGetListResultForError<T>(Exception error)
        {
            return new GetListResult<T>
            {
                Result = GetResultEnum.Error,
                Error = error
            };
        }

        public static GetItemResult<T> FillGetItemResult<T>(T item)
        {
            return new GetItemResult<T>
            {
                Result  = item ==null? GetResultEnum.NotFound : 
                                        GetResultEnum.Success,
                Item = item
            };
        }

        public static GetItemResult<T> FillGetItemResultForError<T>(Exception error)
        {
            return new GetItemResult<T>
            {
                Result = GetResultEnum.Error,
                Error = error                
            };
        }

        public static GetDictionaryResult<TKey, TValue> FillGetDictionaryResult<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            return new GetDictionaryResult<TKey, TValue>
            {
                Result = dictionary.Count == 0 ? GetResultEnum.NotFound :
                                                 GetResultEnum.Success,
                Dictionary = dictionary
            };
        }

        public static GetDictionaryResult<TKey, TValue> FillGetDictionaryResultForError<TKey, TValue>(Exception error)
        {
            return new GetDictionaryResult<TKey, TValue>
            {
                Result = GetResultEnum.Error,
                Error = error
            };
        }


        //public static ProcessResult FillProcessResult(ValidationList validations = null)
        //{
        //    if (validations == null)
        //        return new ProcessResult { Result = ProcessResultEnum.Success };

        //    return new ProcessResult
        //    {
        //        Result = validations.IsValid ?
        //                        ProcessResultEnum.Success : ProcessResultEnum.Validation,
        //        Validations = validations
        //    };
        //}

        //public static ProcessResult FillProcessResultForError(Exception error)
        //{
        //    return new ProcessResult
        //    {
        //        Result = ProcessResultEnum.Error,
        //        Error = error
        //    };
        //}
    }
}
