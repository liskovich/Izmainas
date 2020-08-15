using Caliburn.Micro;
using IzmainasAdmin.Models;
using IzmainasAdmin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IzmainasAdmin.ViewModels
{
    public class NewRecordViewModel : Screen
    {
        private readonly IRecordService _recordService;
        private readonly IWindowManager _windowManager;

        private string _teacher;
        private string _room;
        private string _note;
        private string _lessons;
        private DateTime _date;
        private string _selectedNumber;
        private string _selectedLetter;

        public NewRecordViewModel(IRecordService recordService, IWindowManager windowManager)
        {
            _recordService = recordService;
            _windowManager = windowManager;

            Date = DateTime.Today;
            SelectedNumber = "-";
            SelectedLetter = "-";
        }

        public string Teacher
        {
            get { return _teacher; }
            set 
            { 
                _teacher = value;
                NotifyOfPropertyChange(() => Teacher);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public string Room
        {
            get { return _room; }
            set 
            { 
                _room = value;
                NotifyOfPropertyChange(() => Room);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public string Note
        {
            get { return _note; }
            set 
            { 
                _note = value;
                NotifyOfPropertyChange(() => Note);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public List<string> ClassNumber
        {
            get
            {
                return new List<string>
                {
                    "7", "8", "9", "10", "11", "12", "-"
                };
            }
        }

        public string SelectedNumber
        {
            get { return _selectedNumber; }
            set 
            { 
                _selectedNumber = value;
                NotifyOfPropertyChange(() => SelectedNumber);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public List<string> ClassLetter
        {
            get
            {
                return new List<string>
                {
                    "A", "B", "C", "D", "E", "F", "SB", "-"
                };
            }
        }

        public string SelectedLetter
        {
            get { return _selectedLetter; }
            set 
            { 
                _selectedLetter = value;
                NotifyOfPropertyChange(() => SelectedLetter);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public string Lessons
        {
            get { return _lessons; }
            set
            { 
                _lessons = value;
                NotifyOfPropertyChange(() => Lessons);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set 
            { 
                _date = value;
                NotifyOfPropertyChange(() => Date);
                NotifyOfPropertyChange(() => CanAddRecord);
            }
        }

        public void ResetFields()
        {
            Teacher = "";
            Room = "";
            Note = "";
            SelectedNumber = "-";
            SelectedLetter = "-";
            Lessons = "";
            Date = DateTime.Today;
        }

        public bool CanAddRecord
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(Teacher) == false &&
                    string.IsNullOrWhiteSpace(Room) == false &&
                    string.IsNullOrWhiteSpace(Note) == false &&
                    string.IsNullOrWhiteSpace(SelectedNumber) == false &&
                    string.IsNullOrWhiteSpace(SelectedLetter) == false &&
                    string.IsNullOrWhiteSpace(Lessons) == false)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task AddRecord()
        {
            try
            {
                var record = new CreateRecord
                {
                    Teacher = Teacher,
                    Room = Room,
                    Note = Note,
                    ClassNumber = SelectedNumber,
                    ClassLetter = SelectedLetter,
                    Lessons = Lessons,
                    Date = Date
                };
                await _recordService.PostRecord(record);
                ResetFields();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
