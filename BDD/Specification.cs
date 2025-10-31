using NUnit.Framework;
using Shouldly;

namespace BDD;

public class Specification
{
    protected static Exception error = null!;

    [OneTimeSetUp]
    protected virtual Task before_all()
    {
        error = null!;
        return Task.CompletedTask;
    }     
    
    [SetUp]
    protected virtual Task before_each()
    {
        error = null!;
        return Task.CompletedTask;
    }    
    
    [TearDown]
    protected virtual Task after_each()
    {
        return Task.CompletedTask;
    }    
    
    [OneTimeTearDown]
    protected virtual Task after_all()
    {
        return Task.CompletedTask;
    }

    protected static void Given(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void And(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void When(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void Then(Action testAction)
    {
        testAction.Invoke();
    }
    
    protected static void Scenario(Action testAction)
    {
        testAction.Invoke();
    }

    protected static Action Validating(Action testAction)
    {
        return () =>
        {
            try
            {
                testAction.Invoke();
            }
            catch (Exception e)
            {
                error = e;
            }
        };
    }
    
    protected static Action Informs(string message)
    {
        return () =>
        {
            error.ShouldNotBeNull();
            error.Message.ShouldBe(message);
        };
    }

    protected static async Task Given(Func<Task> testAction)
    {
        await testAction.Invoke();
    }

    protected static async Task And(Func<Task> testAction)
    {
        await testAction.Invoke();
    }

    protected static async Task When(Func<Task> testAction)
    {
        await testAction.Invoke();
    }

    protected static async Task Then(Func<Task> testAction)
    {
        await testAction.Invoke();
    }
    
    protected static async Task Scenario(Func<Task> testAction)
    {
        await testAction.Invoke();
    }

    protected static Func<Task> Validating(Func<Task> testAction)
    {
        return async () =>
        {
            try
            {
                await testAction.Invoke();
            }
            catch (Exception e)
            {
                error = e;
            }
        };
    }
    
    protected static Func<Task> InformsAsync(string message)
    {
        return async () =>
        {
            error.ShouldNotBeNull();
            error.Message.ShouldBe(message);
            await Task.CompletedTask;
        };
    }
}