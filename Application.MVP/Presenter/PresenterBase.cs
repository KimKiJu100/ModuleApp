using App.MVP.View;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace App.MVP.Presenter
{
    public abstract class PresenterBase<TView, TModel> : IDisposable
        where TView : IPresenterView
        where TModel : class
    {
        protected readonly IServiceProvider? _serviceProvider;
        protected readonly TView _view;
        protected readonly TModel _model;

        private bool disposedValue;
        public bool IsViewVisible { get => _view.Visible; }
        public bool IsViewDisposed { get => _view.IsDisposed; }
        public TView GetView { get => _view; }

        public abstract event EventHandler<PropertyChangedEventArgs> ModelChanged;
        protected abstract void InjectControl();
        protected abstract void Model_PropertyChanged(object sender, PropertyChangedEventArgs e);

        protected PresenterBase(TView view, TModel model)
        {
            _view = view;
            _model = model;
            InjectControl();
        }

        protected PresenterBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _view = _serviceProvider.GetRequiredService<TView>();
            _model = _serviceProvider.GetRequiredService<TModel>();
            InjectControl();
        }

        public virtual void ShowView()
        {
            if (_view != null)
                _view.Show();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~PresenterBase()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
