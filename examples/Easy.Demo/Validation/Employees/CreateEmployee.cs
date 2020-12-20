using Easy.Demo.Commands.Command;
using FluentValidation;

namespace Easy.Demo.Validation.Employees
{
    /// <summary>
    ///  
    /// </summary>
    public class CreateEmployee : AbstractValidator<CreateEmployeeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateEmployee()
        {
            RuleFor(cmd => cmd.FirstName).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.LastName).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Email).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Phone).NotEmpty().WithMessage("Please specify Model");
        }

    }
}
