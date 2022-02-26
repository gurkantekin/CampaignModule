using System.Collections.Generic;

namespace CampaignModule.Exception.Handler
{
    public class BaseException : System.Exception
    {
        public List<string> Messages { get; private set; }

        protected void Initialize()
        {
            Messages = new List<string>();
        }

        protected BaseException(string message) : base(message)
        {
            Initialize();
            Messages.Add(message);
        }

        protected BaseException(string message, System.Exception innerException) : base(message, innerException)
        {
            Initialize();
            Messages.Add(string.Join("-|-", message, innerException));
        }
    }
}
