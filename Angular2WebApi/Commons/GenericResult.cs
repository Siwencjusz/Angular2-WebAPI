using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.JScript;

namespace Commons
{
    [DataContract]
    public class Result<T>
    {
        public Result()
        {
            IsValid = false;
            Errors = new List<Error>();
        }

        public Result(T item)
        {
            Value = item;
            IsValid = true;
            Errors = new List<Error>();
        }


        [DataMember]
        public T Value { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public List<Error> Errors { get; set; }
        [DataMember]
        public List<string> InfoMessages { get; set; }
    }

    [DataContract]
    public class Error
    {      
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public ErrorType Severity { get; set; }
    }
}
