using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

public class GameViewModel : INotifyPropertyChanged
{
    private readonly GameModel _gameModel;
    private string _resultText;
    private BitmapImage _computerChoiceImage;

    public string ResultText
    {
        get => _resultText;
        set
        {
            _resultText = value;
            OnPropertyChanged(nameof(ResultText));
        }
    }

    public BitmapImage ComputerChoiceImage
    {
        get => _computerChoiceImage;
        set
        {
            _computerChoiceImage = value;
            OnPropertyChanged(nameof(ComputerChoiceImage));
        }
    }

    public ICommand PlayCommand { get; }

    public GameViewModel()
    {
        _gameModel = new GameModel();
        PlayCommand = new RelayCommand(PlayGame);
    }

    private void PlayGame(object parameter)
    {
        string playerChoice = parameter.ToString();
        string computerChoice = _gameModel.GetComputerChoice();
        string result = _gameModel.DetermineWinner(playerChoice, computerChoice);

        ResultText = result;
        ComputerChoiceImage = new BitmapImage(new Uri(GetImageForChoice(computerChoice), UriKind.Relative));
    }

    private string GetImageForChoice(string choice)
    {
        return choice switch
        {
            "Камень" => "Images/rock.png",
            "Ножницы" => "Images/scissors.png",
            "Бумага" => "Images/paper.png",
            _ => "Images/rock.png"
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
