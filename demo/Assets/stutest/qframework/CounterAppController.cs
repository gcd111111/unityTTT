using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    // Controller
    public class CounterAppController : MonoBehaviour
    {
        // View
        private Button mBtnAdd;
        private Button mBtnSub;
        private Text mCountText;

        // Model
        private int mCount = 0;

        private void Start()
        {
            // 组件获取
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<Text>();

            // 监听输入
            mBtnAdd.onClick.AddListener(() =>
            {
                // 交互逻辑
                mCount++;
                // 表现逻辑
                UpdateView();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                // 交互逻辑
                mCount--;
                // 表现逻辑
                UpdateView();
            });

            UpdateView();
        }

        void UpdateView()
        {
            mCountText.text = mCount.ToString();
        }
    }
}
#region 层级规则
//表现层：IController
//系统层：ISystem
//数据层：IModel
//工具层：IUtility
//这里有一份层级的规则，如下：

//表现层：ViewController层。IController接口，负责接收输入和状态变化时的表现，一般情况下，MonoBehaviour 均为表现层
//可以获取System
//可以获取Model
//可以发送Command
//可以监听Event
//系统层：System层。ISystem接口，帮助IController承担一部分逻辑，在多个表现层共享的逻辑，比如计时系统、商城系统、成就系统等
//可以获取System
//可以获取Model
//可以监听Event
//可以发送Event
//数据层：Model层。IModel接口，负责数据的定义、数据的增删查改方法的提供
//可以获取Utility
//可以发送Event
//工具层：Utility层。IUtility接口，负责提供基础设施，比如存储方法、序列化方法、网络连接方法、蓝牙方法、SDK、框架继承等。啥都干不了，可以集成第三方库，或者封装API
//除了四个层级，还有一个核心概念——Command
//可以获取System
//可以获取Model
//可以发送Event
//可以发送Command
//层级规则：
//IController 更改 ISystem、IModel 的状态必须用Command
//ISystem、IModel状态发生变更后通知IController必须用事件或BindableProperty
//IController可以获取ISystem、IModel对象来进行数据查询
//ICommand不能有状态
//上层可以直接获取下层，下层不能获取上层对象
//下层向上层通信用事件
//上层向下层通信用方法调用（只是做查询，状态变更用Command），IController的交互逻辑为特别情况，只能用Command
#endregion
#region //1.引入model使数据共享

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                Model.Count++;
//                // 表现逻辑
//                UpdateView();
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                Model.Count--;
//                // 表现逻辑
//                UpdateView();
//            });

//            UpdateView();
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//2.引入command解决controller臃肿

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // 引入 Command
//    public class IncreaseCountCommand : AbstractCommand // ++
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count++;
//        }
//    }

//    public class DecreaseCountCommand : AbstractCommand // ++
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count--;
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand<IncreaseCountCommand>(); // 没有参数构造的命令支持泛型
//                // 表现逻辑
//                UpdateView();
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand(new DecreaseCountCommand()); // 也支持直接传入对象（方便通过构造传参)
//                // 表现逻辑
//                UpdateView();
//            });

//            UpdateView();
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//3.CQRS 原则，引入事件，读写分离原则.减少表现逻辑
//using QFramework;
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // 定义数据变更事件
//    public struct CountChangeEvent // ++
//    {

//    }

//    // 引入 Command
//    public class IncreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count++;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    public class DecreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count--;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand<IncreaseCountCommand>(); // 没有参数构造的命令支持泛型
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand(new DecreaseCountCommand()); // 也支持直接传入对象（方便通过构造传参)
//            });

//            UpdateView();

//            // 表现逻辑
//            // ++ 
//            this.RegisterEvent<CountChangeEvent>(e =>
//            {
//                UpdateView();
//            }).UnRegisterWhenGameObjectDestroyed(gameObject);
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//4.引入Utility,支持counterApp的存储功能

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // 也可以通过 CounterApp.Interface 监听数据变更事件
//            CounterApp.Interface.RegisterEvent<CountChangeEvent>(e =>
//            {
//                this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
//            });
//        }
//    }

