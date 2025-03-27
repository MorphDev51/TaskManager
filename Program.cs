using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace TaskManager
{
    class TaskItem
    {
        string name;
        bool status;

        public TaskItem(string TaskName)
        {
            name = TaskName;
            status = false;
        }


        public void CompleteTask()
        {
            status = !status;
            Console.WriteLine($"Статус задачи \"{name}\" изменен на: {(status ? "Выполнена" : "Не выполнена")}");
        }
        public void ShowTask()
        {
            string taskStatus = status ? "Выполнена" : "Невыполнена";
            Console.WriteLine($"Задача: {name}, Статус: {taskStatus}");
        }
        public override string ToString()
        {
            return name;
        }

    }
    class Program
    {

        public static void AddTask(List<TaskItem> taskList)
        {
            Console.Write("Введите название задачи: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                taskList.Add(new TaskItem(name));
                Console.WriteLine("Задача успешно добавлена!");
            }
            else
            {
                Console.WriteLine("Ошибка: Название задачи не может быть пустым.");
            }
        }

        public static void ShowTaskList(List<TaskItem> taskList)
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            Console.WriteLine("Список задач: ");
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.Write($"{i + 1} ");
                taskList[i].ShowTask();
            }
        }
        public static void CompleteTask(List<TaskItem> taskList)
        {

            Console.Write("Выберите номер задачи, которую хотите отредактировать: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {
                taskList[taskNumber - 1].CompleteTask();
                return;
            }
            else
            {
                Console.WriteLine("Ошибка: Некорректный ввод");
            }

        }
        public static void RemoveTask(List<TaskItem> taskList)
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("Нет задач для удаления.");
                return;
            }
            Console.Write("Введите номер задачи, которую хотите удалить: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {
                string removedTask = taskList[taskNumber - 1].ToString();
                taskList.RemoveAt(taskNumber - 1);
                Console.WriteLine($"Задача \"{removedTask}\" удалена.");
            }
            else
            {
                Console.WriteLine("Ошибка: Некорректный ввод");
            }
        }
        static void Main(string[] args)
        {
            List<TaskItem> taskList = new List<TaskItem>();
            Console.WriteLine("Добро пожаловать в менеджер задач!");


            while (true)
            {
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Измененить статус задачи");
                Console.WriteLine("4. Показать все задачи");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(taskList);
                        break;
                    case "2":
                        RemoveTask(taskList);
                        break;
                    case "3":
                        CompleteTask(taskList);
                        break;
                    case "4":
                        ShowTaskList(taskList);
                        break;
                    case "5":
                        Console.WriteLine("Завершение работы программы...");
                        return;
                    default:
                        Console.WriteLine("Ошибка: Некорректный ввод");
                        break;
                }
            }
        }
    }
}