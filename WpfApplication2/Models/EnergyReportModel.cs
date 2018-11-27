using Services;
using Services.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WpfApplication2.Models
{
    public class EnergyReportModel : BaseModel
    {
        public override void Execute()
        {
            SqlHelper sql = new SqlHelper();
            sql.Open();
            SimpleLogHelper.Instance.WriteLog(LogType.Info, sql.TestConn);
            string cmd = string.Format("SELECT * FROM sys_reportml WHERE modid='014' AND ( exlmc LIKE 'J%' OR exlmc LIKE 'K%' OR exlmc LIKE 'Q%' OR exlmc LIKE 'R%' OR exlmc LIKE 'S%')", this.Exlmc);
            Debug.WriteLine(cmd);
            List<MlModel> mls = sql.GetDataTable<MlModel>(cmd);
            Debug.WriteLine(mls.Count);
            foreach (var item in mls)
            {
                var a = item.ml.Split(' ');
                string b = a[0] + " (" + a[1] + ")/10000";
                cmd = string.Format("update sys_reportml set modid='{0}',exlmc='{1}',wzy='{2}',wzx='{3}',datares='{4}',ml='{5}',sheet='{6}' WHERE modid='{0}' AND exlmc='{1}' AND wzx='{3}' ", item.modid, item.exlmc, item.wzy, item.wzx, item.datares, b, item.sheet, item.exlmc, item.modid);
                Debug.WriteLine(cmd);
                Debug.WriteLine(sql.Execute(cmd));
            }
        }
    }
}
