namespace Polymorphism
{
    public class Animal
    {
        public virtual void eat()
        {
            Console.WriteLine("Animal eating");
        }
    }
    public class Dog : Animal
    {
        public override void eat()
        {
            Console.WriteLine("Dog eating");
        }
    }
    public class Example
    {
        public static void Main(string[] args)
        {
            Animal animal = new Dog();
            animal.eat();
        }
    }
}