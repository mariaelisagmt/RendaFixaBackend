using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RendaFixa.Aplication.Config;
public static class SeviceExtension
{
   public static void ConfigureApplicationApp(this IServiceCollection services)
   {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
   }
}