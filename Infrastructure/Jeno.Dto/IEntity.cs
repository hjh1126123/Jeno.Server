using System;
using System.Collections.Generic;
using System.Text;
using Masuit.Tools.Systems;
using SqlSugar;

namespace Jeno.Dto
{
    public abstract class IEntity
    {
        public abstract string Name { get; }

        public virtual void Init()
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                ID = Common.Mananger.Instance.GetUniqueID(Name);
            }

            if (B_CREATE_TIME == null)
            {
                B_CREATE_TIME = DateTime.Now;
            }

            if (B_STATUS == null)
            {
                B_STATUS = 0;
            }
        }

        /// <summary>
        /// 数据ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, ColumnName = "id", ColumnDescription = "数据ID", Length = 64)]
        public string ID { get; set; }

        /// <summary>
        /// 数据创建日期
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnName = "b_create_time", ColumnDescription = "数据创建日期")]
        public DateTime? B_CREATE_TIME { get; set; }

        /// <summary>
        /// 数据状态（0 正常， 1 作废、无效数据， 2 删除）
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnName = "b_status", ColumnDescription = "数据状态（0 正常， 1 作废、无效数据， 2 删除）")]
        public int? B_STATUS { get; set; }

        /// <summary>
        /// 数据操作日志
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnName = "b_log", ColumnDescription = "数据操作日志", Length = 1024)]
        public string B_LOG { get; set; }
    }
}
