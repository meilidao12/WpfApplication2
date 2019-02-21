﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;

namespace Services
{
    /*
    调用方法：
    其中 dt 为 System.Data 中的DataTable类型
            ex.Open(Helper.GetCurrentUri + @"\Excel\Hello.xlsx");
            ex.InsertTable(dt, "Sheet1", 2, 1);
            ex.SaveAs(@"C:\Users\MrGao\Desktop\excel\" + string.Format("{0:yyMMdd HHmmss}", DateTime.Now) +".xlsx" );
            ex.Close();
    */
    public class ExcelHelper
    {
        private Microsoft.Office.Interop.Excel.Application App = null;
        private Microsoft.Office.Interop.Excel.Workbooks Wbs = null;
        private Microsoft.Office.Interop.Excel.Workbook Wb = null;
        //private Microsoft.Office.Interop.Excel.Worksheets Wss = null;
        //private Microsoft.Office.Interop.Excel.Worksheet Ws = null;
        private string filePath;
        public ExcelHelper() { }

        public bool Open(string filePath)
        {
            bool result = true;
            this.filePath = filePath;
            App = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                Wbs = App.Workbooks;
                Wb = Wbs.Add(filePath);
            }
            catch (Exception ex)
            {
                result = false;
                SimpleLogHelper.Instance.WriteLog(LogType.Error, ex);
            }
            return result;
        }

        public Microsoft.Office.Interop.Excel.Worksheet GetSheet(string SheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)Wb.Worksheets[SheetName];
            return s;
        }

        public void SetCellValue(Microsoft.Office.Interop.Excel.Worksheet ws, int x, int y, object value)
        {
            ws.Cells[x, y].value = value;
        }

        public void SetCellValue(string ws, int x, int y, object value)
        {
            GetSheet(ws).Cells[x, y].value = value;
        }

        #region --- 插入数据表格
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws">Sheet1 或 Sheet2</param>
        /// <param name="startY">起始行</param>
        /// <param name="startX">起始列</param>
        public void InsertTable(System.Data.DataTable dt, string ws, int startY, int startX)
        {

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startY + i, j + startX] = dt.Rows[i][j].ToString();
                }
            }
        }
        public void InsertTable(System.Data.DataTable dt, Microsoft.Office.Interop.Excel.Worksheet ws, int startY, int startX)
        {

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    ws.Cells[startY + i, j + startX] = dt.Rows[i][j];
                }
            }
        }
        #endregion


        public bool SaveAs(string path)
        {
            if (path == "")
            {
                return false;
            }
            else
            {
                try
                {
                    App.AlertBeforeOverwriting = false;
                    Wb.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing
                        , Type.Missing, Type.Missing);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Save()
        {
            if(this.filePath == "")
            {
                return false;
            }
            else
            {
                try
                {
                    Wb.Save();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public void Close()
        {
            try
            {
                Wb.Close(Type.Missing, Type.Missing, Type.Missing);
                Wbs.Close();
                App.Quit();
                Wb = null;
                Wbs = null;
                App = null;
                GC.Collect();
            }
            catch(Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Error, ex);
            }
        }
    }
}
