using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PCL2.Neo.ViewModels;

namespace PCL2.Neo
{
    /// <summary>
    /// ��ͼ��λ���࣬ʵ����IDataTemplate�ӿڣ����ڸ���ViewModel��̬������Ӧ��View��
    /// View locator class that implements the IDataTemplate interface, used for dynamically creating corresponding Views based on ViewModels.
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        /// <summary>
        /// �����ṩ�Ĳ�������������һ��Controlʵ�����������Ϊnull���򷵻�null��
        /// Builds and returns a Control instance based on the provided parameter. Returns null if the parameter is null.
        /// </summary>
        /// <param name="param">Ҫת��Ϊ��ͼ�Ķ���ͨ����һ��ViewModel��</param>
        /// <returns>������ViewModel��������ͼControlʵ�������û���ҵ�ƥ�����ͼ���򷵻�һ����ʾ"Not Found: [��ͼ����]"�ı���TextBlock��</returns>
        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            // ��ViewModel�������������е�"ViewModel"�滻Ϊ"View"�Ի�ȡ��Ӧ����ͼ��������
            // Replaces "ViewModel" with "View" in the full type name of the ViewModel to get the corresponding view type name.
            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                // ʹ�÷��䴴��ָ�����͵�ʵ����
                // Creates an instance of the specified type using reflection.
                return (Control)Activator.CreateInstance(type)!;
            }

            // ����Ҳ�����Ӧ����ͼ���ͣ��򷵻�һ����ʾδ�ҵ���Ϣ��TextBlock��
            // If no matching view type is found, returns a TextBlock displaying not found information.
            return new TextBlock { Text = "Not Found: " + name };
        }
        /// <summary>
        /// �ж��ṩ�����ݶ����Ƿ�ƥ���ģ�塣�����ж����ݶ����Ƿ���ViewModelBase���ͻ��������͡�
        /// Determines whether the provided data object matches this template. Here it checks if the data object is of type ViewModelBase or its subtypes.
        /// </summary>
        /// <param name="data">Ҫ�������ݶ���</param>
        /// <returns>������ݶ�����ViewModelBase���ͻ��������ͣ��򷵻�true�����򷵻�false��</returns>
        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
