using DigiCV.Domain.Entities;

namespace DigiCV.Persistence.DataSeeder
{
    public static class UserProfileSeed
    {
        public static IList<UserProfile> UserProfiles()
        {
            var adminProfile = new UserProfile
            {
                Id = new Guid("9749E4E1-F89C-42BD-8A04-5A79993A58F9"),
                Address = "Room No. 419, BSMRH Hall, MBSTU",
                Education = "Mawlana Bhashani Science and Technology University, Tangail",
                Experience = "C#, ASP.NET, EF Core",
                Designation = ".NET Developer",
                GithubUsername = "absa1am",
                LinkedInUsername = "absa1am",
                IsActive = true
            };

            var managerProfile = new UserProfile
            {
                Id = new Guid("A618E70B-3CDB-420A-A1B3-702D0B06E9C2"),
                Address = "Room No. 419, BSMRH Hall, MBSTU",
                Education = "Mawlana Bhashani Science and Technology University, Tangail",
                Experience = "C#, ASP.NET, EF Core",
                Designation = ".NET Developer",
                GithubUsername = "absa1am",
                LinkedInUsername = "absa1am",
                IsActive = true
            };

            var profiles = new List<UserProfile> { adminProfile, managerProfile };

            return profiles;
        }
    }
}
