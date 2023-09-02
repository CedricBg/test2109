namespace test2109.Models;

public class Role
{
    /// <summary>
    /// Role qui permet de changer les droits pour un utilisateur exemple: admin devient direction
    /// </summary>
    public int roleId { get; set; }

    public string Name { get; set; }

    public string DiminName { get; set; }

    public int Numero { get; set; }
}
