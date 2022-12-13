using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using Prism.Mvvm;
using WpfCU_MVVM.Model;

namespace WpfCU_MVVM.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private string[] args;
        private StringBuilder stringBuilder = new StringBuilder();
        private ObservableCollection<WordUse> _wordCollection = new ObservableCollection<WordUse>();
        public ObservableCollection<WordUse> WordCollection
        {
            get => _wordCollection;
            set => SetProperty(ref _wordCollection, value);
        }
        public ICollectionView WordCollectionView { get; private set; }
        public MainViewModel(string[] args)
        {
            this.args = args;
            if(args!= null && args.Length > 0)
            {
                ReadText(args[0]);
            }
        }
        private void ReadText(string path)
        {
            stringBuilder.Clear();
            using (StreamReader file = new StreamReader(path))
            {
                int counter = 0;
                string ln;
                
                while ((ln = file.ReadLine()) != null)
                {
                    stringBuilder.Append(" ");
                    stringBuilder.Append(ln);
                    counter++;
                }
                file.Close();
                Console.WriteLine($"File has {counter} lines.");
            }
            var words = stringBuilder.ToString().Split();
        }
    }
}
