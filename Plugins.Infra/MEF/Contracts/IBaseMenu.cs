using System.Web;

namespace Plugins.Infra.Contracts
{
    public interface IBaseMenu
    {
        string GroupName { get; }
        string LinkRelativeUrl { get; }
        string IconRelativeUrl { get; }
        string Text { get; }
        string Description { get; }
        string createLinkRelativeUrl(string parameters = null);
        bool isAtivo(HttpRequestBase request, string parameters = null);
        bool CanShow();
        int Ordem { get; }
    }
}
