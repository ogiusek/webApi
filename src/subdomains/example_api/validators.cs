namespace WebApi.ExampleApi.Models.Validators;

using FluentValidation;

public class HelloWorldBodyValidator : AbstractValidator<HelloWorldBody>
{
    public HelloWorldBodyValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
    }
}

public class HelloWorldQueryValidator : AbstractValidator<HelloWorldQuery>
{
    public HelloWorldQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
    }
}