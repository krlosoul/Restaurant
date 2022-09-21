namespace Restaurant.Core.Services
{
    using Restaurant.Core.Constants;

    public class Response<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Status = false;
            Data = default;
            Quantity = 0;
            Message = Enumerator.Status.failed.ToString();
        }
    }

    public class Response : Response<object> { }
}
