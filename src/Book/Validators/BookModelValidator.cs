using WebApi.Book.Models;
using FluentValidation;

namespace WebApi.ExampleApi.Validators;

class BookModelValidator : AbstractValidator<BookModel>
{
    public BookModelValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.Id).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Name).NotNull().Length(5, 255);
    }
}