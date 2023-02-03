using Ado.Net_HomeworkOne.Models;
using Ado.Net_HomeworkOne.Views;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Ado.Net_HomeworkOne;

public partial class MainWindow : Window
{
 

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        myListView.Items.Clear();

        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
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

                    var book = new Books(bookId, bookName!, bookPages, bookYearPress, comment!, quantity, AuthorFullName!, ThemesName!, CategoryName!, PressName!);
                    myListView.Items.Add(book);


                }

            }
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var obj = myListView.SelectedItem;
        var book = obj as Books;

        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString ;
            conn.Open();


            var param = new SqlParameter();
            param.ParameterName = "@booksId";
            param.SqlDbType = SqlDbType.Int;
            param.Value = book!.Id;


            using (SqlCommand command = new SqlCommand("DeleteBooks", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(param);

                var result = command.ExecuteNonQuery();

            }


           MessageBox.Show("Successfully Deleted");
        }

    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        AddBookWindow window = new AddBookWindow();
        window.ShowDialog();
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        var obj = myListView.SelectedItem;
        var book = obj as Books;

        UpdateBookWindow updateBook = new(book);
        updateBook.ShowDialog();
    }
}