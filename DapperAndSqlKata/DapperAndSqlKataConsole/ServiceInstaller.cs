using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DapperAndSqlKata.DapperImplementation;
using DapperAndSqlKata.Infrastructure;
using EFil.Utility.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndSqlKataConsole
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            const string connstring = "Server=localhost,1433; Database=InstantPOS; User Id=sa; Password=Password1!;";

            container.Register(
                Component.For<IConfiguration>().ImplementedBy<DefaultConfiguration>(),
                Component.For<IDatabaseConnectionFactory>().ImplementedBy<SqlConnectionFactory>().UsingFactoryMethod(k =>
                {
                    var configurationManager = k.Resolve<IConfiguration>();
                    return new SqlConnectionFactory(
                               connstring
                        );
                }).LifestyleTransient(),
                Component.For<IWindsorContainer>().Instance(container)
            );
        }
    }
}
