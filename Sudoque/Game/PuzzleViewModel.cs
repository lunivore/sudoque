using System;
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
        private readonly ICommand _numberRequestCommand;
        private readonly ICommand _newGameRequestCommand;
        private readonly ICommand _playGameRequestCommand;
        private readonly IEnumerable<IEnumerable<NinerViewModel>> _niners;

        public PuzzleViewModel(ICreateNinerViewModels ninerViewModelFactory, IEventAggregator events)
        {
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

            var range = new[] { 0, 1, 2 }.ToList();
            var tempNiners = new List<List<NinerViewModel>>();
            foreach(var row in range)
            {
                tempNiners.Add(new List<NinerViewModel>());
                foreach (var col in range)
                {
                    tempNiners[row].Add(ninerViewModelFactory.Create(col, row));
                }
            }
            _niners = tempNiners;

        }

        public bool GameCreated { get; private set; }

        public IEnumerable<IEnumerable<NinerViewModel>> Niners
        {
            get { return _niners; }
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