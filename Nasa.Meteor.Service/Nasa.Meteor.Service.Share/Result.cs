namespace Meteor.Service.Share;

public record Result<T>
{
    public Result(bool isSuccessfull) => IsSuccessfull = isSuccessfull;

    public Result(bool isSuccessfull, string error) : this(isSuccessfull) => Error = error;

    public bool IsSuccessfull { get; }
    public string Error { get; }
    public T Value { get; set; }
}