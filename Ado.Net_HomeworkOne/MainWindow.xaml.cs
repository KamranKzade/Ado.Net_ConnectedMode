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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ado.Net_HomeworkOne;

public partial class MainWindow : Window
{
    string connectionString = "Data Source=DESKTOP-E15UN3T;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=False;";

    public MainWindow()
    {
        InitializeComponent();
    }

}