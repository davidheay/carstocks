using System.ComponentModel.DataAnnotations;

namespace carstocks.models;

public class Dealer
{

    public int Id { get; private set; }

    [Required]
    public string Name { get; private set; }

    public Dealer(int id, string name)
    {
        Id = id;
        Name = name;
    }

}
