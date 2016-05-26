namespace Server.BusinessLogic
{
    /// <summary>
    ///     Service gets word presentation
    /// </summary>
    public interface IWordPresentationService
    {
        /// <summary>
        ///     Return word presentation for decimal
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        string GetWordPresentation(decimal currency);
    }
}
