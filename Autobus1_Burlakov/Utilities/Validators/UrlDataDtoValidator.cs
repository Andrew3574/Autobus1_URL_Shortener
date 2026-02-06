using Autobus1_Burlakov.Models;
using Autobus1_Burlakov.Models.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Autobus1_Burlakov.Utilities.Validators
{
    public class UrlDataDtoValidator : AbstractValidator<UrlsDataDto>
    {
        private static Regex _urlRegex = new Regex("(https?:\\/\\/)?(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)");
        
        public UrlDataDtoValidator()
        {
            RuleFor(e=>e.PassageCounter)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Passage count must be greater than 0");

            RuleFor(e => e.FullUrl)
                .NotEmpty()
                .WithMessage("Enter URL for processing")
                .Must(url=>_urlRegex.IsMatch(url))
                .WithMessage("Wrong URL for processing");
        }
    }
}
