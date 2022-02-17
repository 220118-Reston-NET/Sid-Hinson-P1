
namespace StoreUI
{

    interface IMenu
    {
        /// <summary>
        ///  Displays Menu for Retro Barbarian Gaming Lair
        /// </summary>
        void MenuDisplay();

        /// <summary>
        /// Grabs User Menu Selection
        /// </summary>
        /// <returns> Returns Appropriate Menu Selection</returns>
        string UserSelection();

    }

    interface ILogo
    {
        void Display();
    }

}