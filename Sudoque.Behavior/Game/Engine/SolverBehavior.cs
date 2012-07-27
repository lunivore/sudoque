using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using Moq;
using NUnit.Framework;
using Sudoque.Game;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine
{
    [TestFixture]
    public class SolverBehavior
    {
        [Test]
        public void ShouldPassOnTheHintFromTheFirstHelpfulRule()
        {
            // Given an event aggregator to which we're subscribed
            var events = new EventAggregator();
            Hint hint = null;
            events.GetEvent<HintProvidedEvent>().Subscribe(h => hint = h);

            // And one rule which fails then one which passes first time
            var unhelpfulRule = new Mock<IMightBeAbleToHelp>();
            unhelpfulRule.Setup(r => r.HelpWith(It.IsAny<NineCells>())).Returns(Hint.None);

            var expectedHint = new Hint("I can help!", new List<Cell>());
            var helpfulRule = new Mock<IMightBeAbleToHelp>();
            helpfulRule.Setup(r => r.HelpWith(It.IsAny<NineCells>())).Returns(expectedHint);

            // And a repository with some cells in it
            var repository = new Mock<ILookAfterCells>();
            repository.Setup(r => r.FetchCellsByRowColumnOrNiner()).Returns(
                new List<NineCells> {new NineCells(new Cell[0])});

            // When we publish a request for a hint
            new Solver(events, repository.Object, new[] {unhelpfulRule.Object, helpfulRule.Object});
            events.GetEvent<HintRequestEvent>().Publish(null);

            // Then the solver should publish the first helpful hint
            Assert.AreEqual(expectedHint, hint);
        }

        [Test]
        public void ShouldAskEachRuleInTurnWithNinersRowsAndColumnsUntilOnePasses()
        {
            // Given a repository with different rows, columns and niners
            var niners = new List<NineCells> { new NineCells( new[] {new Cell(new CellId(-1, -1)) } )};
            var rows = new List<NineCells> { new NineCells( new[] {new Cell(new CellId(-1, -1)) } )};
            var columns = new List<NineCells>
                              {
                                  new NineCells(new[] {new Cell(new CellId(-1, -1))} ),
                                  new NineCells(new[] {new Cell(new CellId(-1, -1))} ),
                                  new NineCells(new[] {new Cell(new CellId(-1, -1))} ),                                  
                              };
            
            var repository = new Mock<ILookAfterCells>();
            var allSequences = new[] {niners, rows, columns}.SelectMany(list => list).ToArray();
            repository.Setup(r => r.FetchCellsByRowColumnOrNiner()).Returns(allSequences);

            // And one rule which fails then one which passes first time
            var unhelpfulRule = new Mock<IMightBeAbleToHelp>();
            unhelpfulRule.Setup(r => r.HelpWith(It.IsAny<NineCells>())).Returns(Hint.None);

            var expectedHint = new Hint("I can help!", new List<Cell>());
            var helpfulRule = new Mock<IMightBeAbleToHelp>();
            helpfulRule.Setup(r => r.HelpWith(It.IsAny<NineCells>())).Returns(expectedHint);

            // When we ask the solver for a hint
            var events = new EventAggregator();
            new Solver(events, repository.Object, new[] {unhelpfulRule.Object, helpfulRule.Object});
            events.GetEvent<HintRequestEvent>().Publish(null);

            // Then the first rule should be called with each niner, row and column
            Array.ForEach(allSequences, s => unhelpfulRule.Verify(r => r.HelpWith(s)));

            // And the second should only be called once
            helpfulRule.Verify(r => r.HelpWith(It.IsAny<NineCells>()), Times.Once());
        }

        [Test]
        public void ShouldTellUsNoHintPassesIfNoRuleHelps()
        {
            // Given an event aggregator to which we're subscribed
            var events = new EventAggregator();
            Hint hint = null;
            events.GetEvent<HintProvidedEvent>().Subscribe(h => hint = h);

            // Given no rules will pass
            var repository = new Mock<ILookAfterCells>();
            
            // When we ask the solver for a hint
            new Solver(events, repository.Object, new List<IMightBeAbleToHelp>());
            events.GetEvent<HintRequestEvent>().Publish(null);

            // Then we should be told we can't be helped
            Assert.AreEqual(Hint.None, hint);
        }
    }
}
