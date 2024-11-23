namespace Ordering.Domain.Abstractions;

public interface IEntity<out T> : IEntity
{
    public T Id { get; }
}

public interface IEntity
{
    public DateTime? CreatedAt { get; }
    public string? CreatedBy { get; }
    public DateTime? ModifiedAt { get; }
    public string? ModifiedBy { get; }
}