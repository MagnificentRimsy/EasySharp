using Easy.Demo.Commands.Command;
using FluentValidation;

namespace Easy.Demo.Validation.Car
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCar : AbstractValidator<CreateCarCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCar()
        {
            RuleFor(cmd => cmd.FirstName).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.LastName).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Email).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Phone).NotEmpty().WithMessage("Please specify Model");
        }

    }
}
