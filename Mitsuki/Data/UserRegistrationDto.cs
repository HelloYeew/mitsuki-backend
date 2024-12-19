using System.Text.Json.Serialization;

namespace Mitsuki.Data;

/// <summary>
/// The request type for the "/register" endpoint added by <see cref="IdentityApiEndpointRouteBuilderExtensions.MapIdentityApi"/>.
/// </summary>
public sealed class UserRegistrationDto
{
    /// <summary>
    /// The user's user name.
    /// </summary>
    [JsonPropertyName("username")]
    public required string UserName { get; init; }
    
    /// <summary>
    /// The user's email address which acts as a user name.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// The user's password.
    /// </summary>
    public required string Password { get; init; }
}