using Library.Models.Births;

namespace Library.Models.FamilyMembers
{
    class FamilyMemberFactory
    {
        public FamilyMember createFamilyMember(string FirstName, string LastName, Birth AssociatedBirth, FamilyMemberType MemberType)
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
