using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Client.Clients;

namespace Client.ViewModel
{    
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IServerClient serverClient;

        public MainViewModel(IServerClient _serverClient)
        {            
            serverClient = _serverClient;

            Calculate = new RelayCommand<string>(async(currency) => await CalculateExecute().ConfigureAwait(false), (currency) => String.IsNullOrEmpty(this[nameof(Currency)]));
        }

        #region Commands

        public RelayCommand<string> Calculate { get; private set; }

        private async Task CalculateExecute()
        {
            this.Result = "Processing...";

            this.Result = await serverClient.CurrencyToWord(Convert.ToDecimal(Currency)).ConfigureAwait(false);
        }

        #endregion

        #region Binding property

        private string _currency;
        public string Currency
        {
            get { return _currency; }
            set
            {                
                _currency = value;
                Calculate.RaiseCanExecuteChanged();
                RaisePropertyChanged(nameof(Currency));                
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        #endregion

        #region IDataErrorInfo implementation

        public string Error
        {
            get
            {
                return null;
            }
        }

        private readonly Regex _currencyValidation = new Regex("^\\d{1,9}(,\\d{1,2})?$", RegexOptions.Compiled);

        public string this[string columnName]
        {
            get
            {                
                if(columnName == nameof(Currency))
                {
                    decimal value;
                    if(!decimal.TryParse(Currency, out value) || !_currencyValidation.IsMatch(Currency))
                    {
                        return "Invalid number format!";
                    }
                }

                return null;
            }
        }

        #endregion
    }
}