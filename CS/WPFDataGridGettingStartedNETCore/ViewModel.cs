using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using WPFDataGridGettingStartedNETCore.Models;

namespace WPFDataGridGettingStartedNETCore {
    public class ViewModel : ViewModelBase {
        NorthwindEntities northwindDBContext;
        public ViewModel() {
            if (IsInDesignMode) {
                Orders = new ObservableCollection<Order>();
                Shippers = new ObservableCollection<Shipper>();
            }
            else {
                northwindDBContext = new NorthwindEntities();

                northwindDBContext.Orders.Load();
                Orders = northwindDBContext.Orders.ToObservableCollection();

                northwindDBContext.Shippers.Load();
                Shippers = northwindDBContext.Shippers.ToObservableCollection();
            }
            ValidateAndSaveCommand = new DelegateCommand(ValidateAndSave);
        }
        public ObservableCollection<Order> Orders {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }
        public ObservableCollection<Shipper> Shippers {
            get => GetValue<ObservableCollection<Shipper>>();
            private set => SetValue(value);
        }
        public DelegateCommand ValidateAndSaveCommand { get; }
        void ValidateAndSave() {
            northwindDBContext.SaveChanges();
        }
    }
}
