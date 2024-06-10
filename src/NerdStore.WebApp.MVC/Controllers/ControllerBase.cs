using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public ControllerBase(IMediatorHandler mediatorHandler,
                              INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        protected Guid ClienteId = Guid.Parse("50b97e45-526c-4a8d-bddf-2d82e2f1b669");

        protected bool OperacaoValida()
        {
            return !_domainNotificationHandler.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _domainNotificationHandler.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

    }
}
