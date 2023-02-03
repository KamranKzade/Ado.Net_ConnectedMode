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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ado.Net_HomeworkOne;

public partial class MainWindow : Window
{
    string connectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

    public MainWindow()
    {
        InitializeComponent();

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = connectionString;
            conn.Open();

            using (SqlCommand command = new("ShowAllBooks", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var bookId = reader["Id"] as int?;
                    var bookName = reader["Name"] as string;
                    var bookPages = reader["Pages"] as int?;
                    var bookYearPress = reader["YearPress"] as int?;
                    var comment = reader["Comment"] as string;
                    var quantity = reader["Quantity"] as int?;
                    var AuthorFullName = reader["AuthorFullName"] as string;
                    var ThemesName = reader["ThemesName"] as string;
                    var CategoryName = reader["CategoryName"] as string;
                    var PressName = reader["PressName"] as string;

                    var book = new Books(bookId, bookName!, bookPages, bookYearPress, comment, quantity, AuthorFullName,ThemesName,CategoryName,PressName);
                    myListView.Items.Add(book);
                  

                }

            }
        }
    }
}