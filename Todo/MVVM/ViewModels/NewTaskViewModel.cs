using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    public class NewTaskViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public string Task { get; set; }


    }
}
