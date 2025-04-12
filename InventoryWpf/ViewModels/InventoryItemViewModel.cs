using InventoryWpf.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System;

namespace InventoryWpf.ViewModels
{
  public  class InventoryItemViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private InventoryItem _item = new InventoryItem();
        private string _name;
        public InventoryItem Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                ValidateName();
            }
        }

        public int StockQuantity
        {
            get => Item.StockQuantity;
            set
            {
                Item.StockQuantity = value;
                OnPropertyChanged();
                ValidateProperty(value);
            }
        }

        private void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            var context = new ValidationContext(Item) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(value, context, results))
            {
                _errors[propertyName] = results.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ValidateName()
        {
            const string prop = nameof(Name);
            if (string.IsNullOrWhiteSpace(Name))
                AddError(prop, "Name is required.");
            else
                ClearErrors(prop);
        }

       

        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public bool HasErrors => _errors.Any();
     
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
