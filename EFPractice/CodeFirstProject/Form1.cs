using CodeFirstProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirstProject.DAL;

namespace CodeFirstProject
{
    public partial class Form1 : Form
    {
        DAL.AppContext context;
        public Form1()
        {
            InitializeComponent();
            context = new DAL.AppContext();
            AddAuthor();
        }

        public void AddAuthor()
        {
            Author author = new Author();
            author.Firstname = "Asgar";
            author.Lastname = "Agazade";
            author.Birthdate = new DateTime(1993, 3, 25);


            context.Authors.Add(author);
            context.SaveChanges();

        }


    }
}
