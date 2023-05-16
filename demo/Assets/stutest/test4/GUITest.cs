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
        //绘制文本与图片
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
        GUI.DrawTexture(new Rect(100, 100, myTexture.width, myTexture.height), myTexture);

        ////// 绘制带边框的文本
        //public static void Box(Rect position, string text, GUIStyle style)
        //// 绘制带边框图片
        //public static void Box(Rect position, Texture image, GUIStyle style)

        //绘制按钮
        //// 绘制带文本的按钮，单击抬起时返回true
        //public static bool Button(Rect position, string text, GUIStyle style)
        //// 绘制带图片的按钮，单击抬起时返回true
        //public static bool Button(Rect position, Texture image, GUIStyle style)

        //绘制出力持续按下事件的按钮
        // 绘制带文本的按钮，按住时持续返回true
        //public static bool RepeatButton(Rect position, string text, GUIStyle style)
        //// 绘制带图片的按钮，按住时持续返回true
        //public static bool RepeatButton(Rect position, Texture image, GUIStyle style)
    }

    private void TextureTest()
    {
        myTexture = Resources.Load<Texture>("MyTexture");
    }

    //// 绘制文本
    //    public static void Label(Rect position, string text, GUIStyle style);
    //// 绘制图片
    //   public static void Label(Rect position, Texture image, GUIStyle style);
    //    // 应用
    //    GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    //    GUI.Label(new Rect(100, 100, texture.width, texture.height), texture);


}
//Unity 3D 提供了 GUI、NGUI、UGUI 等图形系统，以增强玩家与游戏的交互性。GUI 在编译时不能可视化，在运行时才能可视化。GUI 代码需要在 OnGUI 函数中调用才能绘制，布局分为手动布局（GUI）和自动布局（GUILayout）。

//手动布局：需要传人Rect 参数来指定屏幕绘制区域，通过 GUI 调用控件
//自动布局：不需要传入 Rect 参数，自动在屏幕中布局，通过 GUILayout 调用控件
//        注意：屏幕坐标系以左上角为原点。

//        GUI 中主要包含以下控件：

//        Label：绘制文本和图片
//        Box：绘制一个图形框
//        Button：绘制按钮，响应单击事件
//        RepeatButton：绘制一个处理持续按下事件的按钮
//        TextField：绘制一个单行文本输入框
//        PasswordField：绘制一个秘密输入框
//        TextArea：绘制一个多行文本输入框
//        Toggle：绘制一个开关
//        Toolbar：绘制工具条
//        SelectionGrid：绘制一组网格按钮
//        HorizontalSlider：绘制一个水平方向的滑动条
//        VerticalSlider：绘制一个垂直方向的滑动条
//        HorizontalScrollbar：绘制一个水平方向的滚动条
//        VerticalScrollbar：绘制一个垂直方向的滚动条
//        Window：绘制一个窗口，可以用于放置控件
