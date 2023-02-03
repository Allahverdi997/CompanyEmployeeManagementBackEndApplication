namespace RusMProject.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SwaggerAuthToken:Attribute
    {
    }
}
