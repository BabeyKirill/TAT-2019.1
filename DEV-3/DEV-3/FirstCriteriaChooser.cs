namespace DEV_3
{
    class FirstCriteriaChooser : TeamBuilder                 //Makes a team according to the criterion of maximum productivity
    {
        public override void GetEmployees(double budget, double productivity)
        {
            foreach (Employee empl in listEmpl)
            {
                if (empl.Salary <= budget)
                {
                    budget -= empl.Salary;
                    team_cost += empl.Salary;
                    team_productivity += empl.Productivity;
                    matched_Employees.Add(empl);
                }
            }
        }
    }
}
