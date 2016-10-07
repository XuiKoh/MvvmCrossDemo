using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {

        private ObservableCollection<Unit> unitCodes = new ObservableCollection<Unit>()
        {
            new Unit("IAB330","MobileAppDevelopement") ,
            new Unit() { UserLocation="IAB230",UserName="UbiquitousComputing"}
        };
        public ObservableCollection<Unit> UnitCodes
        {
            get { return unitCodes; }
            set { SetProperty(ref unitCodes, value); }
        }
        private string unitCode;
        public string UnitCode
        {
            get { return unitCode; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref unitCode, value); 
                }
            }
        }

        private string unitName;
        public string UnitName
        {
            get { return unitName; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref unitName, value);
                }
            }
        }


        public ICommand ButtonCommand { get; private set; }
        public ICommand SelectUnitCommand { get; private set; }
        public FirstViewModel()
        {
            ButtonCommand = new MvxCommand(() =>
            {
                AddUnit(new Unit(UnitCode, UnitName));
                RaisePropertyChanged(()=>UnitCodes);
            });

            SelectUnitCommand = new MvxCommand<Unit>(unit => 
            {
                UnitCode = unit.UserLocation;
                UnitName = unit.UserName;
            });
        }

        public void AddUnit(Unit unit)
        {
            if (unit.UserLocation != null && unit.UserName != null)
            {
                if (unit.UserName.Trim() != string.Empty && unit.UserLocation.Trim() != string.Empty)
                {
                    UnitCodes.Add(unit);
                }
                else
                {
                    UnitName = UnitName.Trim();
                    UnitCode = UnitCode.Trim();
                }
            }
        }
    }
}
