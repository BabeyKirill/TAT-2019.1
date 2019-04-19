using System;

namespace DEV_4
{
    class EntryPoint
    {
        static void Main(string[] args)             //Some testing commands;
        {
            Lectures lecture1 = new Lectures("../../lection1.txt", "Mathematics");
            Console.WriteLine(lecture1.lecture_text);
            Console.WriteLine(lecture1.ToString());
            Seminars fd = new Seminars("../../seminar1.txt", "Lection1");
            Console.WriteLine(fd.ToString());

            Discipline original_discipline1 = new Discipline("Mathematics");
            Console.WriteLine($"{original_discipline1.GUID}\n");
            original_discipline1.AddLectureToDiscipline("../../lection2.txt");
            original_discipline1.ListOfLectures[0].AddSeminarToLecture("../../seminar2.txt");

            Discipline discipline1_clone = (Discipline)original_discipline1.Clone();
            Console.WriteLine(discipline1_clone.ToString());
            Console.WriteLine(original_discipline1.ToString());

            Lectures original_lecture3 = new Lectures("../../lection3.txt", "Mathematics");
            original_lecture3.AddSeminarToLecture("../../seminar3.txt");
            original_lecture3.AddSeminarToLecture("../../seminar4.txt");
            original_lecture3.AddLabClassesToLecture("../../laboratory_classes2.txt");
            original_lecture3.AddLabClassesToLecture("../../laboratory_classes3.txt");
            original_lecture3.AddLabClassesToLecture("../../laboratory_classes4.txt");
            Console.WriteLine(original_lecture3.ToString());
            Lectures lecture3_clone = (Lectures)original_lecture3.Clone();
            Console.WriteLine(original_lecture3.ToString());
            Console.WriteLine(lecture3_clone.ToString());
            Console.WriteLine($"Verify that the copy equals to the original: {lecture3_clone.Equals(original_lecture3)}");

            original_discipline1.AddLectureToDiscipline(lecture1);
            original_discipline1.AddLectureToDiscipline(original_lecture3);

            Lectures lecture4 = new Lectures();
            Console.WriteLine($"\nShow lection with GUID:{original_lecture3.GUID}");
            lecture4 = original_discipline1.ReturnLectureWithGUID(original_lecture3.GUID);
            Console.WriteLine(lecture4.ToString());
            Console.WriteLine(lecture4.ListOfSeminars[0].control_questions);
            Console.WriteLine(lecture4.ListOfSeminars[0].answers);
            Console.WriteLine(lecture4.ListOfSeminars[1].control_questions);
            Console.WriteLine(lecture4.ListOfSeminars[1].answers);
        }
    }
}
