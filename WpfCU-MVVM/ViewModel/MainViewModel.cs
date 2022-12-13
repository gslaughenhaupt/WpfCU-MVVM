using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.TextFormatting;
using Prism.Mvvm;
using WpfCU_MVVM.Model;

namespace WpfCU_MVVM.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private string[] args;
        HashSet<string> wordHash = new HashSet<string>();
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
                ParseText(ReadText(args[0]));
                WordCollectionView = CollectionViewSource.GetDefaultView(WordCollection);
                WordCollectionView.SortDescriptions.Add(new SortDescription(nameof(WordUse.Count), ListSortDirection.Ascending));
            }
        }
        private string ReadText(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();
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
            return stringBuilder.ToString();
        }
        private void ParseText(string text)
        {
            var words = text.Trim().Split();
            foreach(var word in words)
            {
                AddWord(word);
            }
        }
        private void AddWord(string word)
        {
            if(wordHash.Contains(word))
            {
                //TODO: update count in collection
            }
            else
            {
                wordHash.Add(word);
                WordUse wordUse = new WordUse();
                wordUse.Word = word;
                wordUse.Count = 1;
                WordCollection.Add(wordUse);
            }                
        }
    }
}
