using System;

namespace DEV_3
{
    class ThirdCriteriaChooser : TeamBuilder           //Makes a team according to the criterion of maximum productivity and without juniors
    {
        public override void GetEmployees(double budget, double productivity)
        {          
            int list_position = 0;

            foreach (Employee empl in listEmpl)
            {
                if (empl.Productivity <= productivity && empl.GetType() != typeof(Junior))
                {
                    team_cost += empl.Salary;
                    productivity -= empl.Productivity;
                    team_productivity += empl.Productivity;
                    matched_Employees.Add(empl);
                }
                else
                {
                    if (list_position < listEmpl.Count - 1 && empl.GetType() != typeof(Junior))
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

            if (listEmpl.Count - junior.Length != matched_Employees.Count && productivity > 0)
            {
                team_cost += listEmpl[listEmpl.Count - 1 - junior.Length].Salary;
                matched_Employees.Add(listEmpl[listEmpl.Count - 1 - junior.Length]);
                productivity -= listEmpl[listEmpl.Count - 1 - junior.Length].Productivity;
                team_productivity += listEmpl[listEmpl.Count - 1 - junior.Length].Productivity;
            }

            if (productivity > 0)
                Console.WriteLine("Company have not enough employers. All we can offer is: ");
        }
    }
}
