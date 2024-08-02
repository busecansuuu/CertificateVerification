using CertificateVerification.Services;

namespace CertificateVerification.DIExtension
{
    public static class DIExtension
    {
        public static void AddDI(this IServiceCollection services)
        {
          
            services.AddScoped<HttpClientServiceAction>();
        }
    }
}
