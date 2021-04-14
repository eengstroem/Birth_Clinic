using Bogus;
using Library.Models.FamilyMembers;

namespace Library.Factory.FamilyMembers
{
    class FamilyMemberFactory
    {
        
        public static FamilyMember CreateFakeFamilyMember(FamilyMemberType type)
        {

            var faker = new Faker("en");
            var o = new FamilyMember()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MemberType = type
            };
            return o;
        }
    }
}
