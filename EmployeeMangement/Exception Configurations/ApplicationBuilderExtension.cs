namespace EmployeeMangement.Configurations
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddExceptionErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
