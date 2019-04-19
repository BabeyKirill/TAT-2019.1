using System;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// This class contains fields and methods for identifying objects
    /// </summary>
    abstract class Identifier 
    {
        public string GUID { get; set; }
        public string Description { get; set; }
        private readonly int MAX_LENGTH =256;

        /// <summary>
        /// Prints a string object "Description" of object to the console.
        /// </summary>
        public override string ToString()
        {
            if (Description.Length > MAX_LENGTH)                //Object size should not exceed 256 characters.
            {
                Description = Description.Substring(MAX_LENGTH);
            }
            return Description;
        }

        /// <summary>
        /// Returns true if the object GUIDs match.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Identifier Object_of_Discipline = obj as Identifier; // returns null if the object cannot be converted to type Identifier

            if (Object_of_Discipline as Identifier == null)
            {
                return false;
            }

            return Object_of_Discipline.GUID == this.GUID;
        }
    }
}
