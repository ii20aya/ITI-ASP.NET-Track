namespace day04
{
    class Program
    {
        static void Main()
        {
            #region Complex + Counter
            //Complex c1 = new Complex();
            //Complex c2 = new Complex(5, 6);
            //Complex c3 = new Complex(7);

            //Console.WriteLine(c1.Print());
            //Console.WriteLine(c2.Print());
            //Console.WriteLine(c3.Print());

            //Console.WriteLine("Total Objects = " + Complex.GetCounter());
            #endregion

            #region Composition Line & Rectangle
            Line l1 = new Line(1, 2, 3, 4);
            Console.WriteLine(l1.PrintLine());

            Rectangle r1 = new Rectangle(1, 2, 5, 6);
            Console.WriteLine(r1.PrintRect());
            #endregion

            #region Aggregation Triangle & Circle
            Point p1 = new Point(1, 2);
            Point p2 = new Point(3, 4);
            Point p3 = new Point(5, 6);

            Triangle t1 = new Triangle(p1, p2, p3);
            Console.WriteLine(t1.PrintTri());

            Circle c = new Circle();
            c.SetCenter(p1);
            c.SetRadius(10);
            Console.WriteLine(c.PrintCircle());
            #endregion
        }
    }
}