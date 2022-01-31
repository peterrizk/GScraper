using GScraper.Common;
using GScraper.Common.Model;
using GScraper.ViewModel.Command;
using System;
using System.Linq;
using System.Text;

namespace GScraper.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel(SearchModel searchModel, ISearchDataProvider searchDataProvider, ITermParser termParser)
        {
            SearchCommand = new DelegateCommand(Search, () => CanSearch);
            this.searchModel = searchModel;
            this.searchDataProvider = searchDataProvider;
            this.termParser = termParser;
        }

        public DelegateCommand SearchCommand { get; }

        private readonly SearchModel searchModel;
        private readonly ISearchDataProvider searchDataProvider;
        private readonly ITermParser termParser;

        public string SearchTerm
        {
            get => searchModel.Terms;
            set
            {
                if (searchModel.Terms != value)
                {
                    searchModel.Terms = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSearch));
                    RaisePropertyChanged(nameof(Uri));
                    SearchCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string CountTerm
        {
            get => searchModel.CountTerm;
            set
            {
                if (searchModel.CountTerm != value)
                {
                    searchModel.CountTerm = value;
                }
            }
        }

        public int PageSize
        {
            get => searchModel.PageSize;
            set
            {
                if (searchModel.PageSize != value)
                {
                    searchModel.PageSize = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSearch));
                    RaisePropertyChanged(nameof(Uri));
                    SearchCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Uri
        {
            get {
                if(searchModel.Uri != null)
                {
                    var uriBuilder = new UriBuilder(searchModel.Uri);
                    uriBuilder.Path = searchModel.Path;
                    uriBuilder.Query = $"?{searchModel.PageSizeQs}={searchModel.PageSize}&{searchModel.TermsQs}={searchModel.Terms}";
                    return uriBuilder.ToString(); 
                }
                return string.Empty;
            }
        }

        private string results;

        public string Results
        {
            get => results;
            set
            {
                if (results != value)
                {
                    results = value;
                }
            }
        }


        public bool CanSearch => !string.IsNullOrEmpty(SearchTerm) && PageSize > 0;

        public void Search()
        {
            Results = searchDataProvider.Search(Uri,CountTerm,termParser)
                .Aggregate(new StringBuilder(), (sb,i)=> sb.Append($"{i} "), sb => sb.ToString());
            RaisePropertyChanged(nameof(Results));
        }

    }
}
