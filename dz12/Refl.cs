using System;
using System.Reflection;


namespace dz12
{
    public class Refl
    {
    static void Main(string[] args)
        {
            Refl reflInstance = new Refl();
            Type type = reflInstance.GetType();
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        public string Output()
        {
            return "test-output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
