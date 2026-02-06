using Autobus1_Burlakov.Models;
using Autobus1_Burlakov.Utilities.Validators;
using FluentValidation.TestHelper;

namespace Tests
{
    public class ValidatorTests
    {
        private readonly UrlDataValidator _validator;

        public ValidatorTests()
        {
            _validator = new UrlDataValidator();
        }

        [Theory]
        [InlineData("https://example.com")]
        [InlineData("http://example.com")]
        [InlineData("https://www.example.com")]
        [InlineData("http://subdomain.example.com/path?query=1")]
        [InlineData("https://example.com/page.html")]
        [InlineData("https://github.com/Andrew3574?tab=overview&from=2025-12-01&to=2025-12-31")]
        public void isUrlValid(string url)
        {
            var model = new Urlsdatum{FullUrl = url,PassageCounter = 10};
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.FullUrl);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void isUrlNotValid(string url)
        {
            var model = new Urlsdatum { FullUrl = url, PassageCounter = 10 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullUrl);
        }
       
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(1000000)]
        public void Should_Have_No_Errors_When_PassageCounter_Is_Valid(int passageCounter)
        {
            var model = new Urlsdatum{FullUrl = "https://example.com",PassageCounter = passageCounter};
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PassageCounter);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        public void Should_Have_Error_When_PassageCounter_Is_Negative(int passageCounter)
        {
            var model = new Urlsdatum { FullUrl = "https://example.com", PassageCounter = passageCounter };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PassageCounter);
        }    
    }
}
