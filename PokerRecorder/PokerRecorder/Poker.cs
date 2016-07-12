using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PokerRecorder
{
    class Poker : NotifyPropertyChangedObject
    {
        private string _name;
        private ImageSource _image;
        private TypeEnum _type;
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged("IsChecked"); }
        }


        public TypeEnum Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("Type"); }
        }

        public ImageSource Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged("Image"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
    }
}
