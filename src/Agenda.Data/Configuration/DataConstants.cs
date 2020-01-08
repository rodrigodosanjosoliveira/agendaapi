﻿
namespace Agenda.Data.Configuration
{
    public class DataConstants
    {
        public class SqlServer
        {
            protected SqlServer() { }

            public const string NewId = "newid()";
            public const string SysDateTime = "sysdatetime()";
            public const string NewSequentialId = "newsequentialid()";
            public const string DateTime2 = "datetime2(2)";
        }
    }
}
