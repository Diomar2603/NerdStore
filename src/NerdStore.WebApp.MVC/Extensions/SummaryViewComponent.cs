using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notification;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notificationHandler)
        {
            _notification = (DomainNotificationHandler)notificationHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notification.ObterNotificacoes());
            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Value));

            return View();
        }
    }
}
