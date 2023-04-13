using DesignPatterns2;

namespace DesignPatterns2TestProject
{
    public class CompetitorTests
    {

        [Fact]
        public void TestCompetitorCreateName()
        {
            var competitor = new Competitor();

            Assert.False(string.IsNullOrWhiteSpace(competitor.Name));
        }

        [Fact]
        public void TestCompetitorCreateUniform()
        {
            var competitor = new Competitor();

            Assert.True(competitor.UniformColor != null);
        }

        [Fact]
        public void TestCompetitorCreateGem()
        {
            var competitor = new Competitor();

            Assert.True(competitor.GemStone != null);
        }

        [Fact]
        public void TestCompetitorCreateTurns()
        {
            var competitor = new Competitor();

            Assert.InRange(competitor.TurnsRemaining, 10, 20);
        }
    }
}