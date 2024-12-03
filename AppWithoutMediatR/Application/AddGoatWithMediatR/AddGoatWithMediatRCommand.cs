using AppWithoutMediatR.Application.AddGoat;
using MediatR;

namespace AppWithoutMediatR.Application.AddGoatWithMediatR;

public record AddGoatWithMediatRCommand(string Name, string Description) : IRequest<AddGoatResponse>;
public record AddGoatWithMediatRResponse(Guid GoatId);