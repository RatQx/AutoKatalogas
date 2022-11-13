using Microsoft.AspNetCore.Identity;

namespace AutoKatalogas.Auth.Model
{
    public class ForumRestUser : IdentityUser
    {
        [PersonalData]
        public string? AdditionalInfo { get; set; }
    }
}
