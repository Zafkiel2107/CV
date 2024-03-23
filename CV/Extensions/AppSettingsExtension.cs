namespace CV.Extensions
{
    public static class Authentification
    {
        public static string AuthentificationEmail { get; private set; }
        public static string AuthentificationPassword { get; private set; }
        public static void RegisterAuthentification(this WebApplication application)
        {
            AuthentificationEmail = application.Configuration["Authentification:AuthentificationEmail"] ?? "";
            AuthentificationPassword = application.Configuration["Authentification:AuthentificationPassword"] ?? "";
        }
    }
    public static class Recipient
    {
        public static string RecipientEmail { get; private set; }
        public static string RecipientName { get; private set; }
        public static void RegisterRecipient(this WebApplication application)
        {
            RecipientEmail = application.Configuration["Recipient:RecipientEmail"] ?? "";
            RecipientName = application.Configuration["Recipient:RecipientName"] ?? "";
        }
    }
    public static class Files
    {
        public static string CV { get; private set; }
        public static string About { get; private set; }
        public static string Portfolio_1 { get; private set; }
        public static string Portfolio_2 { get; private set; }
        public static string Portfolio_3 { get; private set; }
        public static string Profile { get; private set; }
        public static string Quote { get; private set; }
        public static void RegisterFiles(this WebApplication application)
        {
            CV = application.Configuration["Files:CV"] ?? "";
            About = application.Configuration["Files:Images:About"] ?? "";
            Portfolio_1 = application.Configuration["Files:Images:Portfolio_1"] ?? "";
            Portfolio_2 = application.Configuration["Files:Images:Portfolio_2"] ?? "";
            Portfolio_3 = application.Configuration["Files:Images:Portfolio_3"] ?? "";
            Profile = application.Configuration["Files:Images:Profile"] ?? "";
            Quote = application.Configuration["Files:Images:Quote"] ?? "";
        }
    }
    public static class Links
    {
        public static string Vk { get; private set; }
        public static string LinkedIn { get; private set; }
        public static string Github { get; private set; }
        public static string Hh { get; private set; }
        public static string Job_1 { get; private set; }
        public static string Job_2 { get; private set; }
        public static string Project_1 { get; private set; }
        public static string Project_2 { get; private set; }
        public static string Project_3 { get; private set; }
        public static void RegisterLinks(this WebApplication application)
        {
            Vk = application.Configuration["Links:Vk"] ?? "";
            LinkedIn = application.Configuration["Links:LinkedIn"] ?? "";
            Github = application.Configuration["Links:Github"] ?? "";
            Hh = application.Configuration["Links:Hh"] ?? "";
            Job_1 = application.Configuration["Links:Experiens:Job_1"] ?? "";
            Job_2 = application.Configuration["Links:Experiens:Job_2"] ?? "";
            Project_1 = application.Configuration["Links:Portfolio:Project_1"] ?? "";
            Project_2 = application.Configuration["Links:Portfolio:Project_2"] ?? "";
            Project_3 = application.Configuration["Links:Portfolio:Project_3"] ?? "";
        }
    }
}
