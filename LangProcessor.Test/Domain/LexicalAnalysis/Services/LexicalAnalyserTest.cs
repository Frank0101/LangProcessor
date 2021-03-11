using FluentAssertions;
using LangProcessor.Domain.LexicalAnalysis.Models;
using LangProcessor.Domain.LexicalAnalysis.Services;
using Xunit;

namespace LangProcessor.Test.Domain.LexicalAnalysis.Services
{
    public class LexicalAnalyserTest
    {
        [Fact]
        public void Analyse_ShouldApplyASimpleSpec()
        {
            // Arrange
            var spec = new TokenSpec("token", "");
            var sut = new LexicalAnalyser(new[] {spec});

            const string input = "this is a test input";

            // Act
            var tokens = sut.Analyse(input);

            // Assert
            tokens.Should().NotBeNull();
        }
    }
}
