namespace Ordering.Domain.Abstractions;

public interface IEntity<out T> : IEntity
{
    public T Id { get; }
}

public interface IEntity
{
    public DateTime? CreatedAt { set; }
    public string? CreatedBy { set; }
    public DateTime? ModifiedAt { set; }
    public string? ModifiedBy { set; }
}