//    // 定义存储 Utility 层
//    public class Storage : IUtility
//    {
//        public void SaveInt(string key, int value)
//        {
//            PlayerPrefs.SetInt(key, value);
//        }

//        public int LoadInt(string key, int defaultValue = 0)
//        {
//            return PlayerPrefs.GetInt(key, defaultValue);
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());

//            // 注册存储工具对象
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // 定义数据变更事件
//    public struct CountChangeEvent
//    {

//    }

//    // 引入 Command
//    public class IncreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count++;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    public class DecreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count--;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand<IncreaseCountCommand>(); // 没有参数构造的命令支持泛型
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand(new DecreaseCountCommand()); // 也支持直接传入对象（方便通过构造传参)
//            });

//            UpdateView();

//            // 表现逻辑
//            this.RegisterEvent<CountChangeEvent>(e =>
//            {
//                UpdateView();
//            }).UnRegisterWhenGameObjectDestroyed(gameObject);
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//5.引入System，解决分数，成就系统等代码不适合分散写在command里，而适合在一个System里
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // 也可以通过 CounterApp.Interface 监听数据变更事件
//            CounterApp.Interface.RegisterEvent<CountChangeEvent>(e =>
//            {
//                this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
//            });
//        }
//    }

//    public class AchievementSystem : AbstractSystem
//    {
//        protected override void OnInit()
//        {
//            var model = this.GetModel<CounterAppModel>();

//            this.RegisterEvent<CountChangeEvent>(e =>
//            {

//                if (model.Count == 10)
//                {
//                    Debug.Log("触发 点击达人 成就");
//                }
//                else if (model.Count == 20)
//                {
//                    Debug.Log("触发 点击专家 成就");
//                }
//                else if (model.Count == -10)
//                {
//                    Debug.Log("触发 点击菜鸟 成就");
//                }
//            });
//        }
//    }

//    // 定义存储 Utility 层
//    public class Storage : IUtility
//    {
//        public void SaveInt(string key, int value)
//        {
//            PlayerPrefs.SetInt(key, value);
//        }

//        public int LoadInt(string key, int defaultValue = 0)
//        {
//            return PlayerPrefs.GetInt(key, defaultValue);
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            // 注册成就系统
//            this.RegisterSystem(new AchievementSystem());

//            this.RegisterModel(new CounterAppModel());

//            // 注册存储工具对象
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // 定义数据变更事件
//    public struct CountChangeEvent
//    {

//    }

//    // 引入 Command
//    public class IncreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count++;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    public class DecreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count--;
//            this.SendEvent<CountChangeEvent>();
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand<IncreaseCountCommand>(); // 没有参数构造的命令支持泛型
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand(new DecreaseCountCommand()); // 也支持直接传入对象（方便通过构造传参)
//            });

//            UpdateView();

//            // 表现逻辑
//            this.RegisterEvent<CountChangeEvent>(e =>
//            {
//                UpdateView();
//            }).UnRegisterWhenGameObjectDestroyed(gameObject);
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}

#endregion

#region  6.BindableProperty 数据加事件的集合，使用 BindableProperty 可以节省大量的代码。BindableProperty 的引入仅仅是为了对代码量做优化，方便大家使用。但是 BIndableProperty 并不能完全替代事件机制，比如数组的变更或者是一些其他的通知事件还是需要用事件机制。
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // 定义一个 Model 对象
//    public class CounterAppModel : AbstractModel
//    {
//        // 数据
//        public BindableProperty<int> Count = new BindableProperty<int>();

//        protected override void OnInit()
//        {
//            // 设置值
//            Count.Value = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // 监听数据变更
//            Count.Register(count =>
//            {
//                this.GetUtility<Storage>().SaveInt(nameof(Count), count);
//            });
//        }
//    }

