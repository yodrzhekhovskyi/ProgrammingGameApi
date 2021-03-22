using Autofac;
using Microsoft.Extensions.Configuration;

namespace ProgrammingGameApi.Configuration
{
    /// <summary>
    /// Autofac module for DI configuration of service layer
    /// objects
    /// </summary>
    public class ConfigurationModule : Module
    {
        /// <summary>
        /// Register components with Autofac.
        /// </summary>
        /// <param name="builder">The builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            // Configuration
            builder.Register(ctx =>
            {
                var config = ctx.Resolve<IConfiguration>();
                return config.GetSection("ApplicationSettings").Get<AppSettings>() ?? new AppSettings();
            })
            .As<IAppSettings>()
            .SingleInstance();
        }
    }
}
