using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PokerRecorder
{
    class MainViewModel : NotifyPropertyChangedObject
    {
        private ObservableCollection<Poker> _pokers = new ObservableCollection<Poker>();
        private ObservableCollection<Poker> _leftPokers = new ObservableCollection<Poker>();

        public ObservableCollection<Poker> LeftPorkers
        {
            get { return _leftPokers; }
            set { _leftPokers = value; OnPropertyChanged("LeftPorkers"); }
        }


        public MainViewModel()
        {
            Initialize();
            NewCommand = new DelegateCommand(() => { Initialize(); });
            ClickedCommand = new DelegateCommand(() =>
            {
                LeftPorkers.Clear();
                foreach (var item in Pokers.Where(x => !x.IsChecked))
                {
                    LeftPorkers.Add(item);
                }
            });
        }

        public ICommand NewCommand { get; set; }

        public ICommand ClickedCommand { get; set; }

        public ObservableCollection<Poker> Pokers
        {
            get { return _pokers; }
            set
            {
                _pokers = value;
                OnPropertyChanged("Pokers");
            }
        }

        private void Initialize()
        {
            Pokers.Clear();
            string[] dic = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            Pokers.Add(new Poker() { Name = "Big", Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.BigJoker });
            Pokers.Add(new Poker() { Name = "Small", Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.LittleJoker });

            for (int i = dic.Length - 1; i >= 0; i--)
            {
                Pokers.Add(new Poker()
                {
                    Name = dic[i],
                    Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)),
                    Type = TypeEnum.RedHeart
                });
                Pokers.Add(new Poker() { Name = dic[i], Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.BlackHeart });
                Pokers.Add(new Poker() { Name = dic[i], Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.Flower });
                Pokers.Add(new Poker() { Name = dic[i], Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/A2.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.Rect });
            }
        }
    }
}
