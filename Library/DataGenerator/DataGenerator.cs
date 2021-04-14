using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.FamilyMembers;
using Library.Models.Births;

namespace Library.DataGenerator
{
    class DataGenerator
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
        public Birth CreateFakeBirth()
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
