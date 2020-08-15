using Caliburn.Micro;
using IzmainasAdmin.Models;
using IzmainasAdmin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IzmainasAdmin.ViewModels
{
    public class RecordsViewModel : Screen
    {
        private readonly IRecordService _recordService;
        private readonly IWindowManager _windowManager;

        private readonly NewRecordViewModel _newRecordView;
        private BindingList<Record> _records;

        public RecordsViewModel(IRecordService recordService, IWindowManager windowManager, NewRecordViewModel newRecordView)
        {
            _recordService = recordService;
            _windowManager = windowManager;
            _newRecordView = newRecordView;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadRecords(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task LoadRecords()
        {
            var records = await _recordService.GetAll();
            Records = new BindingList<Record>(records);
            /*
            Records = new BindingList<Record>
            {
                new Record
                {
                    Id = Guid.NewGuid(),
                    Teacher = "karmena",
                    Room = "219",
                    Note = "test test test",
                    ClassNumber = "11",
                    ClassLetter = "D",
                    Lessons = "5,7",
                    Date = DateTime.Today
                },
                new Record
                {
                    Id = Guid.NewGuid(),
                    Teacher = "viktor",
                    Room = "69",
                    Note = "tudey wi lorn tu plej poker",
                    ClassNumber = "8",
                    ClassLetter = "F",
                    Lessons = "1",
                    Date = DateTime.Today
                },
                new Record
                {
                    Id = Guid.NewGuid(),
                    Teacher = "dachi",
                    Room = "75",
                    Note = "test test test",
                    ClassNumber = "12",
                    ClassLetter = "A",
                    Lessons = "8,9",
                    Date = DateTime.Today
                }
            };
            */
        }

        public BindingList<Record> Records
        {
            get { return _records; }
            set
            {
                _records = value;
                NotifyOfPropertyChange(() => Records);
            }
        }

        public async Task AddNew()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.Title = "Jauns Ieraksts";

            await _windowManager.ShowDialogAsync(_newRecordView, null, settings);
            try
            {
                await LoadRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
