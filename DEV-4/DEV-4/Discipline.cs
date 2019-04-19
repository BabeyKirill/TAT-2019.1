using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// This class is needed to store materials for a particular discipline.
    /// </summary>
    class Discipline : Identifier
    { 
        protected string name_of_discipline;
        protected int number_of_lectures;
        public List<Lectures> ListOfLectures;
        private StringBuilder description = new StringBuilder();

        /// <summary>
        /// Constructor for class Discipline.
        /// </summary>
        /// <param name="NameOfDiscipline">Fills class field "name_of_discipline"</param>
        public Discipline(string NameOfDiscipline)   
        {       
            name_of_discipline = NameOfDiscipline;
            description.AppendLine($"Description of Discipline: \nDiscipline: {name_of_discipline}");
            GUID = GUID.RandomGUID();
            description.AppendLine($"GUID: {GUID}");
            description.AppendLine($"Number of lectures: {number_of_lectures}");
            Description = description.ToString();
        }

        public Discipline()
        {
        }

        /// <summary>
        /// Add a lection from .txt file to field "ListOfLectures"
        /// </summary>
        /// <param name="name_of_lecture">name of lecture .txt file</param>
        public void AddLectureToDiscipline(string name_of_lecture)
        {
            ListOfLectures = new List<Lectures>();
            ListOfLectures.Add(new Lectures(name_of_lecture, name_of_discipline));
            Description = Description.Replace(Convert.ToString(number_of_lectures), Convert.ToString(number_of_lectures+1));
            number_of_lectures++;
        }

        /// <summary>
        /// Add an existing Lectures object to field "ListOfLectures"
        /// </summary>
        /// <param name="existing_object_of_lectures">name of existing object of Lectures</param>
        public void AddLectureToDiscipline(Lectures existing_object_of_lectures)
        {
            ListOfLectures = new List<Lectures>();
            ListOfLectures.Add(existing_object_of_lectures);
            Description = Description.Replace(Convert.ToString(number_of_lectures), Convert.ToString(number_of_lectures + 1));
            number_of_lectures++;
        }

        /// <summary>
        /// Search lecture by GUID in list of lectures of Discipline and return
        /// </summary>
        /// <param name="guid">Guid</param>
        public Lectures ReturnLectureWithGUID(string guid)               
        {
            foreach(Lectures lect in ListOfLectures)
            {
                if(lect.GUID == guid)
                {
                    return lect;
                }
            }
            return null;
        }
        
        /// <summary>
        /// deep cloning of Discipline object
        /// </summary>
        public object Clone()          
        {
            Discipline clone = new Discipline();
            clone.name_of_discipline = this.name_of_discipline;
            clone.GUID = this.GUID;
            clone.ListOfLectures = this.ListOfLectures;
            clone.Description = this.Description;
            clone.number_of_lectures = this.number_of_lectures;

            return clone;
        }
    }
}
