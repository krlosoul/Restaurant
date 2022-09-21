namespace Restaurant.Core.Services
{
    using Restaurant.Core.Constants;

    public class ResponseService<T>
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
        public int Quantity { get; set; }

        public ResponseService()
        {
            ResponseCode = (int)Enumerator.ResponseCode.InternalError;
            Status = false;
            Data = default;
            Quantity = 0;
            Message = Enumerator.Status.failed.ToString();
        }
    }

    public class ResponseService : ResponseService<object> { }
}
