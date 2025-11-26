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

namespace TaskManagementApp
{
    /// <summary>
    /// Логика взаимодействия для TaskDialog.xaml
    /// </summary>
    public partial class TaskDialog : Window
    {
        public TaskItem TaskItem { get; private set; }
        public TaskDialog(TaskItem taskItem = null)
        {
            InitializeComponent();
            if (taskItem != null)
            {
                TitleTextBox.Text = taskItem.Title;
                DescriptionTextBox.Text = taskItem.Description;
                DueDatePicker.SelectedDate = taskItem.DueDate;
                IsCompletedCheckBox.IsChecked = taskItem.IsCompleted;

                TaskItem = taskItem;
            }
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskItem = new TaskItem
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                DueDate = DueDatePicker.SelectedDate ?? DateTime.Now,
                IsCompleted = IsCompletedCheckBox.IsChecked ?? false
            };

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
