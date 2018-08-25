namespace WebStore.Common.Admin.ViewModels
{
    public class UserConciseViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public bool IsDataOperator { get; set; }

        public bool IsAdmin { get; set; }
    }
}
