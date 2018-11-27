using Services;
using Services.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WpfApplication2.Models
{
    public class LeiJiModel :BaseModel
    {
        public override void Execute()
        {
            SqlHelper sql = new SqlHelper();
            sql.Open();
            SimpleLogHelper.Instance.WriteLog(LogType.Info, sql.TestConn);
            for (int i = 1; i <= 31; i++)
            {
                int lie = i + 2; ;
                string cmd = string.Format("insert into sys_reportml (modid,exlmc,wzy,wzx,datares,ml,sheet) values('{0}','{1}','{2}',{3},'TC'," +
           "'SELECT (@DIFF_Day_0_{4}_00_00_24H+(33369))/10000','1')", this.Modid, this.Exlmc, this.Wzy, lie, i.ToString("00"));



                Debug.WriteLine(cmd);
                sql.Execute(cmd);
                SimpleLogHelper.Instance.WriteLog(LogType.Info, cmd);
            }
        }
    }
}
