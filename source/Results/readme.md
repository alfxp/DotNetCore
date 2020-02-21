# DotNetCore.Results

The package provides generic classes for **results**.

## IResult

```cs
public interface IResult
{
    bool Failed { get; }

    string Message { get; }

    bool Succeeded { get; }
}
```

## Result

```cs
public class Result : IResult
{
    protected Result() { }

    public bool Failed { get; protected set; }

    public string Message { get; protected set; }

    public bool Succeeded { get; protected set; }

    public static IResult Fail() { }

    public static IResult Fail(string message) { }

    public static IResult Success() { }

    public static IResult Success(string message) { }
}
```

## IDataResult

```cs
public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
```

## DataResult

```cs
public class DataResult<T> : Result, IDataResult<T>
{
    protected DataResult() { }

    public T Data { get; protected set; }

    public static new IDataResult<T> Fail() { }

    public static new IDataResult<T> Fail(string message) { }

    public static new IDataResult<T> Success() { }

    public static new IDataResult<T> Success(string message) { }

    public static IDataResult<T> Success(T data) { }

    public static IDataResult<T> Success(T data, string message) { }
}
```
