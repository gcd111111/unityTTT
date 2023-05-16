using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{
    private Texture myTexture;

    void Start()
    {
        TextureTest();
    }

    void OnGUI()
    {
        //�����ı���ͼƬ
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
        GUI.DrawTexture(new Rect(100, 100, myTexture.width, myTexture.height), myTexture);

        ////// ���ƴ��߿���ı�
        //public static void Box(Rect position, string text, GUIStyle style)
        //// ���ƴ��߿�ͼƬ
        //public static void Box(Rect position, Texture image, GUIStyle style)

        //���ư�ť
        //// ���ƴ��ı��İ�ť������̧��ʱ����true
        //public static bool Button(Rect position, string text, GUIStyle style)
        //// ���ƴ�ͼƬ�İ�ť������̧��ʱ����true
        //public static bool Button(Rect position, Texture image, GUIStyle style)

        //���Ƴ������������¼��İ�ť
        // ���ƴ��ı��İ�ť����סʱ��������true
        //public static bool RepeatButton(Rect position, string text, GUIStyle style)
        //// ���ƴ�ͼƬ�İ�ť����סʱ��������true
        //public static bool RepeatButton(Rect position, Texture image, GUIStyle style)
    }

    private void TextureTest()
    {
        myTexture = Resources.Load<Texture>("MyTexture");
    }

    //// �����ı�
    //    public static void Label(Rect position, string text, GUIStyle style);
    //// ����ͼƬ
    //   public static void Label(Rect position, Texture image, GUIStyle style);
    //    // Ӧ��
    //    GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    //    GUI.Label(new Rect(100, 100, texture.width, texture.height), texture);


}
//Unity 3D �ṩ�� GUI��NGUI��UGUI ��ͼ��ϵͳ������ǿ�������Ϸ�Ľ����ԡ�GUI �ڱ���ʱ���ܿ��ӻ���������ʱ���ܿ��ӻ���GUI ������Ҫ�� OnGUI �����е��ò��ܻ��ƣ����ַ�Ϊ�ֶ����֣�GUI�����Զ����֣�GUILayout����

//�ֶ����֣���Ҫ����Rect ������ָ����Ļ��������ͨ�� GUI ���ÿؼ�
//�Զ����֣�����Ҫ���� Rect �������Զ�����Ļ�в��֣�ͨ�� GUILayout ���ÿؼ�
//        ע�⣺��Ļ����ϵ�����Ͻ�Ϊԭ�㡣

//        GUI ����Ҫ�������¿ؼ���

//        Label�������ı���ͼƬ
//        Box������һ��ͼ�ο�
//        Button�����ư�ť����Ӧ�����¼�
//        RepeatButton������һ��������������¼��İ�ť
//        TextField������һ�������ı������
//        PasswordField������һ�����������
//        TextArea������һ�������ı������
//        Toggle������һ������
//        Toolbar�����ƹ�����
//        SelectionGrid������һ������ť
//        HorizontalSlider������һ��ˮƽ����Ļ�����
//        VerticalSlider������һ����ֱ����Ļ�����
//        HorizontalScrollbar������һ��ˮƽ����Ĺ�����
//        VerticalScrollbar������һ����ֱ����Ĺ�����
//        Window������һ�����ڣ��������ڷ��ÿؼ�
