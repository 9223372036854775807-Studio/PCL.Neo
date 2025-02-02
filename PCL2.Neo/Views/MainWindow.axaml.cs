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
    /// Constructor for the main window, initializes components and sets up related event handlers.
    /// </summary>
    public MainWindow()
    {
        // ��ʼ�����������XAML�ж�������пؼ�����Դ��
        // Initializes components, including all controls and resources defined in XAML.
        InitializeComponent();

        // Ϊ���������߿��PointerPressed�¼��󶨴��������Ա㿪ʼ�϶����ڡ�
        // Binds the handler method for the PointerPressed event of the navigation background border to start dragging the window.
        NavBackgroundBorder.PointerPressed += OnNavPointerPressed;

        // ����ThemeHelperʵ����ˢ�����⣬��ȷ��Ӧ������ȷ��������ʽ��
        // Creates an instance of ThemeHelper and refreshes the theme to ensure the correct theme style is applied.
        new ThemeHelper(this).Refresh();

        // Ϊ�رհ�ť����¼��󶨴����������ڹرմ��ڡ�
        // Binds the handler method for the click event of the close button to close the window.
        BtnTitleClose.Click += (_, _) => Close();

        // Ϊ��С����ť����¼��󶨴����������ڽ�������С����
        // Binds the handler method for the click event of the minimize button to minimize the window.
        BtnTitleMin.Click += (_, _) => WindowState = WindowState.Minimized;
    }
    /// <summary>
    /// �����������߿򱻰���ʱ���ã���ʼ�ƶ���ק���ڵĲ�����
    /// Called when the navigation background border is pressed, starts the operation to move and drag the window.
    /// </summary>
    /// <param name="sender">�¼������ߡ�</param>
    /// <param name="e">�����¼����ݵ�PointerPressedEventArgs��</param>
    private void OnNavPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) {
        // ��ʼ��ק�����������û�ͨ������϶����ڡ�
        // Starts a drag operation that allows the user to drag the window with the mouse.
        this.BeginMoveDrag(e);
    }
}