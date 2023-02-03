using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Ado.Net_HomeworkOne.Views;

public partial class AddBookWindow : Window
{
    public AddBookWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            conn.Open();

            var paramId = new SqlParameter();
            paramId.ParameterName = "@Id";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Value = id_txt.Text;


            var paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.SqlDbType = SqlDbType.NVarChar;
            paramName.Value = name_txt.Text;


            var paramPages = new SqlParameter();
            paramPages.ParameterName = "@Pages";
            paramPages.SqlDbType = SqlDbType.Int;
            paramPages.Value = pages_txt.Text;

            var paramYear = new SqlParameter();
            paramYear.ParameterName = "@YearPress";
            paramYear.SqlDbType = SqlDbType.Int;
            paramYear.Value = yearpress_txt.Text;

            var paramThemes = new SqlParameter();
            paramThemes.ParameterName = "@Id_Themes";
            paramThemes.SqlDbType = SqlDbType.Int;
            paramThemes.Value = idThemes_txt.Text;

            var paramCategory = new SqlParameter();
            paramCategory.ParameterName = "@Id_Category";
            paramCategory.SqlDbType = SqlDbType.Int;
            paramCategory.Value = idCategory_txt.Text;


            var paramAuthor = new SqlParameter();
            paramAuthor.ParameterName = "@Id_Author";
            paramAuthor.SqlDbType = SqlDbType.Int;
            paramAuthor.Value = idAuthor_txt.Text;

            var paramPress = new SqlParameter();
            paramPress.ParameterName = "@Id_Press";
            paramPress.SqlDbType = SqlDbType.Int;
            paramPress.Value = idPress_txt.Text;

            var paramComment = new SqlParameter();
            paramComment.ParameterName = "@Comment";
            paramComment.SqlDbType = SqlDbType.NVarChar;
            paramComment.Value = comment_txt.Text;

            var paramQuantity = new SqlParameter();
            paramQuantity.ParameterName = "@Quantity";
            paramQuantity.SqlDbType = SqlDbType.Int;
            paramQuantity.Value = quantity_txt.Text;

            using (SqlCommand command = new SqlCommand("InsertBook", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(paramId);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramPages);
                command.Parameters.Add(paramYear);
                command.Parameters.Add(paramThemes);
                command.Parameters.Add(paramCategory);
                command.Parameters.Add(paramAuthor);
                command.Parameters.Add(paramPress);
                command.Parameters.Add(paramComment);
                command.Parameters.Add(paramQuantity);

                var result = command.ExecuteNonQuery();
                MessageBox.Show($"{result} rows affected");
            }

            DialogResult = true;
        }
    }
}
