using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SampleLibrary.Models
{
    public partial class Contacts : INotifyPropertyChanged
    {
        private string _firstName;

        public Contacts()
        {
            Customers = new HashSet<Customers>();
        }

        [Key]
        public int ContactId { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName { get; set; }

        [InverseProperty("Contact")]
        public virtual ICollection<Customers> Customers { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
