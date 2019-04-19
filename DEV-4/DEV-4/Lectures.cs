using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DEV_4
{
    /// <summary>
    /// This class is needed to store materials of lecture.
    /// </summary>
    class Lectures : Identifier         //This can contains seminars and laboratory classes
    {                                   //Also it has some specific fields as URL, lection format
        protected string lecture_name;
        public string lecture_text;
        protected string URL;
        protected string lection_format;
        protected int number_of_seminars;
        protected int number_of_classes;
        public List<Seminars> ListOfSeminars = new List<Seminars>();
        public List<LaboratoryClasses> ListOfLaboratoryClasses = new List<LaboratoryClasses>();

        /// <summary>
        /// Constructor which fills class fields from .txt document. lectures should not exist without discipline.
        /// </summary>
        /// <param name="LectureName">name of lecture .txt file</param>
        /// <param name="NameOfDiscipline">name of discipline to which this lecture applies</param>
        public Lectures(string LectureName, string NameOfDiscipline)
        {
            StreamReader reader = new StreamReader(LectureName);
            string partLine = string.Empty;
            StringBuilder text = new StringBuilder();
            StringBuilder url = new StringBuilder();
            StringBuilder description = new StringBuilder();

            description.AppendLine($"Description of lecture: \nDiscipline: {NameOfDiscipline}");

            partLine = reader.ReadLine();                               // Read from .txt and add to partLine.
            if (partLine != null)
            {
                url.Append($"https://Something.com/ {NameOfDiscipline}/{partLine}");
                description.AppendLine($"Name of lecture: {partLine}");
                lecture_name = partLine;
                URL = url.ToString();
                description.AppendLine($"URL: {URL}");
            }
            while (partLine != null)
            {
                if (partLine != null)
                {
                    text.AppendLine(partLine);
                }
                partLine = reader.ReadLine();
            }
            reader.Close();
            lecture_text = text.ToString();

            GUID = GUID.RandomGUID();
            description.AppendLine($"GUID: {GUID}");

            Random random = new Random(DateTime.Now.Millisecond);
            Format f;
            f = (Format)random.Next(0, 3);                        //The format is random
            lection_format = Convert.ToString(f);
            description.AppendLine($"Format: {lection_format}");

            description.AppendLine($"Number of seminars: {number_of_seminars}");
            description.AppendLine($"Number of classes: {number_of_classes}");

            Description = description.ToString();
        }

        /// <summary>
        /// Add a seminar from .txt file to field "ListOfSeminars"
        /// </summary>
        /// <param name="name_of_seminar">name of seminar .txt file</param>
        public void AddSeminarToLecture(string name_of_seminar)
        {
            ListOfSeminars.Add(new Seminars(name_of_seminar, lecture_name));
            Description = Description.Replace($"Number of seminars:{Convert.ToString(number_of_seminars)}", $"Number of seminars:{Convert.ToString(number_of_seminars + 1)}");
            number_of_seminars++;
        }

        /// <summary>
        /// Add a laboratory classes from .txt file to field "ListOfLaboratoryClasses"
        /// </summary>
        /// <param name="name_of_classes">name of classes .txt file</param>
        public void AddLabClassesToLecture(string name_of_classes)
        {
            ListOfLaboratoryClasses.Add(new LaboratoryClasses(name_of_classes, lecture_name));
            Description = Description.Replace(Convert.ToString(number_of_classes), Convert.ToString(number_of_classes + 1));
            number_of_classes++;
        }

        public Lectures()
        {
        }

        /// <summary>
        /// deep cloning of Lectures object
        /// </summary>
        public object Clone() 
        {
            Lectures clone = new Lectures();
            clone.lecture_name = this.lecture_name;
            clone.lecture_text = this.lecture_text;
            clone.URL = this.URL;
            clone.lection_format = this.lection_format;
            clone.number_of_seminars = this.number_of_seminars;
            clone.number_of_classes = this.number_of_classes;
            clone.ListOfSeminars = this.ListOfSeminars;
            clone.ListOfLaboratoryClasses = this.ListOfLaboratoryClasses;
            clone.GUID = this.GUID;
            clone.Description = this.Description;

            return clone;
        }
    }
}
