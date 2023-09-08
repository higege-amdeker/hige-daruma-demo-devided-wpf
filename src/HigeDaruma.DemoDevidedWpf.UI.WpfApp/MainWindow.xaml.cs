﻿using System;
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

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ContentRendered += (s, e) => GetAccount();
    }

    private void GetAccount()
    {
        Guid id = new("ffffffff-ffff-ffff-ffff-ffffffffffff");
        string name = "DemoName";

        Id.Text = id.ToString();
        Name.Text = name;
    }
}
