using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.Meta
{
    // Meta with error
    public class MetaWithError
    {
        public string HttpStatus { get; internal set; }

        public string RequestId { get; internal set; }

        public string Notice { get; internal set; }

        public Error Error { get; internal set; }
    }

    // Error
    public class Error
    {
        public string ErrorMessage { get; internal set; }

        public string ErrorCode { get; internal set; }
    }
}
