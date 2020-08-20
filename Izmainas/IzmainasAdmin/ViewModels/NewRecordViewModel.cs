using Caliburn.Micro;
using IzmainasAdmin.Commands;
using IzmainasAdmin.Models;
using IzmainasAdmin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IzmainasAdmin.ViewModels
{
    public class NewRecordViewModel : Screen, INotifyPropertyChanged
    {
        //private readonly IRecordService _recordService;
        private readonly IRecordTempService _recordTempService;
        private readonly IWindowManager _windowManager;

        private string _teacher;
        private string _room;
        private string _note;
        private string _lessons;
        private DateTime _date;
        private string _selectedNumber;
        private string _selectedLetter;

        //
        public ICommand Command { get; set; }
        //

        public NewRecordViewModel(IRecordTempService recordTempService, IWindowManager windowManager)
        {
            _recordTempService = recordTempService;
            _windowManager = windowManager;

            Date = DateTime.Today;
            SelectedNumber = "-";
            SelectedLetter = "-";

            //
            Command = new RelayCommand(executemethod, canexecutemethod);
            LessonList = new List<string>();
            //
        }

        //
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ResetFields();
        }

        private bool canexecutemethod(object parameter)
        {
            return true;
        }

        private void executemethod(object parameter)
        {
            var values = (object[])parameter;
            string name = (string)values[0];
            bool check = (bool)values[1];
            if (check)
            {
                LessonList.Add(name);
            }
            else
            {
                LessonList.Remove(name);
            }

            var rawList = new List<int>();

            foreach (string l in LessonList)
            {
                int lesson = int.Parse(l);
                rawList.Add(lesson);
            }

            rawList.Sort();

            Lessons = "";
            foreach (int item in rawList)
            {
                string l = item.ToString();
                Lessons += l;
                Lessons += "., ";
                
            }
        }

        private List<string> _lessonList;

        public List<string> LessonList
        {
            get { return _lessonList; }
            set 
            { 
                _lessonList = value;
                NotifyOfPropertyChange(() => LessonList);
                NotifyOfPropertyChange(() => Lessons);
            }
        }

        //

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
            LessonList.Clear();

            OneChecked = TwoChecked = ThreeChecked = FourChecked =
                FiveChecked = SixChecked = SevenChecked = EightChecked =
                NineChecked = TenChecked = ElevenChecked = TwelveChecked = false;
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
                Lessons = Lessons.Substring(0, Lessons.Length - 2);

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
                await _recordTempService.PostRecord(record);
                ResetFields();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Checkboxes

        private bool _one;

        public bool OneChecked
        {
            get { return _one; }
            set { _one = value; NotifyOfPropertyChange(() => OneChecked); }
        }

        private bool _two;

        public bool TwoChecked
        {
            get { return _two; }
            set { _two = value; NotifyOfPropertyChange(() => TwoChecked); }
        }

        private bool _three;

        public bool ThreeChecked
        {
            get { return _three; }
            set { _three = value; NotifyOfPropertyChange(() => ThreeChecked); }
        }

        private bool _four;

        public bool FourChecked
        {
            get { return _four; }
            set { _four = value; NotifyOfPropertyChange(() => FourChecked); }
        }

        private bool _five;

        public bool FiveChecked
        {
            get { return _five; }
            set { _five = value; NotifyOfPropertyChange(() => FiveChecked); }
        }

        private bool _six;

        public bool SixChecked
        {
            get { return _six; }
            set { _six = value; NotifyOfPropertyChange(() => SixChecked); }
        }

        private bool _seven;

        public bool SevenChecked
        {
            get { return _seven; }
            set { _seven = value; NotifyOfPropertyChange(() => SevenChecked); }
        }

        private bool _eight;

        public bool EightChecked
        {
            get { return _eight; }
            set { _eight = value; NotifyOfPropertyChange(() => EightChecked); }
        }

        private bool _nine;

        public bool NineChecked
        {
            get { return _nine; }
            set { _nine = value; NotifyOfPropertyChange(() => NineChecked); }
        }

        private bool _ten;

        public bool TenChecked
        {
            get { return _ten; }
            set { _ten = value; NotifyOfPropertyChange(() => TenChecked); }
        }

        private bool _eleven;

        public bool ElevenChecked
        {
            get { return _eleven; }
            set { _eleven = value; NotifyOfPropertyChange(() => ElevenChecked); }
        }

        private bool _twelve;

        public bool TwelveChecked
        {
            get { return _twelve; }
            set { _twelve = value; NotifyOfPropertyChange(() => TwelveChecked); }
        }

        #endregion
    }
}
