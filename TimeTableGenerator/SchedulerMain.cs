using Microsoft.AspNetCore.Components.Forms;

namespace TimeTableProject.TimeTableGenerator
{
    public class SchedulerMain
    {
        List<Chromosome> firstlist;
        List<Chromosome> newlist;
        double firstlistfitness;
        double newlistfitness;
        int populationsize = 1000;
        int maxgenerations = 100;

        public static Chromosome FinalSon;

        public SchedulerMain()
        {
            new TimeTable();
            initialisePopulation();
            createNewGenerations();
        }

        public void createNewGenerations()
        {

            Chromosome father = null;
            Chromosome mother = null;
            Chromosome son = null;
            int generationsCount = 0;

            while (generationsCount < maxgenerations)
            {

                newlist = new List<Chromosome>();
                newlistfitness = 0;
                int i = 0;

                for (i = 0; i < populationsize / 10; i++)
                {
                    newlist.Add(firstlist[i].DeepClone());
                    newlistfitness += firstlist[i].getFitness();
                }

                while (i < populationsize)
                {

                    father = selectParentRoulette();
                    mother = selectParentRoulette();

                    if (new Random().NextDouble() < InputData.CrossOverrate)
                    {
                        son = crossover(father, mother);
                    }
                    else
                        son = father;

                    customMutation(son);

                    if (son.Fitness == 1)
                    {
                        break;
                    }

                    newlist.Add(son);
                    newlistfitness += son.getFitness();
                    i++;

                }

                if (i < populationsize)
                {
                    FinalSon = son;
                    break;
                }

                firstlist = newlist;
                newlist.Sort();
                firstlist.Sort();
                generationsCount++;

            }
        }

        public Chromosome selectParentRoulette()
        {

            firstlistfitness /= 10;
            double randomdouble = new Random().NextDouble() * firstlistfitness;
            double currentsum = 0;
            int i = 0;

            while (currentsum <= randomdouble)
            {
                currentsum += firstlist[i++].getFitness();
            }
            return firstlist[--i].DeepClone();

        }

        public void customMutation(Chromosome c)
        {

            double newfitness = 0, oldfitness = c.getFitness();
            int geneno = new Random().Next(InputData.StudentGroupsCount);

            int i = 0;
            while (newfitness < oldfitness)
            {
                c.gene[geneno] = new Gene(geneno);
                newfitness = c.getFitness();
                
                i++;
                if (i >= 500000) break;
            }

        }

        public Chromosome crossover(Chromosome father, Chromosome mother)
        {

            int randomint = new Random().Next(InputData.StudentGroupsCount);
            Gene temp = father.gene[randomint].DeepClone();
            father.gene[randomint] = mother.gene[randomint].DeepClone();
            mother.gene[randomint] = temp;
            if (father.getFitness() > mother.getFitness()) return father;
            else return mother;

        }

        public void initialisePopulation()
        {
            firstlist = new List<Chromosome>();
            firstlistfitness = 0;

            for (int i = 0; i < populationsize; i++)
            {

                Chromosome c;
                firstlist.Add(c = new Chromosome());
                firstlistfitness += c.Fitness;

            }
            firstlist.Sort();

        }

        public Chromosome selectParentBest(List<Chromosome> list)
        {

            Random r = new Random();
            int randomint = r.Next(100);
            return list[randomint].DeepClone();

        }

        public void mutation(Chromosome c)
        {
            int geneno = new Random().Next(InputData.StudentGroupsCount);
            int temp = c.gene[geneno].SlotNum[0];
            for (int i = 0; i < InputData.DaysPerWeek * InputData.HoursPerDay - 1; i++)
            {
                c.gene[geneno].SlotNum[i] = c.gene[geneno].SlotNum[i + 1];
            }
            c.gene[geneno].SlotNum[InputData.DaysPerWeek * InputData.HoursPerDay - 1] = temp;
        }

        public void swapMutation(Chromosome c)
        {

            int geneno = new Random().Next(InputData.StudentGroupsCount);
            int slotno1 = new Random().Next(InputData.HoursPerDay * InputData.DaysPerWeek);
            int slotno2 = new Random().Next(InputData.HoursPerDay * InputData.DaysPerWeek);

            int temp = c.gene[geneno].SlotNum[slotno1];
            c.gene[geneno].SlotNum[slotno1] = c.gene[geneno].SlotNum[slotno2];
            c.gene[geneno].SlotNum[slotno2] = temp;
        }
    }
}
