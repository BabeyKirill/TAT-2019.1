using System;

namespace DEV_3
{
    class SecondCriteriaChooser : TeamBuilder                   //Makes a team according to the minimum cost criterion.
    {
        public override void GetEmployees(double budget, double productivity)
        {          
            int list_position = 0;

            foreach (Employee empl in listEmpl)
            {
                if (empl.Productivity <= productivity)
                {
                    team_cost += empl.Salary;
                    productivity -= empl.Productivity;
                    team_productivity += empl.Productivity;
                    matched_Employees.Add(empl);
                }
                else
                {
                    if (list_position < listEmpl.Count - 1)
                        if (productivity >= listEmpl[list_position + 1].Productivity)
                        {
                            team_cost += empl.Salary;
                            productivity -= empl.Productivity;
                            team_productivity += empl.Productivity;
                            matched_Employees.Add(empl);
                        }
                }
                list_position++;
            }

            if (listEmpl.Count != matched_Employees.Count && productivity > 0)
            {
                team_cost += listEmpl[listEmpl.Count - 1].Salary;
                matched_Employees.Add(listEmpl[listEmpl.Count - 1]);
                productivity -= listEmpl[listEmpl.Count - 1].Productivity;
                team_productivity += listEmpl[listEmpl.Count - 1].Productivity;
            }

            if (productivity > 0)
                Console.WriteLine("Company have not enough employers. All we can offer is: ");
        }
    }
}
