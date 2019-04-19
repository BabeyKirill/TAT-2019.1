using System.Text;
using System.IO;

namespace DEV_4
{
    /// <summary>
    /// This class is needed to store materials of Seminars.
    /// </summary>
    class Seminars : Identifier                 
    {
        public string Tasks { get; set; }
        public string ControlQuestions { get; set; }
        public string Answers { get; set; }
        public string NameOfSeminar { get; set; }
        private StringBuilder _Description = new StringBuilder();
        /// <summary>
        /// Constructor which fills class fields from .txt document. Seminars should not exist without lecture.
        /// </summary>
        /// <param name="SeminarName">name of seminar .txt file</param>
        /// <param name="LectureName">name of lecture to which this seminar applies</param>
        public Seminars(string NameOfSeminar)      
        {
            this.NameOfSeminar = NameOfSeminar;
            _Description.AppendLine($"Description of seminar:\nName: {NameOfSeminar}");
            GUID = GUID.RandomGUID();
            _Description.AppendLine($"GUID: {GUID}");
        }

        public void AddMaterials(string NameOfFile)
        {
            StreamReader reader = new StreamReader($"../../{NameOfFile}.txt");
            string partLine = string.Empty;
            StringBuilder text = new StringBuilder();
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
        }

        /// <summary>
        /// deep cloning of Seminars object
        /// </summary>
        public object Clone()
        {
            Seminars clone = new Seminars(this.Tasks, this.ControlQuestions, this.Answers);
            clone.tasks = this.tasks;
            clone.control_questions = this.control_questions;
            clone.answers = this.answers;
            clone.GUID = this.GUID;
            clone.Description = this.Description;
            return clone;
        }
    }
}
