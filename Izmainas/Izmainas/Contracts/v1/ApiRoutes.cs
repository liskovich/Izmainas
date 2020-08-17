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

        public static class Records
        {
            public const string GetAll = Base + "/records";
            public const string Get = Base + "/records/{recordId}";
            public const string Create = Base + "/records";
            public const string Update = Base + "/records/{recordId}";
            public const string Delete = Base + "/records/{recordId}";
            public const string Date = Base + "/records/dates/{recordDate}";

            public const string Today = Base + "/records/today";
            public const string Tomorrow = Base + "/records/tomorrow";
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
    }
}
