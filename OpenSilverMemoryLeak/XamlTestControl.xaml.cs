using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace OpenSilverMemoryLeak
{
    public partial class XamlTestControl : UserControl
    {
        public XamlTestControl()
        {
            this.InitializeComponent();

            Console.WriteLine("XamlTestControl Created");
        }

        ~XamlTestControl()
        {
            Console.WriteLine("XamlTestControl Deleted");
        }
    }
}
