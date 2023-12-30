using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeTableProject.TimeTableGenerator
{
    [Serializable]
    public class Gene
    {
        public int[] SlotNum { get; set; }
        public int Days { get; set; } = InputData.DaysPerWeek;
        public int Hours { get; set; } = InputData.HoursPerDay;

        Random rand = new Random();

        public Gene() { }

        public Gene(int index)
        {
            bool[] flag = new bool[Days * Hours];

            SlotNum = new int[Days * Hours];

            for (int j = 0; j < Days * Hours; j++)
            {
                int rnd;
                while (flag[rnd = rand.Next(Days * Hours)] == true) { }
                flag[rnd] = true;
                SlotNum[j] = index * Days * Hours + rnd;
            }

        }

        public Gene DeepClone()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Gene>(jsonString);
        }

    }
}
