using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using CommonCode.BusinessLayer.Helpers;

namespace CommonCode.Web.Infrastructure
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        public WindsorControllerFactory(IWindsorContainer container)
        {
            Verify.NotNull(container, nameof(container));

            Container = container;
        }

        public IWindsorContainer Container { get; protected set; }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;
            disposableController?.Dispose();

            Container.Release(controller);
        }
    }
}