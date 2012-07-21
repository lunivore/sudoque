using Sudoque.Scenarios.Steps;

namespace Sudoque.Scenarios.Framework
{
    public class Scenario
    {
        private readonly SudoqueSteps _sudoqueSteps;
        private readonly CellSelectionSteps _cellSelectionSteps;
        private World _world;

        protected Scenario()
        {
            _world = new World();
            _sudoqueSteps = new SudoqueSteps(_world);
            _cellSelectionSteps = new CellSelectionSteps(_world);
        }


        protected CellSelectionSteps WhenISelect
        {
            get { return _cellSelectionSteps; }
        }

        protected SudoqueSteps GivenSudoque
        {
            get { return _sudoqueSteps; }
        }
        
        protected SudoqueSteps WhenSudoque
        {
            get { return _sudoqueSteps; }
        }

        protected SudoqueSteps ThenSudoque
        {
            get { return _sudoqueSteps; }
        }
    }
}