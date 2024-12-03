using AppWithoutMediatR.Domain;

namespace AppWithoutMediatR.Application.AddGoat;

internal class AddGoatHandler : IAddGoatHandler
{
    public Task<AddGoatResponse> Handle(AddGoatCommand query)
    {
        return Task.FromResult(new AddGoatResponse(Guid.NewGuid()));
    }
}

public interface IAddGoatHandler : IHandler<AddGoatCommand, AddGoatResponse>;
public interface IHandler<in TQuery, TResult> where TQuery : ICommand<TResult>
{
    Task<TResult> Handle(TQuery query);
}
