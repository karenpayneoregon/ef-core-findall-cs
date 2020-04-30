using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleLibrary.Models;

namespace WindowsFormsApp1.Classes
{
    public static class CheckedListBoxExtensions
    {
        public static int[] SelectedCategoryIdentifier(this CheckedListBox sender)
        {
            return sender.Items.Cast<Categories>().Where((cat, index) => sender.GetItemChecked(index)).Select(item => item.CategoryId).ToArray();
        }
    }
}
