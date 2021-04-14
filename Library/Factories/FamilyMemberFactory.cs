using Bogus;
using Library.Models.FamilyMembers;

namespace Library.Factory.FamilyMembers
{
    class FamilyMemberFactory
    {
        public enum FamilyMemberType
        {
            FATHER,
            MOTHER,
            CHILD,
            RELATIVE
        }

        public FamilyMember CreateFakeFamilyMember()
        {

            var faker = new Faker("en");
            var o = new FamilyMember()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MemberType = (Models.FamilyMembers.FamilyMemberType)faker.PickRandom<FamilyMemberType>()
            };
            return o;
        }
    }
}
