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
            // �����ȡ
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<Text>();

            // ��������
            mBtnAdd.onClick.AddListener(() =>
            {
                // �����߼�
                mCount++;
                // �����߼�
                UpdateView();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                // �����߼�
                mCount--;
                // �����߼�
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
#region �㼶����
//���ֲ㣺IController
//ϵͳ�㣺ISystem
//���ݲ㣺IModel
//���߲㣺IUtility
//������һ�ݲ㼶�Ĺ������£�

//���ֲ㣺ViewController�㡣IController�ӿڣ�������������״̬�仯ʱ�ı��֣�һ������£�MonoBehaviour ��Ϊ���ֲ�
//���Ի�ȡSystem
//���Ի�ȡModel
//���Է���Command
//���Լ���Event
//ϵͳ�㣺System�㡣ISystem�ӿڣ�����IController�е�һ�����߼����ڶ�����ֲ㹲����߼��������ʱϵͳ���̳�ϵͳ���ɾ�ϵͳ��
//���Ի�ȡSystem
//���Ի�ȡModel
//���Լ���Event
//���Է���Event
//���ݲ㣺Model�㡣IModel�ӿڣ��������ݵĶ��塢���ݵ���ɾ��ķ������ṩ
//���Ի�ȡUtility
//���Է���Event
//���߲㣺Utility�㡣IUtility�ӿڣ������ṩ������ʩ������洢���������л��������������ӷ���������������SDK����ܼ̳еȡ�ɶ���ɲ��ˣ����Լ��ɵ������⣬���߷�װAPI
//�����ĸ��㼶������һ�����ĸ����Command
//���Ի�ȡSystem
//���Ի�ȡModel
//���Է���Event
//���Է���Command
//�㼶����
//IController ���� ISystem��IModel ��״̬������Command
//ISystem��IModel״̬���������֪ͨIController�������¼���BindableProperty
//IController���Ի�ȡISystem��IModel�������������ݲ�ѯ
//ICommand������״̬
//�ϲ����ֱ�ӻ�ȡ�²㣬�²㲻�ܻ�ȡ�ϲ����
//�²����ϲ�ͨ�����¼�
//�ϲ����²�ͨ���÷������ã�ֻ������ѯ��״̬�����Command����IController�Ľ����߼�Ϊ�ر������ֻ����Command
#endregion
#region //1.����modelʹ���ݹ���

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // Controller
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                Model.Count++;
//                // �����߼�
//                UpdateView();
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                Model.Count--;
//                // �����߼�
//                UpdateView();
//            });

//            UpdateView();
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//2.����command���controllerӷ��

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // ���� Command
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
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand<IncreaseCountCommand>(); // û�в������������֧�ַ���
//                // �����߼�
//                UpdateView();
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand(new DecreaseCountCommand()); // Ҳ֧��ֱ�Ӵ�����󣨷���ͨ�����촫��)
//                // �����߼�
//                UpdateView();
//            });

//            UpdateView();
//        }

//        void UpdateView()
//        {
//            mCountText.text = Model.Count.ToString();
//        }

//        /// <summary>
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//3.CQRS ԭ�������¼�����д����ԭ��.���ٱ����߼�
//using QFramework;
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = 0;
//        }
//    }

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());
//        }
//    }

//    // �������ݱ���¼�
//    public struct CountChangeEvent // ++
//    {

//    }

//    // ���� Command
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
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand<IncreaseCountCommand>(); // û�в������������֧�ַ���
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand(new DecreaseCountCommand()); // Ҳ֧��ֱ�Ӵ�����󣨷���ͨ�����촫��)
//            });

//            UpdateView();

//            // �����߼�
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
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//4.����Utility,֧��counterApp�Ĵ洢����

//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // Ҳ����ͨ�� CounterApp.Interface �������ݱ���¼�
//            CounterApp.Interface.RegisterEvent<CountChangeEvent>(e =>
//            {
//                this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
//            });
//        }
//    }

//    // ����洢 Utility ��
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

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            this.RegisterModel(new CounterAppModel());

//            // ע��洢���߶���
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // �������ݱ���¼�
//    public struct CountChangeEvent
//    {

//    }

//    // ���� Command
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
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand<IncreaseCountCommand>(); // û�в������������֧�ַ���
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand(new DecreaseCountCommand()); // Ҳ֧��ֱ�Ӵ�����󣨷���ͨ�����촫��)
//            });

//            UpdateView();

//            // �����߼�
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
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region//5.����System������������ɾ�ϵͳ�ȴ��벻�ʺϷ�ɢд��command����ʺ���һ��System��
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        public int Count;

//        protected override void OnInit()
//        {
//            Count = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // Ҳ����ͨ�� CounterApp.Interface �������ݱ���¼�
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
//                    Debug.Log("���� ������� �ɾ�");
//                }
//                else if (model.Count == 20)
//                {
//                    Debug.Log("���� ���ר�� �ɾ�");
//                }
//                else if (model.Count == -10)
//                {
//                    Debug.Log("���� ������� �ɾ�");
//                }
//            });
//        }
//    }

//    // ����洢 Utility ��
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

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            // ע��ɾ�ϵͳ
//            this.RegisterSystem(new AchievementSystem());

//            this.RegisterModel(new CounterAppModel());

//            // ע��洢���߶���
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // �������ݱ���¼�
//    public struct CountChangeEvent
//    {

//    }

//    // ���� Command
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
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand<IncreaseCountCommand>(); // û�в������������֧�ַ���
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand(new DecreaseCountCommand()); // Ҳ֧��ֱ�Ӵ�����󣨷���ͨ�����촫��)
//            });

//            UpdateView();

//            // �����߼�
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
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}

