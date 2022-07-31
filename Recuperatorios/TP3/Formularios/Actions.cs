using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    internal static class Actions
    {
        public static void ActionsDGV<T>(DataGridView dgv, List<T> list)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;
        }
    }
}
