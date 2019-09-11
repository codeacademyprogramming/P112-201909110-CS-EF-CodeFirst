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
        News selectedNews;
        public Form1()
        {
            InitializeComponent();
            selectedNews = null;
            db = new P112NewsEntities();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Butun bolmeleri doldurun");
                return;
            } 

            News news = new News
            {
                Title = txtTitle.Text,
                Content = rtxtContent.Text,
                CreatedAt = DateTime.Now,
                ViewCount = 0
            };

            Category category = db.Categories.FirstOrDefault(c => c.Name == cbxCategory.SelectedItem);
            news.CategoryId = category.Id;
            db.News.Add(news);
            db.SaveChanges();


            ResetForm();
            FillGridView();
        }


        public void ResetForm()
        {
            txtTitle.Text = "";
            rtxtContent.Text = "";
            cbxCategory.SelectedIndex = -1;
        }

        public void FillGridView()
        {
            string[] categories = db.Categories.Select(c => c.Name).OrderBy(c => c).ToArray();

            cbxCategory.Items.AddRange(categories);

            dgvNews.Rows.Clear();
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

        public bool ValidateForm()
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(txtTitle.Text) && 
                !string.IsNullOrEmpty(rtxtContent.Text) &&
                (cbxCategory.SelectedIndex >= 0))
            {
                isValid = true;
            }

            return isValid;
        }

        private void DgvNews_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;

            int selectedNewsId = (int)dgvNews.Rows[e.RowIndex].Cells[0].Value;
            selectedNews = db.News.Find(selectedNewsId);

            txtTitle.Text = selectedNews.Title;
            rtxtContent.Text = selectedNews.Content;
            if (selectedNews.Category != null)
            {
                cbxCategory.SelectedItem = selectedNews.Category.Name;

            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Butun bolmeleri doldurun");
                return;
            }

            selectedNews.Title = txtTitle.Text;
            selectedNews.Content = rtxtContent.Text;


            Category category = db.Categories.FirstOrDefault(c => c.Name == cbxCategory.SelectedItem);
            selectedNews.CategoryId = category.Id;

            db.SaveChanges();

            ResetForm();
            FillGridView();
        }
    }
}
