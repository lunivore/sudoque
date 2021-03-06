using System;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class SudoqueSteps
    {
        private readonly World _world;
        private static readonly string NL = Environment.NewLine;

        public SudoqueSteps(World world)
        {
            _world = world;
        }

        public void IsRunning()
        {
            _world.Initialize();
        }

        public void ShouldLookLike(string grid)
        {
            _world.PuzzleView.ShouldMatch(grid);
        }

        public void HasAPuzzle(string grid)
        {
            IsRunning();
            _world.PuzzleView.SetUpWith(grid);
        }

        public void IsPlayed()
        {
            _world.Operations.PlayGame();
        }

        public void IsPlayedWithAPuzzle(string puzzle)
        {
            HasAPuzzle(puzzle);
            IsPlayed();
        }

        public void IsToldToCreateANewGame()
        {
            _world.Operations.CreateNewGame();
        }

        public void ShouldBeEmpty()
        {
            _world.PuzzleView.ShouldMatch(
                
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }

        public void AddPotentials(int column, int row, string potentials)
        {
            _world.PuzzleView.AddPotentials(column, row, potentials);
        }
    }
}