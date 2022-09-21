namespace Restaurant.Core.Constants
{
    public class Enumerator
    {
        public enum Status
        {
            successful,
            failed,
            noContent
        }

        public enum ResponseCode
        {
            Ok,
            BadRequest,
            NoContent,
            InternalError,
            Created,
            Conflict
        }
    }
}
