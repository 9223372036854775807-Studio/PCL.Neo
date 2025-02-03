using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PCL2.Neo.ViewModels;

namespace PCL2.Neo
{
    /// <summary>
    /// ��ͼ��λ���࣬ʵ����IDataTemplate�ӿڣ����ڸ���ViewModel��̬������Ӧ��View��
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        /// <summary>
        /// �����ṩ�Ĳ�������������һ��Controlʵ�����������Ϊnull���򷵻�null��
        /// </summary>
        /// <param name="param">Ҫת��Ϊ��ͼ�Ķ���ͨ����һ��ViewModel��</param>
        /// <returns>������ViewModel��������ͼControlʵ�������û���ҵ�ƥ�����ͼ���򷵻�һ����ʾ"Not Found: [��ͼ����]"�ı���TextBlock��</returns>
        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            // ��ViewModel�������������е�"ViewModel"�滻Ϊ"View"�Ի�ȡ��Ӧ����ͼ��������
            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                // ʹ�÷��䴴��ָ�����͵�ʵ����
                return (Control)Activator.CreateInstance(type)!;
            }

            // ����Ҳ�����Ӧ����ͼ���ͣ��򷵻�һ����ʾδ�ҵ���Ϣ��TextBlock��
            return new TextBlock { Text = "Not Found: " + name };
        }
        /// <summary>
        /// �ж��ṩ�����ݶ����Ƿ�ƥ���ģ�塣�����ж����ݶ����Ƿ���ViewModelBase���ͻ��������͡�
        /// </summary>
        /// <param name="data">Ҫ�������ݶ���</param>
        /// <returns>������ݶ�����ViewModelBase���ͻ��������ͣ��򷵻�true�����򷵻�false��</returns>
        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
