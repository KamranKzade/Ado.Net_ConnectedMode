using Ado.Net_HomeworkOne.Models;
using System;
using System.Collections.Generic;
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
    public UpdateBookWindow(Books book)
    {
        InitializeComponent();

        id_txt.Text = book.Id.ToString();
        name_txt.Text = book.Name;
        pages_txt.Text = book.Pages.ToString();
        yearpress_txt.Text = book.YearPress.ToString();
        comment_txt.Text = book.Comment.ToString();
        quantity_txt.Text = book.Quantity.ToString();

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}
