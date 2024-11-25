using FluentValidation;
using ProjectListing.Api.Models.Employee;

namespace ProjectListing.Api.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator() 
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Employee's name is required!");

            RuleFor(e => e.Last_Name)
                .NotEmpty()
                .WithMessage("Employee's last name is required!");
        }
    }
}
