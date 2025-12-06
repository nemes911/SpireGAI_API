namespace SpireGAI_API.ApiService.Redis.models
{
    public class AddNewUserEvent
    {
        public string name_user {  get; set; }

        public string role { get; set; }

        public string name_added_user { get; set; }

        public string role_added_user { get; set; }
    }
}
