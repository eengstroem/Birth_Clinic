using Library.Models.Births;

namespace Library.Models.FamilyMembers
{
    public enum FamilyMemberType
    {
        FATHER,
        MOTHER,
        CHILD,
        RELATIVE
    }

    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Birth AssociatedBirth { get; set; }

        public FamilyMemberType MemberType { get; set; }
    }
}
