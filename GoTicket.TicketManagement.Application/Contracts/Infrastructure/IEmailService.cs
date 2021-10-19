using GoTicket.TicketManagement.Application.Model.Mail;
using System.Threading.Tasks;

namespace GoTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
