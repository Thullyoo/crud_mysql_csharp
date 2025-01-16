namespace crud_mysql;

public class Person
{
    public Guid Id { get; init; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public Person(string email, string password)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
    }

    public void setEmail(string email)
    {
        Email = email;
    }

    public void setPassword(string password)
    {
        Password = password;
    }
}