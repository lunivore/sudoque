using Sudoque.Scenarios.Steps;

namespace Sudoque.Scenarios.Framework
{
    public class Scenario
    {
        private readonly SudoqueSteps _sudoqueSteps;
        private readonly CellSelectionSteps _cellSelectionSteps;

        protected Scenario()
        {
            _sudoqueSteps = new SudoqueSteps();
            _cellSelectionSteps = new CellSelectionSteps();
        }

        protected SudoqueSteps ThenSudoque
        {
            get { return _sudoqueSteps; }
        }

        protected CellSelectionSteps WhenISelect
        {
            get { return _cellSelectionSteps; }
        }

        protected SudoqueSteps GivenSudoque
        {
            get { return _sudoqueSteps; }
        }
    }
}