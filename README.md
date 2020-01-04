# IfConditions
Say Good Bye to Multiple If Else Code . 
If Condition use dictionary/Map to store conditions as Keys &amp; single statement as values.

## Usage/Example

``` C#
namespace Demo
{
    class Program
    {
        private static StringCondition status_Code = new StringCondition()
        {
            { "200","OK" },
            { "201","CREATED" },
            { "202","ACCEPTED" },
            { "400","BAD REQUEST" },
            { "401","UNAUTHORIZED" },
            { "403","FORBIDDEN" },
            { "404","NOT FOUND" }
        };

        private static Condition<int, string> status_Code_generic = new Condition<int, string>()
        {
            { 200,"OK" },
            { 201,"CREATED" },
            { 202,"ACCEPTED" },
            { 400,"BAD REQUEST" },
            { 401,"UNAUTHORIZED" },
            { 403,"FORBIDDEN" },
            { 404,"NOT FOUND" }
        };

        private static Condition<int, IObject> xyz = new Condition<int, IObject>()
        {
            { 1,new ObjectA() },
            { 2,new ObjectB()}
        };


        private static BoolCondition Grades = new BoolCondition()
        {
            { "[Marks] > 90","A" },
            { "[Marks] > 80","B+" },
            { "[Marks] > 70","C" },
            { "[Marks] > 60","D" },
            { "[Marks] > 50","Pass" },
            { "[Marks] < 50","Fail" } //In This Case it is Else Condtion
        };

        interface IObject
        {
            void Show();
        }
        class ObjectA : IObject
        {
            public void Show()
            {
                Console.WriteLine("Inside " + this);
            }
        }
        class ObjectB : IObject
        {
            public void Show()
            {
                Console.WriteLine("Inside " + this);
            }
        }

        static void Main(string[] args)
        {
            //String Condition Example (No Else Value Provided)
            //In case of null, "Key Not Found" will be printed!
            Console.WriteLine("Enter Value");
            Console.WriteLine(status_Code.Find(Console.ReadLine()));
            Console.WriteLine();

            //String Condition Example (No Else Value Provided)
            Console.WriteLine("Enter Value");
            Console.WriteLine(status_Code.Find(Console.ReadLine(), "My Error"));
            Console.WriteLine();

            //Generic Condition Example (No Else Value Provided)
            //In case of null, Nothing  will be printed!
            Console.WriteLine("Enter Value");
            Console.WriteLine(status_Code_generic.Find(Convert.ToInt32(0)));
            Console.WriteLine();

            //Generic Condition Example (Else Value Provided)
            Console.WriteLine("Enter Value");
            Console.WriteLine(status_Code_generic.Find(Convert.ToInt32(0), "No Key Match!"));
            Console.WriteLine();

            //Bool Condition Example
            Console.WriteLine("Enter Value");
            Console.WriteLine(Grades.Find("Marks", Convert.ToDouble(100)));
            Console.WriteLine();

            //Interface Condition Example
            xyz.Find(2).Show();
            Console.WriteLine();
        }
    }
}
```

