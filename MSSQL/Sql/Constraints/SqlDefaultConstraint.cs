﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL.Sql.Constraints
{
    public class SqlDefaultConstraint : SqlConstraint
    {
        public object DefaultValue { get; set; }
    }
}
