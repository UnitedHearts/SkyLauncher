namespace SkyLauncher;
internal interface IResponse
{
    /// <summary>
    /// Проверяет, содержит ли ответ ошибки</summary>
    /// <returns>true - не содержит ошибку, false - содержит</returns>
    bool IsValid { get; }

    /// <summary>
    /// Возвращает обьект ошибки запроса
    /// </summary>
    /// <returns></returns>
    Error? GetError();
}
