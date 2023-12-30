using System.Text.Json;
using TimeTableProject.Data;
using TimeTableProject.Dto;
using TimeTableProject.Entities;

namespace TimeTableProject.TimeTableGenerator
{
    public class InputData
    {
        public static StudentGroup[] StudentGroup { get; set; }
        public static Teacher[] Teacher { get; set; }
        public static double CrossOverrate { get; set; } = 1.0;
        public static double MutationRate { get; set; } = 0.1;
        public static int StudentGroupsCount { get; set; }
        public static int TeachersCount { get; set; }
        public static int HoursPerDay { get; set; }
        public static int DaysPerWeek { get; set; }

        private Guid _referenceId;
        private DataContext _dataContext;

        public InputData(Guid referenceId, DataContext dataContext)
        {
            _referenceId = referenceId;
            _dataContext = dataContext;
            StudentGroup = new StudentGroup[100];
            Teacher = new Teacher[100];
        }

        public void InitializeData(ScheduleDetails scheduleDetails)
        {
            HoursPerDay = scheduleDetails.ClassesPerDay;
            DaysPerWeek = scheduleDetails.Days.Where(day => day.selected == true).ToList().Count;

            Console.WriteLine("Days per week: " + DaysPerWeek);
            Console.WriteLine("Days per week: " + scheduleDetails.Days.Where(day => day.selected == true).ToList().Count);

            TimeDetails timeDetails = new TimeDetails();
            timeDetails.ReferenceId = _referenceId;
            timeDetails.SchoolStartTime = scheduleDetails.SchoolStartTime;
            timeDetails.ClassesPerDay = scheduleDetails.ClassesPerDay;
            timeDetails.ClassDuration = scheduleDetails.ClassDuration;
            timeDetails.BreakDuration = scheduleDetails.BreakDuration;
            timeDetails.Days = JsonSerializer.Serialize(scheduleDetails.Days);

            _dataContext.TimeDetails.Add(timeDetails);

            List<Batches> studentGroups = scheduleDetails.Batches;
            StudentGroupsCount = studentGroups.Count;
            int i;
            for(i = 0;i < StudentGroupsCount;i++)
            {
                StudentGroup[i] = new StudentGroup();
                StudentGroup[i].Id = i;
                StudentGroup[i].Name = studentGroups[i].ClassName;
                
                List<Subjects> subjects = studentGroups[i].Subjects;
                StudentGroup[i].SubjectsCount = subjects.Count;

                for (int j = 0;j < subjects.Count;j++)
                {
                    StudentGroup[i].Subject[j] = subjects[j].Name;
                    StudentGroup[i].Hours[j] = subjects[j].Hours;

                    BatchDetails batchDetails = new BatchDetails();
                    batchDetails.ReferenceId = _referenceId;
                    batchDetails.ClassName = studentGroups[i].ClassName;
                    batchDetails.SubjectName = subjects[j].Name;
                    batchDetails.Hours = subjects[j].Hours;

                    _dataContext.BatchDetals.Add(batchDetails);
                }
            }

            List<Teachers> teachers = scheduleDetails.Teachers;
            TeachersCount = teachers.Count;
            for(i = 0;i < teachers.Count;i++)
            {
                Teacher[i] = new Teacher();
                Teacher[i].Id = i;
                Teacher[i].Name = teachers[i].Name;
                Teacher[i].Subject = teachers[i].Subject;

                TeacherDetails teacherDetails = new TeacherDetails();
                teacherDetails.ReferenceId = _referenceId;
                teacherDetails.Name = teachers[i].Name;
                teacherDetails.Subject = teachers[i].Subject;

                _dataContext.TeacherDetails.Add(teacherDetails);
            }

            AssignTeacher();
        }

        public void AssignTeacher()
        {
            for (int i = 0; i < StudentGroupsCount; i++)
            {
                for (int j = 0; j < StudentGroup[i].SubjectsCount; j++)
                {
                    int teacherid = -1;
                    int assignedmin = -1;
                    string subject = StudentGroup[i].Subject[j];

                    for (int k = 0; k < TeachersCount; k++)
                    {
                        if (Teacher[k].Subject.Equals(subject))
                        {
                            if (assignedmin == -1)
                            {
                                assignedmin = Teacher[k].Assigned;
                                teacherid = k;
                            }

                            else if (assignedmin > Teacher[k].Assigned)
                            {
                                assignedmin = Teacher[k].Assigned;
                                teacherid = k;
                            }
                        }
                    }
                    Teacher[teacherid].Assigned++;
                    StudentGroup[i].TeacherId[j] = teacherid;
                }
            }
        }

    }
}
