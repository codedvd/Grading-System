namespace GradingSystem
{
    class GpaCalculator
    {
        public double totalCourseUnit;
        public int totalWeigthPoint;
        public int totalGradeunit;
        public string GpaIn2Decimal;
        // Creating a constructor and passing it the required parameters.
        public GpaCalculator(double totalCourseUnit, int totalWeigthPoint, int totalGradeunit, string GpaIn2Decimal)
        {
            this.totalCourseUnit = totalCourseUnit;
            this.totalWeigthPoint = totalWeigthPoint;
            this.totalGradeunit = totalGradeunit;
            this.GpaIn2Decimal = GpaIn2Decimal;

            // Total course Unit registered 
            Console.WriteLine($"       Total course Unit registered: {totalCourseUnit}");

            // Total Course Unit Passed
            Console.WriteLine($"       Total Course Unit Passed: {totalGradeunit}");

            //Total Weight Point is 
            Console.WriteLine($"       Total Weight Point is: {totalWeigthPoint}");

            //GPA printed in 2dp
            Console.WriteLine($"       Your GPA is: {GpaIn2Decimal}");
        }
    }
}
