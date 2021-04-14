using Library.Models.Births;
using Library.Models.Clinicians;
using System.Collections.Generic;
using Bogus;

namespace Library.Factory.Clinicians
{
    class ClinicianFactory
    {
        public enum ClinicianType
        {
            DOCTOR,
            MIDWIFE,
            NURSE,
            HEALTH_ASSISTANT,
            SECRETARY
        }

        public Clinician CreateFakeClinician()
        {

            var faker = new Faker("en");
            var o = new Clinician()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Role = (Models.Clinicians.ClinicianType)faker.PickRandom<ClinicianType>()
            };
            return o;
        }
    }
}
