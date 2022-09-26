using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using OpenSilver;

namespace OpenSilverMemoryLeak
{
    public partial class MainPage : Page
    {
        public static readonly Model Data = new Model();

        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("START GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("END GC");
        }

        private int number = 0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SP.Children.Add(new XamlTestControl
            {
                Name = "MyTest" + number++,
                DataContext = Data
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SP.Children.Remove(SP.Children.Last());
        }
    }

    public class TestControl : TextBlock
    {
        private Model _model = new Model();

        public TestControl()
        {
        }
    }
}





public class Model : INotifyPropertyChanged
{
    public Model()
    {
        Height = 10;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private int _height;

    public int Height
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
            OnPropertyChanged();
        }
    }
}

public class TestObject2
{
    public TestObject TO { get; set; }
}

public class TestObject
{
    public string Id { get; }

    public TestObject(string id)
    {
        Id = id;
        TO2 = new Dictionary<string, TestObject2>();
    }

    public Dictionary<string, TestObject2> TO2 { get; set; }

    ~TestObject()
    {
        Console.WriteLine("TEST OBJECT WAS DELETED. ID - " + Id);
    }
}

public class TestHandler
{
    public void Test()
    {
        Console.WriteLine("Test Handler");
    }
}