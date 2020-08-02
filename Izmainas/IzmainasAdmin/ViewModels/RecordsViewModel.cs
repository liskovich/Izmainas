using Caliburn.Micro;
using IzmainasAdmin.Models;
using IzmainasAdmin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace IzmainasAdmin.ViewModels
{
    public class RecordsViewModel : Screen
    {
        private readonly IRecordService _recordService;
        private readonly IWindowManager _windowManager;

        private BindingList<Record> _records;

        public RecordsViewModel(IRecordService recordService, IWindowManager windowManager)
        {
            _recordService = recordService;
            _windowManager = windowManager;
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

    }
}
