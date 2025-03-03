using Microsoft.Extensions.DependencyInjection;
using UserCreatorTask;
using UserCreatorTask.UserValidators;

namespace IntegrationTests;

public class Container
{
    private IServiceCollection _collection;

    public Container()
    {
        #region dependencies

        _collection = new ServiceCollection();
        _collection.AddSingleton<IStringValidator, NameValidator>();
        _collection.AddSingleton<NameValidator>();
        _collection.AddSingleton<IStringValidator, PasswordValidator>();
        _collection.AddSingleton<PasswordValidator>();
        _collection.AddSingleton<IStringValidator, EmailValidator>();
        _collection.AddSingleton<EmailValidator>();

        _collection.AddSingleton<IUserValidator>(x =>
            new UserValidator(x.GetService<NameValidator>()!, x.GetService<PasswordValidator>()!,
                x.GetService<EmailValidator>()!));

        #endregion
    }

    public IServiceProvider BuildServiceProvider()
    {
        return _collection.BuildServiceProvider();
    }
}