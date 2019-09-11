using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFirstProject.Models;

namespace DBFirstProject
{
    public partial class Form1 : Form
    {
        private readonly P112NewsEntities db;

        public Form1()
        {
            InitializeComponent();
            db = new P112NewsEntities();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] categories = db.Categories.Select(c => c.Name).OrderBy(c => c).ToArray();

            cbxCategory.Items.AddRange(categories);


            List<News> allNews = db.News.ToList();
            foreach (News item in allNews)
            {
                string categoryName = "";
                if (item.Category != null)
                {
                    categoryName = item.Category.Name;
                }
                dgvNews.Rows.Add(item.Id,
                    item.CategoryId,
                    item.Title,
                    item.Content,
                    categoryName,
                    item.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    item.ViewCount);
            }
        }
    }
}
