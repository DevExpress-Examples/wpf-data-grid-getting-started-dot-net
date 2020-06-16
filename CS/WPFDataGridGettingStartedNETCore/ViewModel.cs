using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DXGridGetStartedCore.Models;

namespace DXGridGetStartedCore {
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
                Orders = northwindDBContext.Orders.ToObservableCollection<Order>();

                northwindDBContext.Shippers.Load();
                Shippers = northwindDBContext.Shippers.ToObservableCollection<Shipper>();
            }
            ValidateAndSaveCommand = new DelegateCommand(ValidateAndSave);
        }
        public ObservableCollection<Order> Orders { get; }
        public ObservableCollection<Shipper> Shippers { get; }
        public DelegateCommand ValidateAndSaveCommand { get; }
        void ValidateAndSave() {
            northwindDBContext.SaveChanges();
        }
    }
}