using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{
    public class OrganizationDataUnit : DataUnit
    {
        private OrganizationTable organization;

        public OrganizationDataUnit()
            : base((int)ObjectTypeCode.Organization)
        {
            this.DataSetName = "OrganizationComponent";

            // Organization
            organization = new OrganizationTable();
            Tables.Add(organization);
        }

        public OrganizationTable Organization
        {
            get
            {
                return organization;
            }
        }
    }
}
