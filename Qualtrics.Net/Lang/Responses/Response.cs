using Qualtrics.Net.Lang.Responses.Meta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses
{
    // Response base class
    public abstract class Response
    {
        public MetaWithError Meta { get; internal set; }

        // Not part of API
        public virtual bool IsSuccess()
        {
            return Meta.HttpStatus == "200";
        }
    }
}
