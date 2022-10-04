using System;
using System.Collections.ObjectModel;

namespace HierarchicalDataTemplateMode {
    public class ViewModel {
        public ObservableCollection<ProjectObject> DataItems { get; set; }

        public ViewModel() {
            DataItems = InitData();
        }

        private ObservableCollection<ProjectObject> InitData() {
            ObservableCollection<ProjectObject> projects = new ObservableCollection<ProjectObject>();
            ProjectObject betaronProject = new ProjectObject() { Name = "Project: Betaron" };
            ProjectObject stantoneProject = new ProjectObject() { Name = "Project: Stanton" };

            InitBetaronProjectData(betaronProject);
            InitStantoneProjectData(stantoneProject);

            projects.Add(betaronProject);
            projects.Add(stantoneProject);

            return projects;
        }

        void InitBetaronProjectData(ProjectObject betaronProject) {
            betaronProject.Executor = "Mcfadyen Ball";

            ProjectStage stage21 = new ProjectStage() { Name = "Information Gathering", Executor = "Kaiden Savastano", Owner = betaronProject };
            stage21.Tasks.Add(new Task() { Name = "Market research", Executor = "Carmine Then", StartDate = new DateTime(2021, 10, 1), EndDate = new DateTime(2021, 10, 5), State = States.DataSource[2], Owner = stage21 });
            stage21.Tasks.Add(new Task() { Name = "Making specification", Executor = "Seto Kober", StartDate = new DateTime(2021, 10, 5), EndDate = new DateTime(2021, 10, 10), State = States.DataSource[1], Owner = stage21 });

            ProjectStage stage22 = new ProjectStage() { Name = "Planning", Executor = "Manley Difrancesco", Owner = betaronProject };
            stage22.Tasks.Add(new Task() { Name = "Documentation", Executor = "Martez Gollin", StartDate = new DateTime(2021, 10, 15), EndDate = new DateTime(2021, 10, 16), State = States.DataSource[0], Owner = stage22 });

            ProjectStage stage23 = new ProjectStage() { Name = "Design", Executor = "Clint Mary", Owner = betaronProject };
            stage23.Tasks.Add(new Task() { Name = "Design of a web pages", Executor = "Gasper Hartsell", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage23 });
            stage23.Tasks.Add(new Task() { Name = "Pages layout", Executor = "Shirish Huminski", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage23 });

            ProjectStage stage24 = new ProjectStage() { Name = "Development", Executor = "Edwin Thone", Owner = betaronProject };
            stage24.Tasks.Add(new Task() { Name = "Design", Executor = "Zarko Knill", StartDate = new DateTime(2021, 10, 27), EndDate = new DateTime(2021, 10, 28), State = States.DataSource[0], Owner = stage24 });
            stage24.Tasks.Add(new Task() { Name = "Coding", Executor = "Harley Kirckof", StartDate = new DateTime(2021, 10, 29), EndDate = new DateTime(2021, 10, 30), State = States.DataSource[0], Owner = stage24 });

            ProjectStage stage25 = new ProjectStage() { Name = "Testing and Delivery", Executor = "Boucher Hislop", Owner = betaronProject };
            stage25.Tasks.Add(new Task() { Name = "Testing", Executor = "Sarah Ragas", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage25 });
            stage25.Tasks.Add(new Task() { Name = "Content", Executor = "Rashid Terinoni", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage25 });

            betaronProject.Stages.Add(stage21);
            betaronProject.Stages.Add(stage22);
            betaronProject.Stages.Add(stage23);
            betaronProject.Stages.Add(stage24);
            betaronProject.Stages.Add(stage25);
        }

        void InitStantoneProjectData(ProjectObject stantoneProject) {
            stantoneProject.Executor = "Ruben Ackerman";

            ProjectStage stage11 = new ProjectStage() { Name = "Information Gathering", Executor = "Huyen Trinklein", Owner = stantoneProject };
            stage11.Tasks.Add(new Task() { Name = "Market research", Executor = "Tanner Crittendon", StartDate = new DateTime(2021, 10, 1), EndDate = new DateTime(2021, 10, 5), State = States.DataSource[2], Owner = stage11 });
            stage11.Tasks.Add(new Task() { Name = "Making specification", Executor = "Carmine Then", StartDate = new DateTime(2021, 10, 5), EndDate = new DateTime(2021, 10, 10), State = States.DataSource[2], Owner = stage11 });

            ProjectStage stage12 = new ProjectStage() { Name = "Planning", Executor = "Alfredo Sookoo", Owner = stantoneProject };
            stage12.Tasks.Add(new Task() { Name = "Documentation", Executor = "Gorf Wobbe", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[2], Owner = stage12 });

            ProjectStage stage13 = new ProjectStage() { Name = "Design", Executor = "Saphire Plump", Owner = stantoneProject };
            stage13.Tasks.Add(new Task() { Name = "Design of a web pages", Executor = "Dominic Minden", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[1], Owner = stage13 });
            stage13.Tasks.Add(new Task() { Name = "Pages layout", Executor = "Pinkerton Trezise", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[1], Owner = stage13 });

            ProjectStage stage14 = new ProjectStage() { Name = "Development", Executor = "Lauren Partain", Owner = stantoneProject };
            stage14.Tasks.Add(new Task() { Name = "Design", Executor = "Delilah Beamer", StartDate = new DateTime(2021, 10, 23), EndDate = new DateTime(2021, 10, 24), State = States.DataSource[1], Owner = stage14 });
            stage14.Tasks.Add(new Task() { Name = "Coding", Executor = "Dunaway Dupriest", StartDate = new DateTime(2021, 10, 25), EndDate = new DateTime(2021, 10, 26), State = States.DataSource[0], Owner = stage14 });

            ProjectStage stage15 = new ProjectStage() { Name = "Testing and Delivery", Executor = "Christos Arrant", Owner = stantoneProject };
            stage15.Tasks.Add(new Task() { Name = "Testing", Executor = "Grice Ohora", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage15 });
            stage15.Tasks.Add(new Task() { Name = "Content", Executor = "Christos Arrant", StartDate = new DateTime(2021, 10, 13), EndDate = new DateTime(2021, 10, 14), State = States.DataSource[0], Owner = stage15 });

            stantoneProject.Stages.Add(stage11);
            stantoneProject.Stages.Add(stage12);
            stantoneProject.Stages.Add(stage13);
            stantoneProject.Stages.Add(stage14);
            stantoneProject.Stages.Add(stage15);
        }
    }
}