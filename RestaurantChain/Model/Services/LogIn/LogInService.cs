using RestaurantChain.Model.Convertors;

namespace RestaurantChain.Model.Services.LogIn
{
    /// <summary>
    /// Сервис входа пользователя.
    /// </summary>
    public class LogInService : ILogInService
    {
        private IConvertor<string, string> _convertor;

        public LogInService(IConvertor<string, string> convertor)
        {
            _convertor = convertor;
        }

        /// <summary>
        /// Проверка введённых значений для входа в аккаунт.
        /// </summary>
        /// <param name="login">Введённый логин.</param>
        /// <param name="password">Введённый пароль.</param>
        /// <returns>True - введённые значения есть БД, пароль соответсвует логину;
        /// False - обратная ситуация.</returns>
        public bool TryLogIn(string login, string password)
        {
            //foreach (IUserData userData in DataManager.GetInstance().UserRepository.Read())
            //{
            //    if(userData.User.Login == login && userData.User.Password == _convertor.Convert(password))
            //    {
            //        DataManager.GetInstance().CurrentUser = userData;
            //        return true;
            //    }
            //}
            return false;
        }
    }
}
