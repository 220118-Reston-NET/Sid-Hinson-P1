namespace StoreUI
{
    public class AdminValidate
    {
        private string _password = "8675309";
        public bool ValidateAdminPassword()
        {
            Console.WriteLine("Enter Password");
            string userinput = Console.ReadLine();
            if (userinput.Equals(_password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
