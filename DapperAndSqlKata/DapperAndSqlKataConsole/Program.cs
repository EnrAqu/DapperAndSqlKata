using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EFil.Utility.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.ServiceConfigurators;

namespace DapperAndSqlKataConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            const string connstring = "Server=localhost,1433; Database=InstantPOS; User Id=sa; Password=Password1!;";
            Console.WriteLine(connstring);
            var container = new WindsorContainer().Install(new IWindsorInstaller[] { new ServiceInstaller() });

            HostFactory.Run(h =>
            {
                IConfiguration configuration = new DefaultConfiguration();
                h.Service<DapperService>((ServiceConfigurator<DapperService> s) =>
                {
                    s.ConstructUsing((sn) => container.Resolve<DapperService>());
                    s.WhenStarted(myService => myService.OnStart());
                    s.WhenStopped(myService => myService.OnStop());
                });
            });

            Console.ReadLine();
        }
    }
}
