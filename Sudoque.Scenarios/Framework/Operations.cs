using NUnit.Framework;
using Sudoque.Game;

namespace Sudoque.Scenarios.Framework
{
    public class Operations
    {
        private readonly PuzzleViewModel _viewModel;

        public Operations(PuzzleViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void PressNumber(int digit)
        {
            _viewModel.NumberRequest.Execute(digit);
        }

        public void PlayGame()
        {
            _viewModel.PlayGameRequest.Execute(null);
        }

        public void CreateNewGame()
        {
            _viewModel.NewGameRequest.Execute(null);
        }

        public void AskForHelp()
        {
            _viewModel.AskForHelp.Execute(null);
        }

        public void HelpTextShouldBe(string text)
        {
            Assert.AreEqual(text, _viewModel.HintText);
        }
    }
}