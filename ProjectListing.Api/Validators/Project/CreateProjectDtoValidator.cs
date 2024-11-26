using FluentValidation;
using ProjectListing.Api.Models.Project;

namespace ProjectListing.Api.Validators.Project
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name for project is required!");

            RuleFor(x => x.Name)
                .MinimumLength(4)
                .WithMessage("The name of the project is too short. ");

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start date must be erlier than or equal to end date.");
        }
    }
}