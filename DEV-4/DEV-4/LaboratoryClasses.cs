using System.Text;
using System.IO;

namespace DEV_4
{
    /// <summary>
    /// This class contains materials of laborotory classes
    /// </summary>
    class LaboratoryClasses : Identifier
    {
        protected string classes_name;
        protected string classes_text;

        /// <summary>
        /// Constructor which fills class fields from .txt document. laboratory classes should not exist without lecture.
        /// </summary>
        /// <param name="ClassesName">name of laboratory classes .txt file</param>
        /// <param name="LectionName">name of lecture to which this classes applies</param>
        public LaboratoryClasses(string ClassesName, string LectionName) 
        { 
            StreamReader reader = new StreamReader(ClassesName);
            string partLine = string.Empty;
            StringBuilder text = new StringBuilder();
            StringBuilder description = new StringBuilder();

            partLine = reader.ReadLine();                          // Read from .txt and add to partLine.
            if (partLine != null)
            {
                classes_name = partLine;
                description.AppendLine($"Description of {classes_name}: \nRefers to the lecture: {LectionName}");
            }

            while (partLine != null)
            {
                if (partLine != null)
                {
                    text.AppendLine(partLine);
                }
                partLine = reader.ReadLine();
            }
            classes_text = text.ToString();
            reader.Close();

            GUID = GUID.RandomGUID();
            description.AppendLine($"GUID: {GUID}");

            Description = description.ToString();
        }

        public LaboratoryClasses()
        {
        }

        /// <summary>
        /// deep cloning of LaboratoryClasses object
        /// </summary>
        public object Clone()                                        
        {
            LaboratoryClasses clone = new LaboratoryClasses();
            clone.classes_name = this.classes_name;
            clone.classes_text = this.classes_text;
            clone.GUID = this.GUID;
            clone.Description = this.Description;
            return clone;
        }
    }
}

