namespace AspHw6
{
    public class RequestLoggingService
    {
        private readonly List<string> _requests = new();

        public void AddRequest(string request)
        {
            _requests.Add(request);
        }

        public List<string> GetRequests()
        {
            return _requests;
        }
    }
}