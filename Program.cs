using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file
{
    public struct Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string[] Actors;

    }
    class Program
    {

        static void Main(string[] args)
        {
            Film f1 = new Film();
            f1.Name = string.Empty;
            f1.Year = 0;
            f1.Duration = 0;
            f1.Actors = new string[2];

            string path = @"E:\job\Brain Academy\test\data.csv";
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;  

                while ((line = sr.ReadLine()) != null)
                {
                    string[] fileFilms = line.Split(new char[] { ';' });
                    string actors = string.Empty;

                    for (int i = 0; i < fileFilms.Length; i++)
                    {
                        actors = "";
                        f1.Name = fileFilms[0];
                        f1.Year = Convert.ToInt32(fileFilms[1]);
                        f1.Duration = int.Parse(fileFilms[2]);
                        f1.Actors = fileFilms[3].Split(',');

                        actors = string.Join(",", f1.Actors);                        
                    }  

                    Console.WriteLine(@"Film: {0}
Year: {1}
Duration: {2} minutes
Actors: {3} ", f1.Name, f1.Year, f1.Duration, actors);                    
                    Console.WriteLine(); 
                }
                Console.ReadLine();
            }
        }
    }
}

