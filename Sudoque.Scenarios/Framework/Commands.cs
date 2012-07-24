using Sudoque.Game;

namespace Sudoque.Scenarios.Framework
{
    public class Commands
    {
        private readonly PuzzleViewModel _viewModel;

        public Commands(PuzzleViewModel viewModel)
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
    }
}