using Library.Models.Births;
using Library.Models.Clinicians;
using Library.Models.FamilyMembers;
using System;
using System.Collections.Generic;

namespace Library.Factory.Births
{
    public class BirthFactory
    {
        public Birth createBirth(DateTime BirthDate, ICollection<Clinician> AssociatedClinicians, ICollection<FamilyMember> ChildrenToBeBorn, FamilyMember Mother)
        {
            Birth b = new();
            b.BirthDate = BirthDate;
            b.AssociatedClinicians = AssociatedClinicians;
            b.ChildrenToBeBorn = ChildrenToBeBorn;
            b.Mother = Mother;

            return b;
        }

        public Birth createBirth(DateTime BirthDate, ICollection<Clinician> AssociatedClinicians, ICollection<FamilyMember> ChildrenToBeBorn, FamilyMember Mother, FamilyMember Father)
        {
            Birth b = new();
            b.BirthDate = BirthDate;
            b.AssociatedClinicians = AssociatedClinicians;
            b.ChildrenToBeBorn = ChildrenToBeBorn;
            b.Mother = Mother;
            b.Father = Father;

            return b;
        }

        public Birth createBirth(DateTime BirthDate, ICollection<Clinician> AssociatedClinicians, ICollection<FamilyMember> ChildrenToBeBorn, FamilyMember Mother, ICollection<FamilyMember> Relatives)
        {
            Birth b = new();
            b.BirthDate = BirthDate;
            b.AssociatedClinicians = AssociatedClinicians;
            b.ChildrenToBeBorn = ChildrenToBeBorn;
            b.Mother = Mother;
            b.Relatives = Relatives;

            return b;
        }

        public Birth createBirth(DateTime BirthDate, ICollection<Clinician> AssociatedClinicians, ICollection<FamilyMember> ChildrenToBeBorn, FamilyMember Mother, FamilyMember Father, ICollection<FamilyMember> Relatives)
        {
            Birth b = new();
            b.BirthDate = BirthDate;
            b.AssociatedClinicians = AssociatedClinicians;
            b.ChildrenToBeBorn = ChildrenToBeBorn;
            b.Mother = Mother;
            b.Father = Father;
            b.Relatives = Relatives;

            return b;
        }
    }
}
