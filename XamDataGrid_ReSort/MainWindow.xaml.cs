using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace XamDataGrid_ReSort
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TestData> testData = null;
        public MainWindow()
        {
            InitializeComponent();

            testData = new ObservableCollection<TestData>();


            testData.Add(new TestData { Test1 = "1", Test2 = "Test4", Test3 = "Item1"});
            testData.Add(new TestData { Test1 = "2", Test2 = "Test1", Test3 = "Item2" });
            testData.Add(new TestData { Test1 = "3", Test2 = "Test2", Test3 = "Item3" });
            testData.Add(new TestData { Test1 = "4", Test2 = "Test5", Test3 = "Item3" });
            testData.Add(new TestData { Test1 = "5", Test2 = "Test5", Test3 = "Item1" });
            testData.Add(new TestData { Test1 = "6", Test2 = "Test7", Test3 = "Item1" });
            testData.Add(new TestData { Test1 = "7", Test2 = "Test1", Test3 = "Item2" });
            testData.Add(new TestData { Test1 = "8", Test2 = "Test6", Test3 = "Item2" });
            testData.Add(new TestData { Test1 = "9", Test2 = "Test2", Test3 = "Item3" });


            this.DataContext = testData;


            FieldSortDescription sortItem = new FieldSortDescription();
            sortItem.Direction = ListSortDirection.Ascending;
            sortItem.FieldName = "Test2";
            this.xamDataGrid1.FieldLayouts[0].SortedFields.Add(sortItem);
        }

        int counter = 10;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestData itemToAdd  = new TestData { Test1 = counter.ToString(), Test2 = "Test3", Test3 = "Item3" };
            testData.Add(itemToAdd);
            xamDataGrid1.GetRecordFromDataItem(itemToAdd, true).RefreshSortPosition();

            counter++;
        }
    }

    public class TestData : INotifyPropertyChanged
    {
        private String m_test1;
        public String Test1
        {
            get { return m_test1; }
            set
            {
                m_test1 = value;
                NotifyPropertyChanged("Test1");
            }
        }

        private String m_test2;
        public String Test2
        {
            get { return m_test2; }
            set
            {
                m_test2 = value;
                NotifyPropertyChanged("Test2");
            }
        }

        private String m_test3;
        public String Test3
        {
            get { return m_test3; }
            set
            {
                m_test3 = value;
                NotifyPropertyChanged("Test3");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

}
