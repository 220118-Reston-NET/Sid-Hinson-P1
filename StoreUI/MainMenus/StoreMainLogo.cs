


namespace StoreUI
{

    public class StoreMainLogo : ILogo
    {
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("================================================================================");
            Console.WriteLine("= @xxxx[{:::::::::::::::::::::::::::::> @xxxx[{:::::::::::::::::::::::::::::>  =");
            Console.WriteLine("================================================================================");
            Console.WriteLine("=   ------------ WELCOME TO RETRO BARBARIAN ONLINE GAMING LAIR -------------   =");
            Console.WriteLine("================================================================================");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("=                      **Several Stores to Choose From!**                      =");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("=    * Cool Swag  * Retro Systems * Retro Games * New Systems * New Games *    =");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("=               CSR staff to Assist Your Order :  1-505-503-4455               =");
            Console.WriteLine("=                                ===========                                   =");
            Console.WriteLine("================================================================================");
            Console.WriteLine("=  Your Home For All Things Gaming --> Retro and New | Follow Us on Instagram  =");
            Console.WriteLine("================================================================================");
            Console.WriteLine("           ↓↓↓↓   Press Enter to Access Services and Products   ↓↓↓↓            ");
            Log.Information("User is pressing enter to go to Main Program Menu");
            Console.ReadLine();


        }

    }
}