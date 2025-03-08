using TaskManagerAPI.DomainTransferObjects;
using FastEndpoints;
using FluentValidation;

namespace TaskManagerAPI.Validators;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("a title is required and cannot be empty");
        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("a due date cannot be in the past");
    }
}