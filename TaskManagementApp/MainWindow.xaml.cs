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

namespace TaskManagementApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TaskItem> tasks;
        private TaskItem selectedTask;
        private TaskManager taskManager;
        public MainWindow()
        {
            InitializeComponent();
            taskManager = new TaskManager();
            tasks = new List<TaskItem>();
            UpdateTaskList();
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog dialog = new TaskDialog();
            if (dialog.ShowDialog() == true)
            {
                taskManager.AddTask(dialog.TaskItem);
                UpdateTaskList();
            }
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTask != null)
            {
                TaskDialog dialog = new TaskDialog(selectedTask);
                if (dialog.ShowDialog() == true)
                {
                    selectedTask.Title = dialog.TaskItem.Title;
                    selectedTask.Description = dialog.TaskItem.Description;
                    selectedTask.DueDate = dialog.TaskItem.DueDate;
                    selectedTask.IsCompleted = dialog.TaskItem.IsCompleted;
                    UpdateTaskList();
                }
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTask != null)
            {
                taskManager.RemoveTask(selectedTask);
                selectedTask = null;
                UpdateTaskList();
            }
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTask = (TaskItem)TaskListView.SelectedItem;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTaskList();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTaskList();
        }

        private void UpdateTaskList()
        {
            var filteredTasks = taskManager.GetAllTasks();

            // Фильтрация по статусу
            if (FilterComboBox.SelectedItem is ComboBoxItem selectedFilter)
            {
                if (selectedFilter.Content.ToString() == "Completed")
                {
                    filteredTasks = filteredTasks.FindAll(t => t.IsCompleted);
                }
                else if (selectedFilter.Content.ToString() == "Not Completed")
                {
                    filteredTasks = filteredTasks.FindAll(t => !t.IsCompleted);
                }
            }

            // Поиск по заголовку
            string searchText = SearchTextBox.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredTasks = filteredTasks.FindAll(t => t.Title.ToLower().Contains(searchText));
            }

            TaskListView.ItemsSource = null;
            TaskListView.ItemsSource = filteredTasks;
        }
    }
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
