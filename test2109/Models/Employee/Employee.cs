using DataAccess.Models;

namespace test2109.Models.Employee;

/// <summary>
/// Classe qui sert afficher une liste d'employee avec un minimum de donnèes(la complète étant DetailEmployed.cs)
/// </summary>
public class Employee
{
    public int? Id { get; set; }

    public string firstName { get; set; }

    public string SurName { get; set; }

    public Role Role { get; set; }

    public Language Language { get; set; }
}
