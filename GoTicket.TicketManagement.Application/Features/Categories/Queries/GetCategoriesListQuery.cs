using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTicket.TicketManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
