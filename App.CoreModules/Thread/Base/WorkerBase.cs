using App.CoreModules.Thread.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class WorkerBase : IConditionWorkerInfo, IGenericWorkerAction, IDisposable
    {
        private bool disposedValue;

        protected internal Task task;

        public virtual string InstanceKey { get; set; }
        public virtual bool IsRunning { get; protected set; }
        public virtual string ActionName { get; }

        public virtual async Task StartAsync() { }
        public virtual void TaskStop() { }

        public virtual void Wait()
        {
            if (task is null) throw new Exception("Worker에 해당 Task를 설정하지 않았습니다.");
            task?.Wait();
        }

        #region Event 정의
        public event EventHandler Completed;
        public event EventHandler Canceled;
        protected virtual void OnCompleted(object InvokeInstance)
        {
            Completed?.Invoke(InvokeInstance, EventArgs.Empty);
        }
        protected virtual void OnCanceled(object InvokeInstance)
        {
            Canceled?.Invoke(InvokeInstance, EventArgs.Empty);
        }
        #endregion

        #region Dispose 패턴
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    task = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~WorkerBase()
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
        #endregion Dispose 패턴
    }
}
