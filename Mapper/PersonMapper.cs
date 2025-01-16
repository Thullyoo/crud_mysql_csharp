using crud_mysql.Request;

namespace crud_mysql.Mapper;

public static class PersonMapper
{
    public static Person MapRequestToPerson(PersonRequest personRequest)
    {
        return new Person(personRequest.email, personRequest.password);
    }
}