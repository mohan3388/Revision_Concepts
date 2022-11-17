namespace Abstraction
{
    public abstract class Shape
    {
        public abstract void draw();
    } 

    public class Ractangle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Ractangle");
        }
    }
    public class Circle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Circle");
        }
    }
    public class Test
    {
        public static void Main(string[] args)
        {
            Shape shap = new Ractangle();
            shap.draw();
            Shape shape= new Circle();
            shape.draw();
        }
    }
}