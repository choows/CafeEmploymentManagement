using Autofac;
using CafeEmploymentManagement.Resources.Commands.Create;
using MediatR;

namespace CafeEmploymentManagement.IoC
{
	public class MediatorModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// Get the assembly containing your handlers - be specific!
			var handlerAssembly = typeof(CreateCafeCommandHandler).Assembly;

			// Register MediatR components
			builder.RegisterType<Mediator>()
				.As<IMediator>()
				.InstancePerLifetimeScope();

			// Register all handlers - be explicit about the assembly
			builder.RegisterAssemblyTypes(handlerAssembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>))
				.AsImplementedInterfaces();

			// Register notification handlers
			builder.RegisterAssemblyTypes(handlerAssembly)
				.AsClosedTypesOf(typeof(INotificationHandler<>))
				.AsImplementedInterfaces();
		}
	}
}
