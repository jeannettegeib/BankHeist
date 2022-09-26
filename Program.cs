using System;
using System.Collections.Generic;
using System.Linq;

namespace BankHeist
{ 
    public class TeamMember
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public double CourageFactor {get; set;}

        public TeamMember(string name, int skill, double courage){
            Name=name;
            SkillLevel=skill;
            CourageFactor=courage;
        }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist");
            Console.WriteLine("Type the name of your first Team Member.");
            string name = Console.ReadLine();
            Console.WriteLine("What is this person's skill level?");
            int skill = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What is this person's Courage Factor (1.0-2.0).");
            double courage =Double.Parse(Console.ReadLine());
            TeamMember FirstTeamMember = new TeamMember(name, skill, courage);
           List<TeamMember> MyTeam = new List<TeamMember>(){};
           MyTeam.Add(FirstTeamMember);

           Console.WriteLine($"You've added {FirstTeamMember.Name} to your team.");

           

            while(true){
            
            Console.WriteLine("Would you like to add a new team member? Type a another Name. Otherwise hit Enter.");
            name = Console.ReadLine();
            if (name==""){
                break;
            }
            Console.WriteLine("What is this person's skill level (1-50)?");
            skill = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What is this person's Courage Factor (1.0-2.0)?");
            courage =Double.Parse(Console.ReadLine());
            TeamMember AnotherTeamMember = new TeamMember(name, skill, courage);
            MyTeam.Add(AnotherTeamMember);
            Console.WriteLine($"You've added {AnotherTeamMember.Name} to your team.");
            Console.WriteLine($"You now have {MyTeam.Count} members on your team!");
             }

             int TotalSkill = 0;
             
             foreach(TeamMember criminal in MyTeam){
                   TotalSkill += criminal.SkillLevel;
                }

            Console.WriteLine($"You have {MyTeam.Count} members on your team with a Total skill level of {TotalSkill}.");

             Console.WriteLine("How many banks would you like to try to rob?");
             int Tries = Int32.Parse(Console.ReadLine());
                
            int Successes = 0;
            int Failures = 0;
            for (int i=0; i < Tries; i++)
            {
                int BankDifficultyLevel = new Random().Next(75, 120);
                
                int LuckValue = new Random().Next(-10, 10);
                
            
                 Console.WriteLine($"Bank #{i+1}'s difficulty level is {BankDifficultyLevel}.");
                // while(true){Console.WriteLine("Bank Robbery in process... Hit Enter to find out how it went. ");
                // string ready =Console.ReadLine();
                //     if (ready==""){
                //     break;
                //     } 
                // }
                
                int AllTold = TotalSkill + LuckValue;
                if (AllTold>BankDifficultyLevel)
                {
                    Console.WriteLine($"Heist #{i+1} was a success! Enjoy your hard earned wealth!");
                    Console.WriteLine("....");
                    Successes += 1;
                }
                else{
                   Console.WriteLine($"Heist #{i+1} was a failure! Run!");
                   Console.WriteLine("...."); 
                   Failures += 1;
                }              
              
            }
            Console.WriteLine();
           if (Successes == 0)
                {
                    Console.WriteLine("Actually, look, I hate to say this, but at this point you should just turn yourself over to the law and serve your time.");
                }
                else if (Failures == 0)
                {
                    Console.WriteLine("Wow, you're the boss. Time to do some laundry.");
                }
                else if (Successes !=0 && Successes > Failures)
                {
                    Console.WriteLine("Pay off the chief and lay low till the heat dies down.");
                }
                else if (Failures != 0 && Failures > Successes)
                {
                    Console.WriteLine("Take your cash and get out of the country quick!");
                }

        }
    }
}
