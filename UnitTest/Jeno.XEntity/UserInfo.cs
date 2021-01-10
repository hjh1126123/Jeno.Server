using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Jeno.XUnit.Entity
{
    [SugarTable(tableName: "user")]
    public class UserInfo : Dto.IEntity
    {
        public override string Name { get => "10010"; }
    }
}
