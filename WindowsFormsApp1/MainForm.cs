using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SampleLibrary.Models;
using System.Data.Linq.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using WindowsFormsApp1.Classes;
using SampleLibrary.Contexts;
using SampleLibrary.Extensions;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Shown += MainForm_Shown;
        }

        /// <summary>
        /// Read all categories without the change tracker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_Shown(object sender, EventArgs e)
        {
            using (var context = new NorthWindContext())
            {
                await Task.Run(async () =>
                {
                    var categories = await context.Categories.AsNoTracking().ToListAsync();
                    CategoryCheckedListBox.InvokeIfRequired(clb => clb.DataSource = categories);
                });
                
            }

            GetSelectedButton.Enabled = true;
        }
        private async void GetSelectedButton_Click(object sender, EventArgs e)
        {
            ResultsTextBox.Text = "";
            var sb = new StringBuilder();

            /*
             * Get all checked categories primary key in the checked list box
             */
            var indices = CategoryCheckedListBox.SelectedCategoryIdentifier();

            if (indices.Length <= 0) return;

            using (var context = new NorthWindContext())
            {
                /*
                 * Get all products for each category, not FindAllAsync expects an
                 * object array not an int array so they are converted via
                 * Array.ConvertAll.
                 */
                Categories[] categories = await context.FindAllAsync<Categories>(Array.ConvertAll(indices, id => (object)id));

                /*
                 * Display in a text box
                 */
                foreach (Categories category in categories)
                {
                    sb.AppendLine(category.CategoryName);

                    List<Products> products = context.Products
                        .AsNoTracking().Where(prod => prod.CategoryId == category.CategoryId)
                        .ToList();

                    foreach (Products product in products)
                    {
                        sb.AppendLine($"  {product.ProductId,-4}{product.ProductName}");   
                    }

                    sb.AppendLine();
                }

                ResultsTextBox.Text = sb.ToString();
            }
        }
    
    }
}
