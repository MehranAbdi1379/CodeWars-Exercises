// See https://aka.ms/new-console-template for more information


var people = new List<Person>()
{
    new Person()
    {
        Age = 18,
        Cars = new List<Car>(),
        FirstName = "Mehran",
        LastName = "Abdi"
    }
};

public class Entity
{
    public Entity()
    {
        Id = new Guid();
    }
    public Guid Id { get; set; }
}

public class Person: Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Car> Cars { get; set; }
}

public class Car: Entity
{
    public List<Wheel> wheels { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public Person Owner { get; set; }
}

public class Wheel : Entity
{
    public double Size { get; set; }
    public Car Owner { get; set; }
}
