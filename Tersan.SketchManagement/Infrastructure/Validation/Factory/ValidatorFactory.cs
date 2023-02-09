using FluentValidation;

namespace Tersan.SketchManagement.Infrastructure.Validation.Factory
{
    public class ValidatorFactory : ICustomValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)_serviceProvider.GetService(typeof(IValidator<T>));
        }

        public IValidator GetValidator(Type type)
        {
            return (IValidator)_serviceProvider.GetService(typeof(IValidator<>).MakeGenericType(type));
        }
    }
}