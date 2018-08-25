namespace WebStore.Utilities.Messages
{
    public class ErrorMessages
    {
        public class Models
        {
            public const string NamesMaxLength = "Name length can not be more than 50 symbols.";
            public const string NamesMinLength = "Name length can not be less than 5 symbols.";

            public const string DescriptionMaxLength = "Description length can not be more than 1500 symbols.";
            public const string DescriptionMinLength = "Description length can not be less than 15 symbols.";

            public const string AddressMaxLength = "Address length can not be more than 150 symbols.";
            public const string AddressMinLength = "Address length can not be less than 10 symbols.";

            public const string AmountRange = "Amount must be between 1 and 100 pieces.";

            public const string DiscountRange = "Discount percentage must be between 0 and 90.";

            public const string StockQuantityMinLevel = "Stock quantity must be between 0 and 1500.";

            public const string PasswordLength = "The {0} must be at least {2} and at max {1} characters long.";

            public const string ConfirmPasswordMatchesPassword = "The password and confirmation password do not match.";

            public const string InvalidModelStateMessage = "Invalid data entered. Please try again";

        }
    }
}
