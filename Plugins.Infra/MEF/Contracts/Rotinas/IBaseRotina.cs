using System.Web;

namespace Plugins.Infra.Contracts.Rotinas.Financeiro
{
    public interface IBaseRotina
    {
        string GroupName { get; }
        string LinkRelativeUrl { get; }
        string IconRelativeUrl { get; }
        string Text { get; }
        string Description { get; }
        bool isAtivo(HttpRequestBase request, string parameters = null);
        string createLinkRelativeUrl(string parameters = null);
        bool CanShow(long idAluno);
    }
}
