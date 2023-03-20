using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> action)
        {
            DoExecute = action;
        }

        public event EventHandler? CanExecuteChanged;
        public Func<object, bool>? CanExecution { set; get; }
        public Action<object>? DoExecute { set; get; }

        /// <summary>
        /// IsEnabled="False" 就不会发起命令操作
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanExecute(object? parameter)
        {
            if (CanExecution != null)
            {
                CanExecute(parameter);
            }
            return true;
        }

        /// <summary>
        /// 真正执行命令的方法
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object? parameter)
        {
            DoExecute!.Invoke(parameter!);
        }
    }
}
