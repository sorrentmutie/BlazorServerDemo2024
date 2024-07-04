namespace BlazorServerDemo2024.Core;

public interface IEntity<T>
{
    T Id { get; set; }
}
