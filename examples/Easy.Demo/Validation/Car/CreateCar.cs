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
            RuleFor(cmd => cmd.Brand).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Model).NotEmpty().WithMessage("Please specify Model");
            RuleFor(cmd => cmd.Year).NotEmpty().WithMessage("Please specify Year");
        }

    }
}
