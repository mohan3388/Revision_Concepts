namespace ADODotNet
{
    class Program
    {
        public static void Main(string[] args)
        {
            AddressBook address = new AddressBook();
            //Model mod = new Model();
            //mod.Name = Console.ReadLine();
            //mod.Email = Console.ReadLine();
            //mod.Mobile = Console.ReadLine();
            //mod.City = Console.ReadLine();
            //address.AddContact(mod);

            List<Model> list = address.GetData();
            foreach(Model model in list)
            {
                Console.WriteLine(model.Name+" "+model.Email+" "+model.Mobile+" "+model.City);
            }

            Console.WriteLine("update users");
            //Model mod = new Model();

            int Id = Convert.ToInt32(Console.ReadLine());
            //mod.Name = Console.ReadLine();
            //mod.Email = Console.ReadLine();
            //mod.Mobile = Console.ReadLine();
            //mod.City = Console.ReadLine();
            //address.Updateuser(mod);

            address.DeleteUser(Id);
        }
       
    }
   
}