namespace day06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Human Test ");

            //Male m1 = new Male("ahmed");
            //m1.SayName();

            //Female f1 = new Female("aya");
            //f1.SayName();

            //Human h1 = new Male("Youssef");
            //h1.SayName();

            Console.WriteLine("\n Area Test - Wrong Way");

            Rect[] rarr =
            {
                new Rect(3,4),
                new Rect(2,5)
            };

            Square[] sarr =
            {
                new Square(5)
            };

            Tri[] tarr =
            {
                new Tri(3,4)
            };

            Circle[] carr =
            {
                new Circle(7)
            };

            Console.WriteLine("Total Area (Wrong Way) = "
                + Utility.SumOfAreas(rarr, sarr, tarr, carr));

            Console.WriteLine("\n Area Test - Correct Way ");

            Geoshape[] shapes =
            {
                new Rect(3,4),
                new Rect(2,5),
                new Square(5),
                new Tri(3,4),
                new Circle(7)
            };

            Console.WriteLine("Total Area (Correct Way) = "
                + Utility.SumOfAreasV2(shapes));
        }
    }
}