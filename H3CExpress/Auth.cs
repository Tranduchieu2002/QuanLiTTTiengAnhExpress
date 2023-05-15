using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout.Modes;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace H3CExpress
{
    public static class Auth
    {
        public static users User { get; set; }
        public static bool IsLoggedIn { get; set; }

        public static void ExportToExcel(object dataGrid, string title = "DANH SÁCH KHÁCH HÀNG")
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                Microsoft.Office.Interop.Excel.Range titleRange = worksheet.Range["A1:F1"];
                titleRange.MergeCells = true;
                titleRange.Value = title;
                titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;

                try
                {
                    // Export dữ liệu vào Excel
                    if (dataGrid is DataGridView)
                    {
                        DataGridView dataGridView = (DataGridView)dataGrid;
                        // Export using DataGridView
                        // ...
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            worksheet.Cells[2, i + 1] = dataGridView.Columns[i].HeaderText;
                        }
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                if (dataGridView.Rows[i].Cells[j].Value != null)
                                {
                                    worksheet.Cells[i + 3, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                                }
                                else
                                {
                                    worksheet.Cells[i + 3, j + 1] = "";
                                }
                            }
                        }
                    }
                    else if (dataGrid is DevExpress.XtraGrid.GridControl)
                    {
                        DevExpress.XtraGrid.GridControl gridControl = (DevExpress.XtraGrid.GridControl)dataGrid;
                        var gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl.FocusedView;

                        // Export using GridView of DevExpress
                        // ...
                        for (int i = 0; i < gridView.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1] = gridView.Columns[i].Caption;
                        }

                        // Export row data
                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            for (int j = 0; j < gridView.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1] = gridView.GetRowCellValue(i, gridView.Columns[j]);
                            }
                        }
                    }

                    // Lưu file Excel
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("File đã được lưu thành công!");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static void ExportToExcelWithList(List<object[]> dataList, string HeaderText)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Records";
            try
            {

                // Add title
                Microsoft.Office.Interop.Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dataList[0].Length]];
                titleRange.Merge();
                titleRange.Value = HeaderText;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Add data
                for (int i = 0; i < dataList.Count; i++)
                {
                    object[] row = dataList[i];
                    for (int j = 0; j < row.Length; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = row[j].ToString();
                    }
                }

                // Save file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("File đã được lưu thành công!");


                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                app.Quit();
                workbook = null;
                worksheet = null;
            }
        }
    }
}



