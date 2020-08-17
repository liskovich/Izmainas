using Caliburn.Micro;
using IzmainasAdmin.Models;
using IzmainasAdmin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IzmainasAdmin.ViewModels
{
    public class EditRecordViewModel : Screen
    {
        private readonly IRecordService _recordService;
        private readonly IRecordTempService _recordTempService;

        private readonly Record _record;

        private System.Action<Record> _saveChanges;

        private string _teacher;
        private string _room;
        private string _note;
        private string _selectedNumber;
        private string _selectedLetter;
        private string _lessons;
        private DateTime _date;

        public EditRecordViewModel(Record record, System.Action<Record> saveChanges, IRecordTempService recordTempService = null, IRecordService recordService = null)
        {
            _record = record;
            _recordTempService = recordTempService;
            _recordService = recordService;

            _saveChanges = saveChanges;

            Teacher = record.Teacher;
            Room = record.Room;
            Note = record.Note;
            SelectedNumber = record.ClassNumber;
            SelectedLetter = record.ClassLetter;
            Lessons = record.Lessons;
            Date = record.Date;
        }

        public string Teacher
        {
            get { return _teacher; }
            set
            {
                _teacher = value;
                NotifyOfPropertyChange(() => Teacher);
                NotifyOfPropertyChange(() => CanEditRecord);
            }
        }

        public string Room
        {
            get { return _room; }
            set
            {
                _room = value;
                NotifyOfPropertyChange(() => Room);
                NotifyOfPropertyChange(() => CanEditRecord);
            }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                NotifyOfPropertyChange(() => Note);
                NotifyOfPropertyChange(() => CanEditRecord);
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
                NotifyOfPropertyChange(() => CanEditRecord);
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
                NotifyOfPropertyChange(() => CanEditRecord);
            }
        }

        public string Lessons
        {
            get { return _lessons; }
            set
            {
                _lessons = value;
                NotifyOfPropertyChange(() => Lessons);
                NotifyOfPropertyChange(() => CanEditRecord);
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
                NotifyOfPropertyChange(() => CanEditRecord);
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

        public void Return()
        {
            Teacher = _record.Teacher;
            Room = _record.Room;
            Note = _record.Note;
            SelectedNumber = _record.ClassNumber;
            SelectedLetter = _record.ClassLetter;
            Lessons = _record.Lessons;
            Date = _record.Date;
        }

        public bool CanEditRecord
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

        public async Task EditRecord()
        {
            try
            {
                var record = new Record
                {
                    Id = _record.Id,
                    Teacher = Teacher,
                    Room = Room,
                    Note = Note,
                    ClassNumber = SelectedNumber,
                    ClassLetter = _selectedLetter,
                    Lessons = Lessons,
                    Date = Date
                };
                await _recordTempService.EditRecord(record);
                ResetFields();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
