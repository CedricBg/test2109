namespace test2109.Models.Auth;

public class ConnectedForm
{
    /// <summary>
    /// Objet qui est renvoyer quand on est logguer permet de creer un cookies de connexion
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string SurName { get; set; }

    public string Token { get; set; }

    public string Role { get; set; }

    public string Dimin { get; set; }
}
