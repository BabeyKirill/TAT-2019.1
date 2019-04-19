using System;

namespace DEV_3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            double budget = 0;
            double team_productivity = 0;
            int criterion = 0;

            while (criterion != 1 && criterion != 2 && criterion != 3)          //Team recruitment criteria
            {
                Console.WriteLine("Choose criterion: 1 - max productivity, 2 - min cost, 3 - max productivity without Juniors");
                Console.Write("criterion = ");
                Int32.TryParse(Console.ReadLine(), out criterion);
                if (criterion != 1 && criterion != 2 && criterion != 3)
                    Console.WriteLine("You can enter only a number from 1 to 3, try again.");
            }

            switch (criterion)                           //Criterion selection menu
            {
                case 1:
                    while (budget <= 0)
                    {
                        Console.WriteLine("Set a budget: ");
                        Console.Write("budget = ");
                        Double.TryParse(Console.ReadLine(), out budget);
                        if (budget == 0)
                            Console.WriteLine("Characters and letters are not allowed, try again.");
                    }
                    FirstCriteriaChooser first_criteria_team = new FirstCriteriaChooser();
                    first_criteria_team.GetEmployees(budget, team_productivity);
                    first_criteria_team.Show_result();
                    break;
                case 2:
                    while (team_productivity <= 0)
                    {
                        Console.WriteLine("Enter the required team productivity: ");
                        Console.Write("productivity = ");
                        Double.TryParse(Console.ReadLine(), out team_productivity);
                        if (team_productivity == 0)
                            Console.WriteLine("Characters and letters are not allowed, try again.");
                    }
                    SecondCriteriaChooser second_criteria_team = new SecondCriteriaChooser();
                    second_criteria_team.GetEmployees(budget, team_productivity);
                    second_criteria_team.Show_result();
                    break;
                case 3:
                    while (team_productivity <= 0)
                    {
                        Console.WriteLine("Enter the required team productivity: ");
                        Console.Write("productivity = ");
                        Double.TryParse(Console.ReadLine(), out team_productivity);
                        if (team_productivity == 0)
                            Console.WriteLine("Characters and letters are not allowed, try again.");
                    }
                    ThirdCriteriaChooser third_criteria_team = new ThirdCriteriaChooser();
                    third_criteria_team.GetEmployees(budget, team_productivity);
                    third_criteria_team.Show_result();
                    break;
            }
        }
    }
}
