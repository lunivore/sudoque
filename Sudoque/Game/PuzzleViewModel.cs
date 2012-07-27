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
        private readonly ICommand _askForHelpCommand;
        private readonly IEnumerable<NinerViewModel> _niners;
        private string _hintText = string.Empty;

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

            _askForHelpCommand = new DelegateCommand<object>(b => events.GetEvent<HintRequestEvent>().Publish(null));

            events.GetEvent<HintProvidedEvent>().Subscribe(hint => HintText = hint.Text);
            

            var ninerModels = new List<NinerViewModel>();

            foreach (var id in Enumerable.Range(0, 9))
            {
                ninerModels.Add(ninerViewModelFactory.Create(id));
            }
            _niners = ninerModels;
        }

        public string HintText
        {
            get { return _hintText; }
            private set
            {
                _hintText = value;
                NotifyPropertyChanged(()=> HintText);
            }
        }


        public bool GameCreated { get; private set; }

        public IEnumerable<NinerViewModel> Niners
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

        public ICommand AskForHelp
        {
            get { return _askForHelpCommand; }
        }
    }
}