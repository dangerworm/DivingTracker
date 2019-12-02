using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonCode.BusinessLayer;
using CommonCode.Web.Controllers;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Services;
using DivingTracker.Web.Controllers;

namespace DivingTracker.Web.Infrastructure
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["DivingTrackerConnection"].ConnectionString
                .Replace("MACHINENAME", Environment.MachineName);

            var smtpClient = new SmtpClient
            {
                EnableSsl = true,
                Host = ConfigurationManager.AppSettings["SmtpHost"],
                Port = int.Parse(ConfigurationManager.AppSettings["SmtpTlsPort"]),
                UseDefaultCredentials = false
            };

            // Don't be tempted to subsume this into the block above.
            // If you do, the email service stops working. ;)
            smtpClient.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SmtpUsername"],
                ConfigurationManager.AppSettings["SmtpPassword"]
            );

            container.Register(Component
                .For<IUnitOfWork<IDbConnection, IDbTransaction>>()
                .ImplementedBy<SqlUnitOfWork<IDbConnection, IDbTransaction>>()
                .DependsOn(Dependency.OnValue("connectionString", connectionString))
                .LifestylePerWebRequest());

            container.Register(Component
                .For<IEmailService>()
                .ImplementedBy<EmailService>()
                .DependsOn(Dependency.OnValue("smtpClient", smtpClient))
                .LifestyleTransient());

            container.Register(Component
                .For<DivingTrackerEntities>()
                .ImplementedBy<DivingTrackerEntities>()
                .LifestyleTransient());

            //container.Register(Component
            //    .For(typeof(IValidator<>))
            //    .ImplementedBy(typeof(BaseValidator<>))
            //    .LifestyleTransient());

            container.Register(Classes
                .FromAssemblyNamed("DivingTracker.ServiceLayer")
                .InNamespace("DivingTracker.ServiceLayer.Repositories")
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            //container.Register(Classes
            //    .FromAssemblyNamed("DivingTracker.ServiceLayer")
            //    .InNamespace("DivingTracker.ServiceLayer.Validators")
            //    .WithServiceAllInterfaces()
            //    .LifestyleTransient());

            container.Register(Classes
                .FromAssemblyNamed("DivingTracker.ServiceLayer")
                .InNamespace("DivingTracker.ServiceLayer.Workflows")
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes
                .FromAssemblyNamed("DivingTracker.ServiceLayer")
                .InNamespace("DivingTracker.ServiceLayer.Services")
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller))
                .ToList();
            foreach (var controller in controllers)
                container.Register(Component
                    .For(controller)
                    .LifestyleTransient());

            var baseControllers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.BaseType == typeof(BaseController)).ToList();
            foreach (var controller in baseControllers)
                container.Register(Component
                    .For(controller)
                    .LifestyleTransient());

            var divingControllers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.BaseType == typeof(DivingTrackerBaseController)).ToList();
            foreach (var controller in divingControllers)
                container.Register(Component
                    .For(controller)
                    .LifestyleTransient());
        }
    }
}