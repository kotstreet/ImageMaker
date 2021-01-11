namespace ImageManager.MVC.Constants
{
    public static class ModelErrorMessages
    {
        public const string UserIsNotActive = "Учетная запись деактивирована.";
        public const string UserNotExist = "Такого пользвателя не существует.";
        public const string PasswordOrEmailIncorrect = "Почта или пароль указаны неверно.";
        public const string EmailIsNotUnique = "Такая почта уже существует.";
        public const string SomethingIsGoingWrong = "Что-то пошло не так.";

        public const string RoleNotSelected = "Вы должны указать хотя бы одну роль.";
    }
}
