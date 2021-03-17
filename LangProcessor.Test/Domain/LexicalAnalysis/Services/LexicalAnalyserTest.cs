using FluentAssertions;
using LangProcessor.Domain.LexicalAnalysis.Models;
using LangProcessor.Domain.LexicalAnalysis.Services;
using Xunit;

namespace LangProcessor.Test.Domain.LexicalAnalysis.Services
{
    public class LexicalAnalyserTest
    {
        [Fact]
        public void Analyse_ShouldApplyOneSimpleRule()
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

        [Fact]
        public void Analyse_ShouldApplyMultipleSimpleRules()
        {
            // Arrange
            var rule1 = new LexicalRule("character", "[a-zA-Z]");
            var rule2 = new LexicalRule("number", "[0-9]");
            var sut = new LexicalAnalyser(new[] {rule1, rule2});

            const string input = "test123";

            // Act
            var symbols = sut.Analyse(input);

            // Assert
            symbols.Should().Contain(new[]
            {
                new Symbol("character", "t"),
                new Symbol("character", "e"),
                new Symbol("character", "s"),
                new Symbol("character", "t"),
                new Symbol("number", "1"),
                new Symbol("number", "2"),
                new Symbol("number", "3")
            });
        }
    }
}
