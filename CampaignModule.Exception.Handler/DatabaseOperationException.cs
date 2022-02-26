using CampaignModule.Exception.Handler.Model;

namespace CampaignModule.Exception.Handler
{
    public class DatabaseOperationException : BaseException
    {
        public DatabaseExceptionModel DatabaseException { get; }

        public DatabaseOperationException(DatabaseExceptionModel model, string message) : base(string.Join("-|-", model.GetMessage(), message))
        {
            DatabaseException = model;
        }

        public DatabaseOperationException(DatabaseExceptionModel model, string message, System.Exception innerException) : base(string.Join("-|-", model.GetMessage(), message), innerException)
        {
            DatabaseException = model;
        }
    }
}
