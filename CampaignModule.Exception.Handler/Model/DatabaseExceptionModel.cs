namespace CampaignModule.Exception.Handler.Model
{
    public class DatabaseExceptionModel : BaseExceptionModel
    {
        public override string Message { get; set; }

        public string DataBaseName { get; set; }

        public string TableName { get; set; }

        public DatabaseOperationEnum Operation { get; set; }

        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public string NameSpace { get; set; }

        public string GetMessage()
        {
            return $"DatabaseName:{DataBaseName} TableName:{TableName} Operation:{Operation} NameSpace:{string.Join(".", NameSpace, ClassName, MethodName)} Message:{Message}";
        }
    }
}
