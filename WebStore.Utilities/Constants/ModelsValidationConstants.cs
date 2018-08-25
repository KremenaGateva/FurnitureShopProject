namespace WebStore.Utilities.Constants
{
    public class ModelsValidationConstants
    {
        //Constants for string min length
        public const int NamesMinLength = 5;
        public const int DescriptionMinLength = 15;
        public const int AddressMinLength = 10;
        public const int PasswordMinLength = 4;



        //Constants for string max length
        public const int NamesMaxLength = 50;
        public const int DescriptionMaxLength = 1500;
        public const int AddressMaxLength = 150;
        public const int PasswordMaxLength = 100;


        //Constants for min amount
        public const int MinAmount = 1;
        public const int DiscountMinValue = 0;
        public const int StockQuantityMinValue = 0;


        //Conatants for max amount
        public const int MaxAmount = 1000;
        public const int DiscountMaxValue = 90;
        public const int StockQuantityMaxValue = 1500;


    }
}
