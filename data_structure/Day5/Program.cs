namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> numbers = new DynamicArray<int>(3);

            
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40); 

            Console.WriteLine($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");

            
            numbers.Insert(2, 25); 

            
            Console.Write("Elements after Insert: ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

           
            Console.WriteLine($"Index of 25: {numbers.FirstIndexOf(25)}");
            Console.WriteLine($"Contains 100? {numbers.Contains(100)}");

            
            numbers.Reverse();
            numbers.RemoveAt(0);

            Console.Write("Elements after Reverse and RemoveAt(0): ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

           
            numbers.TrimExcess();
            Console.WriteLine($"Capacity after Trim: {numbers.Capacity}");

            numbers.Clear();
            Console.WriteLine($"Count after Clear: {numbers.Count}");

            #region Dictionary
            Console.WriteLine("Hash Table *Dictionary* Testttt");
            Dictionary<int, string> employees = new Dictionary<int, string>();

         
            employees.Add(101, "Basmalla");
          
            string name = employees[101];

           
            bool hasKey = employees.ContainsKey(101);
            bool hasValue = employees.ContainsValue("Basmalla");

            // 4. Remove
            employees.Remove(102);
            if (employees.TryGetValue(101, out string empName))
            {
                Console.WriteLine($"Found: {empName}");
            } 
            #endregion
        }
    }
}