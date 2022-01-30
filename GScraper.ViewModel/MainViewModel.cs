using GScraper.Common;
using GScraper.Common.Model;
using GScraper.ViewModel.Command;
using System;

namespace GScraper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ISearchDataProvider searchDataProvider, ITermParser termParser)
        {
            LoadCommand = new DelegateCommand(Load);
            this.searchDataProvider = searchDataProvider;
            this.termParser = termParser;
        }
   
        private readonly ISearchDataProvider searchDataProvider;
        private readonly ITermParser termParser;
        private SearchViewModel searchModel;

        public SearchViewModel SearchViewModel
        {
            get => searchModel;
            set
            {
                if (searchModel != value)
                {
                    searchModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand LoadCommand { get; }
      
        public void Load()
        {
            var searchData = searchDataProvider.Load();
            SearchViewModel = new SearchViewModel(searchData, searchDataProvider,termParser);
        }
    }
}
