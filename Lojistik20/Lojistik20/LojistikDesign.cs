using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Lojistik20
{
    class LojistikDesign
    {
        public static void DataGrid(DataGridView grd)
        {
            grd.Columns.Clear();
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grd.BackgroundColor = SystemColors.ControlLightLight;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F9D4");
            grd.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F5F7F8");
            grd.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2EB3F4");
            grd.RowHeadersWidth = 4;
        }
    }
}
