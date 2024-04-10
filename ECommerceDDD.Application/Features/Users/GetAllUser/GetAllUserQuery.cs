using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDDD.Application.Features.Users.GetAllUser
{
	public sealed record class GetAllUserQuery() : IRequest<List<User>>;

}
