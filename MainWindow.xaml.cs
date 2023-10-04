using System;
using System.Windows;

namespace ToDoList_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbChoosePrio.Items.Add("--SELECT PRIO--");
            cbChooseTask.Items.Add("--SELECT TASK--");

            // Laddar comboboxen med våra Enum-objekt. 
            foreach (Priority p in Enum.GetValues<Priority>())
            {
                cbChoosePrio.Items.Add(p);
            }

            foreach (TaskType t in Enum.GetValues<TaskType>())
            {
                cbChooseTask.Items.Add(t);
            }

            // Kommer defaulta så att vi valt index 0 från början: 
            cbChoosePrio.SelectedIndex = 0;
            cbChooseTask.SelectedIndex = 0;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (cbChoosePrio.SelectedIndex != 0 && cbChooseTask.SelectedIndex != 0)
            {
                // Casta selectedItem till vår Enum type. 
                Priority priority = (Priority)cbChoosePrio.SelectedItem;
                TaskType task = (TaskType)cbChooseTask.SelectedItem;

                //Skapa ett nytt task-objekt
                Task t = new();

                // Assigna Enum-värden till task-objektet 
                t.Priority = priority;
                t.TaskType = task;

                // Publicera info om objektet till ListView. 
                MyTaskView.Items.Add(t.GetTaskInfo());
            }
        }

        private void MyTaskView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            lblTask.Content = MyTaskView.SelectedItem;
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            object remove = MyTaskView.SelectedItem;
            MyTaskView.Items?.Remove(remove);
            lblTask.Content = "Removed!";
        }
    }
}
