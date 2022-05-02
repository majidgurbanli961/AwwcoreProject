using System;

namespace Awwcor.Errors
{
    public class CustomError :Exception
    {
        public CustomError(string errorMessage)
           : base(errorMessage)
        {


        }
    }
}
