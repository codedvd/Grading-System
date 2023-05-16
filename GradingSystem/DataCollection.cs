namespace GradingSystem
{
    class MyGrades
    {
        // Declaring the vai
        public List<string> coursCode = new();
        public List<int> coursUnit = new();
        public List<string> grade = new();
        public List<int> gradeUnit = new();
        public List<int> weiPnt = new();
        public List<string> remrk = new();
        public List<int> score = new();
        public int numbOfSub;
        public string? newCourse;

        // Rules of Program.
        public void PrintGrades()
        {
            // Rules of program.
            Console.WriteLine("--Welcome to your Grading System");
            Console.WriteLine("--Course name and Code should'nt be more then 6 figures");
            Console.WriteLine("--Scores should be between 0 - 99");
            Console.WriteLine("--Course Unit should be between 1-9 \n \n");

            // Asking the user to put in the number of subjects he would like to offer
            //int num;
            Console.Write("How many subjects do you offer? ");
            string? numInput = Console.ReadLine();
            while (!int.TryParse(numInput, out numbOfSub) || numbOfSub <= 0)
            {
                Console.Write("How many subjects do you offer? ");
                numInput = Console.ReadLine();
            }


            //if (string.IsNullOrEmpty(numbOfSub.ToString())) {
            //    Console.WriteLine("You have to input a number");
            //}
            // For loop to loop through and take in details based on the users number of subjects 
            for (int i = 0; i < numbOfSub; i++)
            {
            james:
                Console.Write("Enter Course title and code: ");
                newCourse = Console.ReadLine();
                // Trying to make sure user input is not just in numbers
                // while (!Regex.IsMatch(newCourse, @"^[A-Z]{3}\d{3}$"))
                if (int.TryParse(newCourse, out _) || newCourse == "" || newCourse.Length > 6 || newCourse.Length < 6)
                {
                    Console.WriteLine("Use format: Mat231, Edu143.. etc \n");
                    goto james;
                };
                coursCode.Add(newCourse);

                Console.Write("Enter Course Unit for: ");
                string? unitInput = Console.ReadLine();
                int Unit;
                //coursUnit.Add(Convert.ToInt32(Console.ReadLine()));
                while (!int.TryParse(unitInput, out Unit) || Unit < 1 || Unit > 5)
                {
                    Console.WriteLine("Course Unit cannot be less than 0 or greater than 5");
                    unitInput = Console.ReadLine();
                }
                coursUnit.Add(Unit);

                Console.Write("Enter your Score for: ");
                string? scoreVal = Console.ReadLine();
                int testScore;
                while (!int.TryParse(scoreVal, out testScore) || testScore < 0 || testScore > 100)
                {
                    Console.WriteLine("Score can't be less than 0 or greater than 100");
                    scoreVal = Console.ReadLine();
                }
                score.Add(testScore);
                Console.WriteLine("");
                Console.Clear();


                grade.Add(score[i] >= 70 ? "A" : score[i] >= 60 ? "B" : score[i] >= 50 ? "C" : score[i] >= 45 ? "D" : score[i] >= 40 ? "E" : "F");
                gradeUnit.Add(score[i] >= 70 ? 5 : score[i] >= 60 ? 4 : score[i] >= 50 ? 3 : score[i] >= 45 ? 2 : score[i] >= 40 ? 1 : 0);
                remrk.Add(gradeUnit[i] == 5 ? "Excellent" : gradeUnit[i] == 4 ? "Very Good" : gradeUnit[i] == 3 ? "Good" : gradeUnit[i] == 2 ? "Fair" : gradeUnit[i] == 1 ? "Pass" : "Fail");
                weiPnt.Add((int)coursUnit[i] * gradeUnit[i]);
            }
            // Top Header table for arrangement of user details.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("       |------------------|----------------|------------|--------------|--------------|-------------|");
            Console.WriteLine("       |  COURSE & CODE   |   COURSE UNIT  |    GRADE   |  GRADE-UNIT  |   WEIGHT Pt. |   REMARK    |");
            Console.WriteLine("       |------------------|----------------|------------|--------------|--------------|-------------|");
            Console.ResetColor();
            // Loop to print results per the subject counts inputed by the user
            for (int i = 0; i < numbOfSub; i++)
            {
                Console.WriteLine($"       |     {coursCode[i]}       |       {coursUnit[i]}        |     {grade[i]}      |      {gradeUnit[i]}       |      {weiPnt[i],-7} |   {remrk[i],-9} |");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("       |__________________|________________|____________|______________|______________|_____________|");
            Console.ResetColor();
            Console.WriteLine("\n");

            // GPA
            double totalCourseUnit = coursUnit.Sum();
            int totalWeigthPoint = weiPnt.Sum();
            int totalGradeunit = gradeUnit.Sum();
            double Gpa = totalWeigthPoint / totalCourseUnit;
            string GpaIn2Decimal = Gpa.ToString("F2");
            // New way of Instantiating a Constructor.
            _ = new GpaCalculator(totalCourseUnit, totalWeigthPoint, totalGradeunit, GpaIn2Decimal);
        }
    }
}
