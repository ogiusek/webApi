namespace WebApi.ExampleApi.Validators;

using WebApi.Book.Models;
using FluentValidation;

public class BookModelValidator : AbstractValidator<BookModel>
{
    public BookModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(5, 255);
    }
}