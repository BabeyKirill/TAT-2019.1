using System;
using System.Collections.Generic;

namespace DEV_3
{
    class TeamBuilder                       //Contains the number of free employees and connected criteria classes for creating a team
    {
        protected Junior[] junior;
        protected Middle[] middle;
        protected Senior[] senior;
        protected Lead[] lead;
        protected List<Employee> listEmpl = new List<Employee>();    //A list with all free workers, which is passed to the criteria classes
        protected List<Employee> matched_Employees = new List<Employee>(); //A list with matched employees

        protected double team_cost = 0;
        protected double team_productivity = 0;

        public TeamBuilder()
        {
            junior = new Junior[10];                //Numbers of free employers in the Company
            for (int i = 0; i < junior.Length; i++)
                junior[i] = new Junior();

            middle = new Middle[7];
            for (int i = 0; i < middle.Length; i++)
                middle[i] = new Middle();

            senior = new Senior[4];
            for (int i = 0; i < senior.Length; i++)
                senior[i] = new Senior();

            lead = new Lead[2];
            for (int i = 0; i < lead.Length; i++)
                lead[i] = new Lead();

            listEmpl.AddRange(lead);               //list must be ordered by efficiency
            listEmpl.AddRange(senior);
            listEmpl.AddRange(middle);
            listEmpl.AddRange(junior);            
        }

        public virtual void GetEmployees(double budget, double team_productivity)    //This function is override by the criteria classes.
        {
            Console.WriteLine("Error, virtual function is not overrited");
        }

        public void Show_result()  //This function shows calculated  
        {                                                                                                         //team in the console.
            int[] team_composition = new int[4];
            foreach (Employee empl in matched_Employees)
            {
                if (empl.GetType() == typeof(Lead))
                    team_composition[3]++;
                if (empl.GetType() == typeof(Senior))
                    team_composition[2]++;
                if (empl.GetType() == typeof(Middle))
                    team_composition[1]++;
                if (empl.GetType() == typeof(Junior))
                    team_composition[0]++;
            }

            Console.WriteLine($"Team cost = {team_cost}; Team productivity = {team_productivity}; Team composition: Juniors = {team_composition[0]}, Middles = {team_composition[1]}, Seniors = {team_composition[2]}, Leads = {team_composition[3]}");
        }
    }
}
