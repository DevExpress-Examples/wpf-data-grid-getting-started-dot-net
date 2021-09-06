using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WPFDataGridGettingStartedNETCore.Models;

namespace WPFDataGridGettingStartedNETCore {
	public class ViewModel : ViewModelBase {
        NorthwindEntities northwindDBContext;

        public ICollection<Order> Orders {
            get => GetValue<ICollection<Order>>();
            private set => SetValue(value);
        }
        public ICollection<Shipper> Shippers {
            get => GetValue<ICollection<Shipper>>();
            private set => SetValue(value);
        }

        public ViewModel() {
            northwindDBContext = new NorthwindEntities();

            northwindDBContext.Orders.Load();
            Orders = northwindDBContext.Orders.Local;

            northwindDBContext.Shippers.Load();
            Shippers = northwindDBContext.Shippers.Local;
        }

        [Command]
        public void ValidateAndSave(RowValidationArgs args) {
            northwindDBContext.SaveChanges();
        }
    }
}
