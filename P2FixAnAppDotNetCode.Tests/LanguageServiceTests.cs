using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    /// <summary>
    /// The LanguageService class
    /// </summary>
    public class LanguageServiceTests
    {
        [Fact]
        public void SetCulture()
        {
            // Arrange
            ILanguageService languageService = new LanguageService();
            string language = "French";

            // Act
            string culture = languageService.SetCulture(language);

            // Assert
            Assert.Same("fr", culture);
        }
    }
}
