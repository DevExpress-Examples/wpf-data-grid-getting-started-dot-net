using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using WPFDataGridGettingStartedNETCore.Models;

namespace WPFDataGridGettingStartedNETCore {
    public class ViewModel : ViewModelBase {
        NorthwindEntities northwindDBContext;

        public ObservableCollection<Order> Orders {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }
        public ObservableCollection<Shipper> Shippers {
            get => GetValue<ObservableCollection<Shipper>>();
            private set => SetValue(value);
        }

        public ViewModel() {
            northwindDBContext = new NorthwindEntities();

            northwindDBContext.Orders.Load();
            Orders = northwindDBContext.Orders.ToObservableCollection();

            northwindDBContext.Shippers.Load();
            Shippers = northwindDBContext.Shippers.ToObservableCollection();
        }

        [Command]
        public void ValidateAndSave(RowValidationArgs args) {
            northwindDBContext.SaveChanges();
        }
    }
}
