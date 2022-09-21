namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Constants;
    using Restaurant.Core.Services;

    public static class ResponseServiceStub
    {
        public static readonly ResponseService responseServiceOk = new ResponseService
        {
            ResponseCode = (int)Enumerator.ResponseCode.Ok,
            Status = true
        };

        public static readonly ResponseService responseServiceBadRequest = new ResponseService
        {
            ResponseCode = (int)Enumerator.ResponseCode.BadRequest
        };

        public static readonly ResponseService responseServiceNoContent = new ResponseService
        {
            ResponseCode = (int)Enumerator.ResponseCode.NoContent
        };
    }
}
