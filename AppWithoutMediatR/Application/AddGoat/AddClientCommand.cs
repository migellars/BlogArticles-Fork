using AppWithoutMediatR.Domain;

namespace AppWithoutMediatR.Application.AddGoat;

public record AddGoatCommand(string Name, string Description) : ICommand<AddGoatResponse>;
public record AddGoatResponse(Guid GoatId);