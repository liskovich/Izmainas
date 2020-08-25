using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class AdminRecords
        {
            public const string GetAll = Base + "/admin/records";
            public const string Get = Base + "/admin/records/{recordId}";
            public const string Create = Base + "/admin/records";
            public const string Update = Base + "/admin/records/{recordId}";
            public const string Delete = Base + "/admin/records/{recordId}";
            public const string Date = Base + "/admin/records/dates/{recordDate}";

            public const string Today = Base + "/admin/records/today";
            public const string Tomorrow = Base + "/admin/records/tomorrow";
        }

        public static class ClientRecords
        {
            public const string Date = Base + "/client/records/dates/{recordDate}";

            public const string GetAll = Base + "/client/records";
            public const string Get = Base + "/client/records/{recordId}";
            public const string Today = Base + "/client/records/today";
            public const string Tomorrow = Base + "/client/records/tomorrow";
        }

        public static class TempRecords
        {
            public const string GetAll = Base + "/temprecords";
            public const string Get = Base + "/temprecords/{recordId}";
            public const string Create = Base + "/temprecords";
            public const string Update = Base + "/temprecords/{recordId}";
            public const string Delete = Base + "/temprecords/{recordId}";
            public const string Transfer = Base + "/temprecords/transfer";
        }

        public static class EmailAdminData
        {
            public const string GetAll = Base + "/admin/emailmodels";
            public const string Get = Base + "/admin/emailmodels/{modelId}";
            public const string Email = Base + "/admin/emailmodels/emails/{email}";
            public const string Create = Base + "/admin/emailmodels";
            public const string Delete = Base + "/admin/emailmodels/emails/{email}";
        }

        public static class EmailClientData
        {
            public const string Create = Base + "/client/emailmodels";
            public const string Delete = Base + "/client/emailmodels/emails/{email}";
            public const string GetAll = Base + "/client/emailmodels";
            public const string Get = Base + "/client/emailmodels/{modelId}";
        }
    }
}
