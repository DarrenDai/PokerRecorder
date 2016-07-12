using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PokerRecorder
{
    class MainViewModel : NotifyPropertyChangedObject
    {
        #region 私有字段

        private ObservableCollection<Poker> _pokers = new ObservableCollection<Poker>();
        private ObservableCollection<Poker> _leftPokers = new ObservableCollection<Poker>();

        #endregion

        #region 构造函数

        public MainViewModel()
        {
            Initialize();
            NewCommand = new DelegateCommand(() => { Initialize(); });
            ClickedCommand = new DelegateCommand(SetLeftPokers);
        }

        #endregion

        #region 公开属性

        public ObservableCollection<Poker> LeftPorkers
        {
            get { return _leftPokers; }
            set { _leftPokers = value; OnPropertyChanged("LeftPorkers"); }
        }

        public ObservableCollection<Poker> Pokers
        {
            get { return _pokers; }
            set
            {
                _pokers = value;
                OnPropertyChanged("Pokers");
            }
        }

        #endregion

        #region 命令

        public ICommand NewCommand { get; set; }

        public ICommand ClickedCommand { get; set; }

        #endregion

        #region 命令处理方法

        private void SetLeftPokers()
        {
            {
                LeftPorkers.Clear();
                foreach (var item in Pokers.Where(x => !x.IsChecked))
                {
                    LeftPorkers.Add(item);
                }
            }
        }

        #endregion

        #region 私有方法

        private void Initialize()
        {
            Pokers.Clear();
            string[] dic = { "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "1", "2" };
            Pokers.Add(new Poker() { Name = "B", Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/B.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.BigJoker });
            Pokers.Add(new Poker() { Name = "S", Image = new BitmapImage(new Uri(@"/PokerRecorder;component/Images/Pokers/S.jpg", UriKind.RelativeOrAbsolute)), Type = TypeEnum.LittleJoker });

            for (int i = dic.Length - 1; i >= 0; i--)
            {
                Pokers.Add(new Poker()
                {
                    Name = dic[i],
                    Image = new BitmapImage(new Uri(string.Format(@"/PokerRecorder;component/Images/Pokers/B{0}.jpg", dic[i]), UriKind.RelativeOrAbsolute)),
                    Type = TypeEnum.BlackHeart
                });
                Pokers.Add(new Poker()
                {
                    Name = dic[i],
                    Image = new BitmapImage(new Uri(string.Format(@"/PokerRecorder;component/Images/Pokers/A{0}.jpg", dic[i]), UriKind.RelativeOrAbsolute)),
                    Type = TypeEnum.RedHeart
                });
                Pokers.Add(new Poker()
                {
                    Name = dic[i],
                    Image = new BitmapImage(new Uri(string.Format(@"/PokerRecorder;component/Images/Pokers/C{0}.jpg", dic[i]), UriKind.RelativeOrAbsolute)),
                    Type = TypeEnum.Flower
                });
                Pokers.Add(new Poker()
                {
                    Name = dic[i],
                    Image = new BitmapImage(new Uri(string.Format(@"/PokerRecorder;component/Images/Pokers/D{0}.jpg", dic[i]), UriKind.RelativeOrAbsolute)),
                    Type = TypeEnum.Rect
                });
            }

            SetLeftPokers();
        }

        #endregion
    }
}
