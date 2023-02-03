using Ado.Net_HomeworkOne.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ado.Net_HomeworkOne.Views;


public partial class UpdateBookWindow : Window
{
    Books books;

    public UpdateBookWindow(Books book)
    {
        InitializeComponent();
        books = book;

        name_txt.Text = book.Name;
        pages_txt.Text = book.Pages.ToString();
        yearpress_txt.Text = book.YearPress.ToString();
        comment_txt.Text = book.Comment.ToString();
        quantity_txt.Text = book.Quantity.ToString();

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            conn.Open();

            var paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.SqlDbType = SqlDbType.NVarChar;
            paramName.Value = books.Name;



            var paramNewName = new SqlParameter();
            paramNewName.ParameterName = "@NewName";
            paramNewName.SqlDbType = SqlDbType.NVarChar;
            paramNewName.Value = name_txt.Text;

            // Pages
            var paramPages = new SqlParameter();
            paramPages.ParameterName = "@Pages";
            paramPages.SqlDbType = SqlDbType.Int;
            paramPages.Value = books.Pages;



            var paramNewPages = new SqlParameter();
            paramNewPages.ParameterName = "@NewPages";
            paramNewPages.SqlDbType = SqlDbType.Int;
            paramNewPages.Value = pages_txt.Text;

            //yearpress

            var paramPress = new SqlParameter();
            paramPress.ParameterName = "@YearPress";
            paramPress.SqlDbType = SqlDbType.Int;
            paramPress.Value = books.YearPress;



            var paramNewPress = new SqlParameter();
            paramNewPress.ParameterName = "@NewYearPress";
            paramNewPress.SqlDbType = SqlDbType.Int;
            paramNewPress.Value = yearpress_txt.Text;

            // comment
            var paramComment = new SqlParameter();
            paramComment.ParameterName = "@Comment";
            paramComment.SqlDbType = SqlDbType.NVarChar;
            paramComment.Value = books.Comment;



            var paramNewComment = new SqlParameter();
            paramNewComment.ParameterName = "@NewComment";
            paramNewComment.SqlDbType = SqlDbType.NVarChar;
            paramNewComment.Value = comment_txt.Text;

            // quantity
            var paramquantity = new SqlParameter();
            paramquantity.ParameterName = "@Quantity";
            paramquantity.SqlDbType = SqlDbType.Int;
            paramquantity.Value = books.Quantity;



            var paramNewquantity = new SqlParameter();
            paramNewquantity.ParameterName = "@NewQuantity";
            paramNewquantity.SqlDbType = SqlDbType.Int;
            paramNewquantity.Value = quantity_txt.Text;

            using (SqlCommand command = new("UpdateBook", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramNewName);
                command.Parameters.Add(paramPages);
                command.Parameters.Add(paramNewPages);
                command.Parameters.Add(paramquantity);
                command.Parameters.Add(paramNewquantity);
                command.Parameters.Add(paramComment);
                command.Parameters.Add(paramNewComment);
                command.Parameters.Add(paramPress);
                command.Parameters.Add(paramNewPress);


                var result = command.ExecuteNonQuery();
                MessageBox.Show($"{result} row affected");
            }
        }
        DialogResult = true;
    }

}