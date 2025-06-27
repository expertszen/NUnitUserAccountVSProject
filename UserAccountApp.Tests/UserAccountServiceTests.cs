
using NUnit.Framework;
using System;

[TestFixture]
public class UserAccountServiceTests
{
    private UserAccountService _service;

    [SetUp]
    public void Init()
    {
        _service = new UserAccountService();
    }

    [TearDown]
    public void Clean()
    {
        _service.Reset();
    }

    [Test, Category("Positive")]
    public void Test_CreateUser_Success()
    {
        _service.CreateUser("john_doe");
        Assert.AreEqual("john_doe", _service.GetUser("john_doe"));
        Assert.IsFalse(_service.IsActive("john_doe"));
    }

    [Test, Category("Negative")]
    public void Test_DuplicateUser_ShouldThrow()
    {
        _service.CreateUser("alice");
        Assert.Throws<InvalidOperationException>(() => _service.CreateUser("alice"));
    }

    [Test, Category("Negative")]
    public void Test_EmptyOrNullUsername_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => _service.CreateUser(""));
        Assert.Throws<ArgumentException>(() => _service.CreateUser(null));
    }

    [Test, Category("Positive")]
    public void Test_ActivateUser_Success()
    {
        _service.CreateUser("dave");
        _service.ActivateUser("dave");
        Assert.IsTrue(_service.IsActive("dave"));
    }

    [Test, Category("Negative")]
    public void Test_GetNonExistentUser_ShouldReturnNull()
    {
        Assert.IsNull(_service.GetUser("ghost"));
    }
}
