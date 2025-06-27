
using System;
using System.Collections.Generic;

public class UserAccountService
{
    private Dictionary<string, bool> _users = new();

    public void CreateUser(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty");
        if (_users.ContainsKey(username))
            throw new InvalidOperationException("User already exists");
        _users[username] = false; // default inactive
    }

    public bool IsActive(string username)
    {
        return _users.ContainsKey(username) && _users[username];
    }

    public string GetUser(string username)
    {
        return _users.ContainsKey(username) ? username : null;
    }

    public void ActivateUser(string username)
    {
        if (_users.ContainsKey(username))
            _users[username] = true;
    }

    public void Reset()
    {
        _users.Clear();
    }
}
