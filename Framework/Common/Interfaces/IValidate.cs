using Framework.Common.Utilities;

namespace Framework.Common.Interfaces
{
    public interface IValidate<T> where T : class
    {
        HttpResponse Validate(T @object);
    }
}