#endregion

#region  6.BindableProperty ���ݼ��¼��ļ��ϣ�ʹ�� BindableProperty ���Խ�ʡ�����Ĵ��롣BindableProperty �����������Ϊ�˶Դ��������Ż���������ʹ�á����� BIndableProperty ��������ȫ����¼����ƣ���������ı��������һЩ������֪ͨ�¼�������Ҫ���¼����ơ�
//using UnityEngine;
//using UnityEngine.UI;

//namespace QFramework.Example
//{
//    // ����һ�� Model ����
//    public class CounterAppModel : AbstractModel
//    {
//        // ����
//        public BindableProperty<int> Count = new BindableProperty<int>();

//        protected override void OnInit()
//        {
//            // ����ֵ
//            Count.Value = this.GetUtility<Storage>().LoadInt(nameof(Count));

//            // �������ݱ��
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

//            // �������ݱ���¼�
//            model.Count.Register(count =>
//            {
//                if (count == 10)
//                {
//                    Debug.Log("���� ������� �ɾ�");
//                }
//                else if (count == 20)
//                {
//                    Debug.Log("���� ���ר�� �ɾ�");
//                }
//                else if (count == -10)
//                {
//                    Debug.Log("���� ������� �ɾ�");
//                }
//            });
//        }
//    }

//    // ����洢 Utility ��
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

//    // ����һ���ܹ������ڹ���ģ�飩
//    public class CounterApp : Architecture<CounterApp>
//    {
//        protected override void Init()
//        {
//            // ע��ɾ�ϵͳ
//            this.RegisterSystem(new AchievementSystem());

//            this.RegisterModel(new CounterAppModel());

//            // ע��洢���߶���
//            this.RegisterUtility(new Storage());
//        }
//    }

//    // �������ݱ���¼�
//    public struct CountChangeEvent
//    {

//    }

//    // ���� Command
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
//    public class CounterAppController : MonoBehaviour, IController // ʵ�� IController �ӿ�
//    {
//        // View
//        private Button mBtnAdd;
//        private Button mBtnSub;
//        private Text mCountText;

//        // Model
//        private CounterAppModel Model;

//        private void Start()
//        {
//            // ��ȡģ��
//            Model = this.GetModel<CounterAppModel>();


//            // �����ȡ
//            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
//            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
//            mCountText = transform.Find("CountText").GetComponent<Text>();

//            // ��������
//            mBtnAdd.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand<IncreaseCountCommand>(); // û�в������������֧�ַ���
//            });

//            mBtnSub.onClick.AddListener(() =>
//            {
//                // �����߼�
//                this.SendCommand(new DecreaseCountCommand()); // Ҳ֧��ֱ�Ӵ�����󣨷���ͨ�����촫��)
//            });

//            // ���ݱ���¼�����
//            Model.Count.RegisterWithInitValue(count =>
//            {
//                mCountText.text = count.ToString();

//            }).UnRegisterWhenGameObjectDestroyed(gameObject);
//        }

//        /// <summary>
//        /// ָ���ܹ�
//        /// </summary>
//        public IArchitecture GetArchitecture()
//        {
//            return CounterApp.Interface;
//        }
//    }
//}
#endregion

#region 7.�����Ѵ洢�� API �� PlayerPrefs �л��� EasySave����ô���ǲ���Ҫȥ�޸� Storage ���󣬶�����չһ�� IStorage �ӿڼ���

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
//Ȼ��ע������Ϊ���£�

//public class CounterApp : Architecture<CounterApp>
//{
//    protected override void Init()
//    {
//        // ע��ɾ�ϵͳ
//        this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

//        this.RegisterModel<ICounterAppModel>(new CounterAppModel());

//        // ע��洢���߶���
//        // this.RegisterUtility<IStorage>(new Storage());
//        this.RegisterUtility<IStorage>(new EasySaveStorage());
//    }
//}
#endregion

#region ���ȱ����߼������ǽ��յ����ݱ���¼�֮�󣬶� Model ���� System ���в�ѯ�����Ҳ�ѯ��ʱ����Ҫ��ϲ�ѯ�������� Model һ���ѯ����ѯ�����ݻ���Ҫ�ڴ���һ�£����ֲ�ѯ�Ĵ������Ƚ϶ࡣ�ⲿ�ִ����е���Ŀ��ǳ��࣬��������ģ�⾭Ӫ���߷ǳ������ݵ���Ŀ������ QFramework ֧�� Query ������һ���������������⡣
//��ʹ�÷�ʽҲ�ܼ򵥣��� Command �÷�һ�£���������:

//    public class FiveTimesCountQuery : AbstractQuery<int> // int �Ƿ���ֵ
//{
//    protected override int OnDo()
//    {
//        return this.GetModel<ICounterAppModel>().Count.Value * 5;
//    }
//}
//�� Controller �еĵ��÷�ʽ���£�

//int result = this.SendQuery(new FiveTimesCountQuery());
//Debug.Log(result);
#endregion