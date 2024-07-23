using FluentValidation;
using WebApi.Book.RequestModels;

namespace WebApi.ExampleApi.RequestModels.Validators;

class BookModelValidator : AbstractValidator<BookRequestModel>
{
    public BookModelValidator()
    {
        RuleFor(x => x)
            .NotNull();
        RuleFor(x => x.Name)
            .NotNull()
            .Length(5, 255);
    }
}