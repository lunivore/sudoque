using System;
using NUnit.Framework;

namespace Sudoque.Scenarios.Framework
{
    public class ScenarioCell
    {
        private readonly World _world;
        private readonly int _ninerId;
        private readonly int _cellId;

        public ScenarioCell(World world, int ninerId, int cellId)
        {
            _world = world;
            _ninerId = ninerId;
            _cellId = cellId;
        }

        public void AndToggle(params int[] selection)
        {
            var cell = _world.CellFinder.FromNinerAndCellId(_ninerId, _cellId);
            cell.GotFocus.Execute("whatever");
            var commands = _world.Operations;
            Array.ForEach(selection, commands.PressNumber);
        }

        public ScenarioCell ShouldHavePotentials(params int[] expectedPotentials)
        {
            var cell = _world.CellFinder.FromNinerAndCellId(_ninerId, _cellId);
            var expected = string.Join(" ", expectedPotentials);
            Assert.AreEqual(expected, cell.Potentials);
            return this;
        }

        public void AndActual(string expected)
        {
            var cell = _world.CellFinder.FromNinerAndCellId(_ninerId, _cellId);
            Assert.AreEqual(expected, cell.Actual);
        }

        public void AndActual(int expected) { AndActual(expected.ToString()); }
    }
}