using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagementApp;

namespace TaskManagmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }
        private TaskManager taskManager;

        [TestInitialize]
        public void Setup()
        {
            taskManager = new TaskManager();
        }

        [TestMethod]
        public void AddTask_ShouldAddTaskToList()
        {
            var task = new TaskItem { Title = "Test Task", Description = "Test Description", DueDate = DateTime.Now, IsCompleted = false };

            taskManager.AddTask(task);
            var tasks = taskManager.GetAllTasks();

            Assert.AreEqual(1, tasks.Count, "Задача не была добавлена в список.");
            Assert.AreEqual("Test Task", tasks[0].Title, "Заголовок задачи не совпадает с ожидаемым.");
        }

        [TestMethod]
        public void DeleteTask_ShouldRemoveTaskFromList()
        {
            var task1 = new TaskItem { Title = "Task 1" };
            var task2 = new TaskItem { Title = "Task 2" };
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);

            taskManager.RemoveTask(task1);
            var tasks = taskManager.GetAllTasks();

            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual("Task 2", tasks[0].Title);
        }

        [TestMethod]
        public void AddTask_NullTask_ShouldNotAddTask()
        {
            TaskItem task = null;

            taskManager.AddTask(task);
            var tasks = taskManager.GetAllTasks();

            Assert.AreEqual(0, tasks.Count);
        }
    }
}
