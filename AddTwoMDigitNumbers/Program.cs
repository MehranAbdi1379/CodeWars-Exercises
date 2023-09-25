// See https://aka.ms/new-console-template for more information
using Bogus;

var categoryFaker = new Faker<Category>()
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(c => c.Title, f => f.Commerce.Categories(1)[0]);

var faker = new Faker(); // Create a Faker instance

// Generate a list of dummy categories without ParentId values
var categoriesWithoutParent = categoryFaker.Generate(20); // Generate 20 categories, adjust as needed

// Clone the categories to another list for assigning parent IDs
var categories = new List<Category>(categoriesWithoutParent);

// Assign ParentId values based on the cloned list
foreach (var category in categories)
{
    if (categories.Count > 0 && category.Id != categories[0].Id) // Ensure the category is not the first one
    {
        // Introduce a one-third chance of having no parent
        if (faker.Random.Bool(0.33f))
        {
            category.ParentId = null; // No ParentId
        }
        else
        {
            // Generate a unique ParentId that is not the same as the instance Id
            Guid parentId;
            do
            {
                int index = faker.Random.Int(0, categories.Count - 1);
                parentId = categories[index].Id;
            } while (parentId == category.Id);

            category.ParentId = parentId;
        }
    }
}

// Display the generated data
foreach (var category in categories)
{
    Console.WriteLine($"Id: {category.Id}, Title: {category.Title}, ParentId: {category.ParentId}");
}


public class Category
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid? ParentId { get; set; }
}