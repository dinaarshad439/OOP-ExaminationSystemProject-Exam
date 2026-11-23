namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Option = 0;
            bool Valid = false;
            do
            {
                Console.WriteLine("Enter Type of Exam ( 1 for Practical, 2 for Final )");
                Valid = int.TryParse(Console.ReadLine(), out Option);

            } while (!Valid || (Option != 1 && Option != 2));



            int minutes;
            do
            {
                Console.WriteLine("Enter Exam Time (30 to 180 minutes):");

                Valid = int.TryParse(Console.ReadLine(), out minutes);

            } while (!Valid || minutes < 30 || minutes > 180);

            TimeSpan time = TimeSpan.FromMinutes(minutes);


            int numOfQuestion = 0;
            do 
            { 
               Console.WriteLine("Please Enter Number of Questions:");
               Valid=int.TryParse(Console.ReadLine(),out numOfQuestion);

            }while(!Valid || numOfQuestion <= 0);
            


            Subject s = new Subject();
            Console.Clear();
            s.ExamCreation(Option, time, numOfQuestion);



        }
    }
}
