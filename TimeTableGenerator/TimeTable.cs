namespace TimeTableProject.TimeTableGenerator
{
    public class TimeTable
    {
        public static Slot[] Slot { get; set; }

        public TimeTable() 
        {
            int k = 0;
            int subjectsCount = 0;
            int hourscount = 1;
            int days = InputData.DaysPerWeek;
            int hours = InputData.HoursPerDay;
            int studentGroupsCount = InputData.StudentGroupsCount;

            Slot = new Slot[hours * days * studentGroupsCount];

            for (int i = 0; i < studentGroupsCount; i++)
            {
                subjectsCount = 0;
                for (int j = 0; j < hours * days; j++)
                {
                    StudentGroup sg = InputData.StudentGroup[i];
                    if (subjectsCount >= sg.SubjectsCount)
                    {
                        Slot[k++] = null;
                    }
                    else
                    {
                        Slot[k++] = new Slot(sg, sg.TeacherId[subjectsCount], sg.Subject[subjectsCount]);
                        if (hourscount < sg.Hours[subjectsCount])
                        {
                            hourscount++;
                        }
                        else
                        {
                            hourscount = 1;
                            subjectsCount++;
                        }

                    }

                } 
            }
        }

        public static Slot[] returnSlots()
        {
            return Slot;
        }

    }
}
