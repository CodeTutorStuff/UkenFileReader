using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkenFileReader
{
    static class CountNums
    {
        public static int MostFrequentNumSmall(string fileName)
        {
            //Commented out code is for debugging
            List<int> uniqueNums = new List<int>();
            List<int> numAmt = new List<int>();

            using (StreamReader file = new StreamReader("..\\src\\" + fileName))
            {
                //int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    int i = int.Parse(ln);

                    if (!uniqueNums.Contains(i))
                    {
                        uniqueNums.Add(i);
                        numAmt.Add(1);
                    }
                    else
                    {
                        numAmt[uniqueNums.IndexOf(i)] += 1;
                    }

                    //Console.WriteLine(ln);
                    //counter++;
                }
                file.Close();
                //Console.WriteLine($"File has {counter} lines.");
                //Console.WriteLine($"File has {uniqueNums.Count} unique nums.");

                int finalNum = 0;
                int finalIndex = 0;
                for (int i = 0; i < uniqueNums.Count; i++)
                {
                    //Console.WriteLine(uniqueNums[i] + " shows up " + numAmt[i] + " times");
                    if (numAmt[i] > finalNum)
                    {
                        finalIndex = i;
                        finalNum = numAmt[i];
                    }
                    else if (numAmt[i] == finalNum)
                    {
                        if (uniqueNums[i] < uniqueNums[finalIndex])
                        {
                            finalIndex = i;
                        }
                    }
                }
                //Console.WriteLine(uniqueNums[finalIndex] + " shows up the most at " + finalNum + " times");
                return uniqueNums[finalIndex];
            }
        }
    }
}
