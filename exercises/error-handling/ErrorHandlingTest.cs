﻿using System;
using Xunit;

public class ErrorHandlingTest
{
    // Read more about exception handling here:
    // https://msdn.microsoft.com/en-us/library/ms173162.aspx?f=255&MSPPError=-2147217396
    [Fact]
    public void ThrowException()
    {
        Assert.Throws<Exception>(() => ErrorHandling.HandleErrorByThrowingException());
    }

    // Read more about nullable types here:
    // https://msdn.microsoft.com/en-us/library/1t3y8s4s.aspx?f=255&MSPPError=-2147217396
    [Fact]
    public void ReturnNullableType()
    {
        var successfulResult = ErrorHandling.HandleErrorByReturningNullableType("1");
        Assert.Equal(1, successfulResult);

        var failureResult = ErrorHandling.HandleErrorByReturningNullableType("a");
        Assert.Equal(null, failureResult);
    }

    // Read more about out parameters here:
    // https://msdn.microsoft.com/en-us/library/t3c3bfhx.aspx?f=255&MSPPError=-2147217396
    [Fact]
    public void ReturnWithOutParameter()
    {
        int result;
        var successfulResult = ErrorHandling.HandleErrorWithOutParam("1", out result);
        Assert.Equal(true, successfulResult);
        Assert.Equal(1, result);
        
        var failureResult = ErrorHandling.HandleErrorWithOutParam("a", out result);
        Assert.Equal(false, failureResult);
        // The value of result is meaningless here (it could be anything) so it shouldn't be used and it's not validated 
    }

    private class DisposableResource : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }

    // Read more about IDisposable here:
    // https://msdn.microsoft.com/en-us/library/system.idisposable(v=vs.110).aspx
    [Fact]
    public void DisposableObjectsAreDisposedWhenThrowingAnException()
    {
        var disposableResource = new DisposableResource();

        Assert.Throws<Exception>(() => ErrorHandling.DisposableResourcesAreDisposedWhenExceptionIsThrown(disposableResource));
        Assert.Equal(true, disposableResource.IsDisposed);
    }
}
