using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeTableProject.TimeTableGenerator
{
    [Serializable]
    public class Chromosome: IComparable<Chromosome>
    {
        static double CrossOverrate { get; set; } = InputData.CrossOverrate;
        static double MutationRate { get; set; } = InputData.MutationRate;
        public static int Hours { get; set; } = InputData.HoursPerDay;
        public static int Days { get; set; } = InputData.DaysPerWeek;
        static int StudentGroupCount { get; set; } = InputData.StudentGroupsCount;
        public double Fitness { get; set; }
        public int Point { get; set; }

        public Gene[] gene { get; set; }

        public Chromosome()
        {
            gene = new Gene[StudentGroupCount];
            for (int i = 0; i < StudentGroupCount; i++)
            {
                gene[i] = new Gene(i);
            }
            Fitness = getFitness();
        }

        public Chromosome DeepClone()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Chromosome>(jsonString);
        }

        public double getFitness()
        {
            Point = 0;
            for (int i = 0; i < Hours * Days; i++)
            {
                List<int> teacherlist = new List<int>();
                for (int j = 0; j < StudentGroupCount; j++)
                {
                    Slot slot;
                    if (TimeTable.Slot[gene[j].SlotNum[i]] != null)
                        slot = TimeTable.Slot[gene[j].SlotNum[i]];
                    else slot = null;

                    if (slot != null)
                    {
                        if (teacherlist.Contains(slot.TeacherId))
                        {
                            Point++;
                        }
                        else teacherlist.Add(slot.TeacherId);
                    }
                }


            }
            Fitness = 1 - (Point / ((StudentGroupCount - 1.0) * Hours * Days));
            Point = 0;
            return Fitness;
        }


        public int CompareTo(Chromosome c)
        {
            if (Fitness == c.Fitness) return 0;
            else if (Fitness > c.Fitness) return -1;
            else return 1;
        }
    }
}
