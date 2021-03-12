using FluentAssertions;
using LangProcessor.Domain.LexicalAnalysis.Models;
using LangProcessor.Domain.LexicalAnalysis.Services;
using Xunit;

namespace LangProcessor.Test.Domain.LexicalAnalysis.Services
{
    public class LexicalAnalyserTest
    {
        [Fact]
        public void Analyse_ShouldApplyASimpleRule()
        {
            // Arrange
            var rule = new LexicalRule("character", "[a-zA-Z]");
            var sut = new LexicalAnalyser(new[] {rule});

            const string input = "test";

            // Act
            var symbols = sut.Analyse(input);

            // Assert
            symbols.Should().Contain(new[]
            {
                new Symbol("character", "t"),
                new Symbol("character", "e"),
                new Symbol("character", "s"),
                new Symbol("character", "t")
            });
        }
    }
}
