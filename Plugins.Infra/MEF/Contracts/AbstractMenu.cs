using System;

namespace Plugins.Infra.Contracts
{
    public abstract class AbstractMenu : IMenu
    {
        public abstract string GroupName { get; }
        public abstract string LinkRelativeUrl { get; }
        public abstract string IconRelativeUrl { get; }
        public abstract string Text { get; }
        public abstract string Description { get; }
        public abstract bool isAtivo(System.Web.HttpRequestBase request, string parameters = null);
        public abstract string createLinkRelativeUrl(string parameters = null);
        public abstract bool CanShow();
        public virtual int Ordem { get; }
        public virtual string Target
        {
            get { return string.Empty; }
        }
    }
}
