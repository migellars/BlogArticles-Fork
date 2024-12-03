using AppWithoutMediatR.Application.AddGoat;
using MediatR;

namespace AppWithoutMediatR.Application.AddGoatWithMediatR;

internal class AddGoatWithMediatRHandler : IRequestHandler<AddGoatWithMediatRCommand, AddGoatResponse>
{
    public Task<AddGoatResponse> Handle(AddGoatWithMediatRCommand request, CancellationToken cancellationToken)
    {
        // We create the goat : var goatCreated = new GoatCreated....
        // We asked here for the credits : var credits = creditsService.GetCredits();
        // We save it in the database : Repository.Save(goatCreated)
        return Task.FromResult(new AddGoatResponse(Guid.NewGuid()));
    }
}

