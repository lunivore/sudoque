using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Sudoque.Gui;

namespace Sudoque.Game
{
    public class PuzzleViewModel : ViewModel
    {
        private readonly ICreateNinerViewModels _ninerViewModelFactory;
        private readonly ICommand _numberRequestCommand;
        private readonly ICommand _newGameRequestCommand;
        private readonly ICommand _playGameRequestCommand;

        public PuzzleViewModel(ICreateNinerViewModels ninerViewModelFactory, IEventAggregator events)
        {
            _ninerViewModelFactory = ninerViewModelFactory;
            _numberRequestCommand = new NumberRequestCommand(events.GetEvent<NumberRequestEvent>());
            _newGameRequestCommand = new DelegateCommand<Mode>(p =>
                                                                   {
                                                                       events.GetEvent<ModeRequestEvent>().Publish(Mode.NewGame);
                                                                       GameCreated = false;
                                                                       NotifyPropertyChanged(() => GameCreated);

                                                                   });
            _playGameRequestCommand = new DelegateCommand<Mode>(p =>
                                                                    {
                                                                        events.GetEvent<ModeRequestEvent>().Publish(Mode.PlayGame);
                                                                        GameCreated = true;
                                                                        NotifyPropertyChanged(() => GameCreated);
                                                                    });
        }

        public bool GameCreated { get; private set; }

        public IEnumerable<IEnumerable<NinerViewModel>> Niners
        {
            get
            {
               return new[]{0, 1, 2}.ToList().Select(row => 
                   new[]{0, 1, 2}.ToList().Select(column => 
                       _ninerViewModelFactory.Create(column, row)));
            }
        }

        public ICommand NumberRequest
        {
            get { return _numberRequestCommand; }
        }

        public ICommand NewGameRequest
        {
            get { return _newGameRequestCommand; }
        }

        public ICommand PlayGameRequest
        {
            get { return _playGameRequestCommand; }
        }
    }
}