using Services;
using Services.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WpfApplication2.Models
{
    public class JiaModel : BaseModel
    {
        public override void Execute()
        {
            SqlHelper sql = new SqlHelper();
            sql.Open();
            Debug.WriteLine(sql.TestConn);
            string cmd = string.Format("SELECT * FROM sys_reportml WHERE modid='{0}' and exlmc='{1}'",this.Modid,this.Exlmc);
            Debug.WriteLine(cmd);
            List<MlModel> mls = sql.GetDataTable<MlModel>(cmd);
            if (mls == null) return;
            MlModel ml;
            MlModel ml1 = mls[0];
            for (int i=2;i<=31;i++)
            {
                string[] hs = ml1.ml.Split('_');
                string a = "";
                foreach(var item in hs)
                {
                    if(item == (i-1).ToString("00"))
                    {
                        a += (i.ToString("00")) + "_";
                    }
                    else
                    {
                        a += (item + "_");
                    }
                }
                a = a.Substring(0, a.Length - 1);
                ml = mls[0];
                ml.ml = a;
                ml.wzx = (1+i*4).ToString();
                //ml.wzx = (8+ (i-2)*4).ToString();
                cmd = string.Format("insert into sys_reportml (modid,exlmc,wzy,wzx,datares,ml,sheet) values('{0}','{1}','{2}',{3},'{4}'," +
           "'{5}','{6}')", ml.modid, ml.exlmc, ml.wzy, ml.wzx, ml.datares, ml.ml, ml.sheet);
                Debug.WriteLine(cmd);
                Debug.WriteLine(sql.Execute(cmd));
            }
            SimpleLogHelper.Instance.WriteLog(LogType.Info, cmd);
        }
    }
}
