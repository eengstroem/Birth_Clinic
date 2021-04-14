using Library.Models.Births;
using Library.Models.FamilyMembers;

namespace Library.Factory.FamilyMembers
{
    class FamilyMemberFactory
    {
        public FamilyMember CreateFamilyMember(string FirstName, string LastName, Birth AssociatedBirth, FamilyMemberType MemberType)
        {
            FamilyMember f = new();
            f.FirstName = FirstName;
            f.LastName = LastName;
            f.AssociatedBirth = AssociatedBirth;
            f.MemberType = MemberType;

            return f;
        }
    }
}
