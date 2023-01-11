namespace Scorerecord.Helper
{
    public class WebHostHelper
    {
        private static IWebHostEnvironment _accessor;
        public static void Configure(IWebHostEnvironment httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }
        public static string baseUrl => _accessor.WebRootPath;
    }
}