//    public class AchievementSystem : AbstractSystem
//    {
//        protected override void OnInit()
//        {
//            var model = this.GetModel<CounterAppModel>();

//            // 监听数据变更事件
//            model.Count.Register(count =>
//            {
//                if (count == 10)
//                {
//                    Debug.Log("触发 点击达人 成就");
//                }
//                else if (count == 20)
//                {
//                    Debug.Log("触发 点击专家 成就");
//                }
//                else if (count == -10)
//                {
//                    Debug.Log("触发 点击菜鸟 成就");
//                }
//            });
//        }
//    }

//    // 定义存储 Utility 层
//    public class Storage : IUtility
//    {
//        public void SaveInt(string key, int value)
//        {
//            PlayerPrefs.SetInt(key, value);
//        }

//        public int LoadInt(string key, int defaultValue = 0)
//        {
//            return PlayerPrefs.GetInt(key, defaultValue);
//        }
//    }

//    // 定义一个架构（用于管理模块）
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            // 注册成就系统
//            this.RegisterSystem(new AchievementSystem());

//            this.RegisterModel(new CounterAppModel());

//            // 注册存储工具对象
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // 定义数据变更事件
//    public struct CountChangeEvent
//    {

//    }

//    // 引入 Command
//    public class IncreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count.Value++;
//        }
//    }

//    public class DecreaseCountCommand : AbstractCommand
//    {
//        protected override void OnExecute()
//        {
//            this.GetModel<CounterAppModel>().Count.Value--;
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // 实现 IController 接口
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // 获取模型
//            Model = this.GetModel<CounterAppModel>();


//            // 组件获取
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // 监听输入
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand<IncreaseCountCommand>(); // 没有参数构造的命令支持泛型
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // 交互逻辑
//                this.SendCommand(new DecreaseCountCommand()); // 也支持直接传入对象（方便通过构造传参)
//            });

//            // 数据变更事件监听
//            Model.Count.RegisterWithInitValue(count =>
//            {
//                mCountText.text = count.ToString();

//            }).UnRegisterWhenGameObjectDestroyed(gameObject);
//        }

//        /// <summary>
//        /// 指定架构
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region 7.如果想把存储的 API 从 PlayerPrefs 切换成 EasySave，那么我们不需要去修改 Storage 对象，而是扩展一个 IStorage 接口即可

//public class EasySaveStorage : IStorage
//{
//    public void SaveInt(string key, int value)
//    {
//        // todo
//    }

//    public int LoadInt(string key, int defaultValue = 0)
//    {
//        // todo
//        throw new System.NotImplementedException();
//    }
//}
//然后注册代码改为以下：

//public class CounterApp : Architecture<CounterApp>
//{
//    protected override void Init()
//    {
//        // 注册成就系统
//        this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

//        this.RegisterModel<ICounterAppModel>(new CounterAppModel());

//        // 注册存储工具对象
//        // this.RegisterUtility<IStorage>(new Storage());
//        this.RegisterUtility<IStorage>(new EasySaveStorage());
//    }
//}
#endregion

#region 首先表现逻辑更多是接收到数据变更事件之后，对 Model 或者 System 进行查询，而且查询的时候需要组合查询，比如多个 Model 一起查询，查询的数据还需要在处理一下，这种查询的代码量比较多。这部分代码有的项目会非常多，尤其是像模拟经营或者非常重数据的项目，所以 QFramework 支持 Query 这样的一个概念，来解决这问题。
//其使用方式也很简单，和 Command 用法一致，代码如下:

//    public class FiveTimesCountQuery : AbstractQuery<int> // int 是返回值
//{
//    protected override int OnDo()
//    {
//        return this.GetModel<ICounterAppModel>().Count.Value * 5;
//    }
//}
//在 Controller 中的调用方式如下：

//int result = this.SendQuery(new FiveTimesCountQuery());
//Debug.Log(result);
#endregion