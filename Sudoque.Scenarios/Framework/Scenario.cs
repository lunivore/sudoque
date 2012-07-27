using System;
using Sudoque.Scenarios.Steps;

namespace Sudoque.Scenarios.Framework
{
    public class Scenario
    {
        private readonly SudoqueSteps _sudoqueSteps;
        private readonly CellSteps _cellSteps;
        private readonly HelpSteps _helpSteps;

        private World _world;
        protected static readonly string NL = Environment.NewLine;
        protected readonly string None = string.Empty;

        protected Scenario()
        {
            _world = new World();
            _sudoqueSteps = new SudoqueSteps(_world);
            _cellSteps = new CellSteps(_world);
            _helpSteps = new HelpSteps(_world);
        }
        
        protected CellSteps WhenISelectACell
        {
            get { return _cellSteps; }
        }

        protected CellSteps ThenTheCell
        {
            get { return _cellSteps; }
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

        protected SudoqueSteps AndSudoque
        {
            get { return _sudoqueSteps; }
        }

        protected HelpSteps WhenIAskForHelp { get { return _helpSteps; } }

        protected HelpSteps ThenTheHintText { get { return _helpSteps; } }
    }
}