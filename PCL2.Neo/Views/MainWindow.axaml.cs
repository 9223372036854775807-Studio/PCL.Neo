using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PCL2.Neo.Helpers;

namespace PCL2.Neo.Views;

/// <summary>
/// ��������
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// �����ڵĹ��캯������ʼ���������������¼�����
    /// </summary>
    public MainWindow()
    {
        // ��ʼ�����������XAML�ж�������пؼ�����Դ��
        InitializeComponent();

        // Ϊ���������߿��PointerPressed�¼��󶨴��������Ա㿪ʼ�϶����ڡ�
        NavBackgroundBorder.PointerPressed += OnNavPointerPressed;

        // ����ThemeHelperʵ����ˢ�����⣬��ȷ��Ӧ������ȷ��������ʽ��
        new ThemeHelper(this).Refresh();

        // Ϊ�رհ�ť����¼��󶨴����������ڹرմ��ڡ�
        BtnTitleClose.Click += (_, _) => Close();

        // Ϊ��С����ť����¼��󶨴����������ڽ�������С����
        BtnTitleMin.Click += (_, _) => WindowState = WindowState.Minimized;
    }
    /// <summary>
    /// �����������߿򱻰���ʱ���ã���ʼ�ƶ���ק���ڵĲ�����
    /// </summary>
    /// <param name="sender">�¼������ߡ�</param>
    /// <param name="e">�����¼����ݵ�PointerPressedEventArgs��</param>
    private void OnNavPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) {
        // ��ʼ��ק�����������û�ͨ������϶����ڡ�
        this.BeginMoveDrag(e);
    }
}