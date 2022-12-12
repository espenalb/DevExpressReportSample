using DevExpress.Mvvm;
using System;
using System.Collections.Generic;

namespace DevExpressReportSample
{
    public class MyServiceProvider : IServiceContainer
    {        

        private readonly ServiceContainer _container;

        private MyServiceProvider(object owner)
        {
            _container = new ServiceContainer(owner);

            //_container.RegisterService()
    }



        public static void Init(object owner)
        {
            DevExpress.Mvvm.ServiceContainer.Default = new MyServiceProvider(owner);
        }

        public void Clear()
        {
            ((IServiceContainer)_container).Clear();
        }

        public object GetService(Type type, string key, ServiceSearchMode searchMode, out bool serviceHasKey)
        {
            serviceHasKey = false;
            if (type == typeof(DevExpress.Xpf.Printing.PreviewControl.Native.IPreviewAreaProvider))
                return new DevExpress.Xpf.Printing.PreviewControl.Native.PreviewAreaProvider(); // <- This fixes the Service problem - but now it crashes intead inside the previewareaprovider
            throw new NotSupportedException();
        }

        public T GetService<T>(string key, ServiceSearchMode searchMode, out bool serviceHasKey) where T : class
        {
            return ((IServiceContainer)_container).GetService<T>(key, searchMode, out serviceHasKey);
        }

        public T GetService<T>(ServiceSearchMode searchMode = ServiceSearchMode.PreferLocal) where T : class
        {
            return ((IServiceContainer)_container).GetService<T>(searchMode);
        }

        public T GetService<T>(string key, ServiceSearchMode searchMode = ServiceSearchMode.PreferLocal) where T : class
        {
            return ((IServiceContainer)_container).GetService<T>(key, searchMode);
        }

        public IEnumerable<object> GetServices(Type type, bool localOnly)
        {
            return ((IServiceContainer)_container).GetServices(type, localOnly);
        }

        public void RegisterService(object service, bool yieldToParent = false)
        {
            ((IServiceContainer)_container).RegisterService(service, yieldToParent);
        }

        public void RegisterService(string key, object service, bool yieldToParent = false)
        {
            ((IServiceContainer)_container).RegisterService(key, service, yieldToParent);
        }

        public void UnregisterService(object service)
        {
            ((IServiceContainer)_container).UnregisterService(service);
        }
    }
}
