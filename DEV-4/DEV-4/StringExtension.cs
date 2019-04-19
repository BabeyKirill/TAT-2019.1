using System;

namespace DEV_4
{
    /// <summary>
    /// This class extends functionality for strings
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// return random identification code
        /// </summary>
        /// <param name="GUID">string which calls this method</param>
        public static string RandomGUID(this string GUID)        
        {
            Guid guid = Guid.NewGuid(); 
            return guid.ToString();
        }
    }
}
