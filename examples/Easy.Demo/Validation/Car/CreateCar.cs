using Easy.Demo.Commands.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            RuleFor(cmd => cmd.CreatedAt).NotEmpty().WithMessage("Please specify CreatedAt");
        }

        private bool MustBeAValidEmail(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
