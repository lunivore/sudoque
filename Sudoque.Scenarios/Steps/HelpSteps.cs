using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class HelpSteps
    {
        private readonly World _world;

        public HelpSteps(World world)
        {
            _world = world;
        }

        public void Please()
        {
            _world.Operations.AskForHelp();
        }

        public void ShouldTellMe(string text)
        {
            _world.Operations.HelpTextShouldBe(text);
        }
    }
}