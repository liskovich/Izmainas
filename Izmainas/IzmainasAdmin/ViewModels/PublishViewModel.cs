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
    public class PublishViewModel : Screen
    {
        private readonly IRecordTempService _recordTempService;
        private readonly IWindowManager _windowManager;

        private BindingList<Record> _publishList;
        private Record _selectedRecord;
        private readonly NewRecordViewModel _newRecordView;

        public PublishViewModel(IRecordTempService recordTempService, IWindowManager windowManager, NewRecordViewModel newRecordView)
        {
            _recordTempService = recordTempService;
            _windowManager = windowManager;
            _newRecordView = newRecordView;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadTempRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task LoadTempRecords()
        {
            var records = await _recordTempService.GetAll();
            PublishList = new BindingList<Record>(records);
        }

        public BindingList<Record> PublishList
        {
            get { return _publishList; }
            set 
            { 
                _publishList = value;
                NotifyOfPropertyChange(() => PublishList);
            }
        }

        public Record SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                _selectedRecord = value;
                NotifyOfPropertyChange(() => SelectedRecord);
                NotifyOfPropertyChange(() => CanEdit);
                NotifyOfPropertyChange(() => CanDelete);
            }
        }

        public async Task AddNew()
        {
            try
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Jauns";

                await _windowManager.ShowDialogAsync(_newRecordView, null, settings);
                await LoadTempRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool CanEdit
        {
            get
            {
                bool output = false;
                if (SelectedRecord != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task Edit()
        {
            try
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Rediģēt";

                await _windowManager.ShowDialogAsync(new EditRecordViewModel(SelectedRecord, SaveEditChanges), null, settings);
                await LoadTempRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //
        public async Task SaveEditChanges(Record r)
        {
            try
            {
                var record = new Record
                {
                    Id = r.Id,
                    Teacher = r.Teacher,
                    Room = r.Room,
                    Note = r.Note,
                    ClassNumber = r.ClassNumber,
                    ClassLetter = r.ClassLetter,
                    Lessons = r.Lessons,
                    Date = r.Date
                };
                await _recordTempService.EditRecord(record);
                //ResetFields();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //
        public bool CanDelete
        {
            get
            {
                bool output = false;
                if (SelectedRecord != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task Delete()
        {
            try
            {
                await _recordTempService.DeleteRecord(SelectedRecord.Id);
                await LoadTempRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Publish()
        {
            try
            {
                await _recordTempService.PublishRecords();
                await LoadTempRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
