using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    //继承Prism中的BindableBase，用于实现INotifyPropertyChanged接口，以便支持数据绑定。
    internal class MainWindowViewModel : BindableBase
    {
        //IRegionManager 是 Prism 框架中的一个接口，用于管理区域（regions），这些区域可以用来动态加载和显示不同的视图
        private readonly IRegionManager _regionManager;
        //DelegateCommand 是 Prism 框架中的一个命令类，用于处理用户交互事件
        public DelegateCommand<string> DelegateCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            DelegateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string obj)
        {
            //使用 _regionManager 的 Regions 属性获取名为 "ModuleContent" 的区域
            //调用 RequestNavigate 方法，传入 obj 作为导航的目标视图名称,RequestNavigate 方法会根据传入的视图名称，导航到相应的视图。
            _regionManager.Regions["ModuleContent"].RequestNavigate(obj);
        }
    }
}
