using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Client.ViewModel
{    
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {        
        public MainViewModel()
        {
            Calculate = new RelayCommand<string>((currency) => CalculateExecute(currency), (currency) => true);
        }

        #region Commands

        public ICommand Calculate { get; private set; }

        private void CalculateExecute(string currency)
        {             
             this.Result = "Hello!";
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