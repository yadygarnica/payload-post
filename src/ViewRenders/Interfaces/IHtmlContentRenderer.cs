using System.Threading.Tasks;

namespace PayloadPost.ViewRenders.Interfaces
{
    public interface IHtmlContentRenderer
    {
        Task<string> RenderViewToString<TModel>(string viewName, TModel model);
    }
}