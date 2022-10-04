using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HierarchicalDataTemplateMode {
    public class BaseObject : INotifyPropertyChanged {
        string nameCore;
        public string Name {
            get { return nameCore; }
            set {
                if (Name == value)
                    return;
                nameCore = value;
                OnPropertyChanged("Name");
            }
        }

        String executorCore;
        public String Executor {
            get { return executorCore; }
            set {
                if (ReferenceEquals(Executor, value))
                    return;
                executorCore = value;
                OnPropertyChanged("Executor");
            }
        }

        public override string ToString() {
            return Name;
        }

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        ProgressingObject ownerCore;
        public ProgressingObject Owner {
            get { return ownerCore; }
            set {
                if(ReferenceEquals(Owner, value))
                    return;
                ownerCore = value;
                OnPropertyChanged("Owner");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ProgressingObject : BaseObject {
        int progressCore;

        public virtual void UpdateProgress() { }
        
        public int Progress {
            get { return progressCore; }
            set {
                if(ReferenceEquals(Progress, value))
                    return;
                progressCore = value;
                OnPropertyChanged("Progress");
                if(Owner != null)
                    Owner.UpdateProgress();
            }
        }
    }

    public class ProjectObject : ProgressingObject {
        public ProjectObject() {
            Stages = new ObservableCollection<ProjectStage>();
            Stages.CollectionChanged += (s, e) => { this.UpdateProgress(); };
        }
        public ObservableCollection<ProjectStage> Stages { get; set; }
        public override void UpdateProgress() {
            int completed = 0, sum = 0;
            
            if(Stages != null)
                foreach(ProjectStage stage in Stages) {
                    sum++;
                    if(stage.Progress >= 100)
                        completed++;
                }
            if(sum == 0)
                Progress = 100;
            else
                Progress = completed * 100 / sum;
        }
    }

    public class ProjectStage : ProgressingObject {
        public ProjectStage() {
            Tasks = new ObservableCollection<Task>();
            Tasks.CollectionChanged += (s, e) => { this.UpdateProgress(); };
        }

        public override void UpdateProgress() {
            int completed = 0, sum = 0;

            if(Tasks != null)
                foreach(Task task in Tasks) {
                    sum++;
                    if(task.State == null || task.State.StateValue == 2)
                        completed++;
                }
            if(sum == 0)
                Progress = 100;
            else
                Progress = completed * 100 / sum;
        }

        public ObservableCollection<Task> Tasks { get; set; }
    }

    public class Task : BaseObject {
        DateTime startDateCore;
        public DateTime StartDate {
            get { return startDateCore; }
            set {
                if (StartDate == value)
                    return;
                startDateCore = value;
                OnPropertyChanged("StartDate");
            }
        }
        DateTime endDateCore;
        public DateTime EndDate {
            get { return endDateCore; }
            set {
                if (EndDate == value)
                    return;
                endDateCore = value;
                OnPropertyChanged("EndDate");
            }
        }
        State stateCore;
        public State State {
            get { return stateCore; }
            set {
                if(ReferenceEquals(State, value))
                    return;
                stateCore = value;
                OnPropertyChanged("State");
                if(Owner != null)
                    Owner.UpdateProgress();
            }
        }
    }

    public class State : IComparable {
        public ImageSource Image { get; set; }
        public string TextValue { get; set; }
        public int StateValue { get; set; }
        public override string ToString() {
            return TextValue;
        }

        public int CompareTo(object obj) {
            return Comparer<int>.Default.Compare(StateValue, ((State)obj).StateValue);
        }
    }

    public class States : List<State> {
        static List<State> src;
        public ImageSource Image { get; set; }
        public static List<State> DataSource {
            get {
                if (src == null) {
                    src = new List<State>();
                    src.Add(new State() { TextValue = "Not started", StateValue = 0, Image = new BitmapImage(new Uri("/HierarchicalDataTemplateMode;component/Images/State_NotStarted.png", UriKind.Relative)) });
                    src.Add(new State() { TextValue = "In progress", StateValue = 1, Image = new BitmapImage(new Uri("/HierarchicalDataTemplateMode;component/Images/State_InProgress.png", UriKind.Relative)) });
                    src.Add(new State() { TextValue = "Completed", StateValue = 2, Image = new BitmapImage(new Uri("/HierarchicalDataTemplateMode;component/Images/State_Completed.png", UriKind.Relative)) });
                }
                return src;
            }
        }
    }
}
