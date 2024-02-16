using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace InterviewQA
{
    /*
    It is always recommended to use Dispose method to clean 
    unmanaged resources.
    A Dispose method should call the GC.SuppressFinalize() method 
    for the object of a class which has destructor 
    because it has already done the work to clean up the object, 
    then it is not necessary for the garbage collector 
    to call the object's Finalize method. 
    */
    public class ImplementDisposeFinalize : IDisposable
    {
        /*
        The SafeHandle class provides critical finalization of handle resources, 
        preventing handles from being reclaimed prematurely by garbage collection 
        and from being recycled by Windows to 
        reference unintended unmanaged objects.*/
        public bool disposeValue;

        //instantiate a safe handle resource
        private SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        //Finalizer or Destructor
        ~ImplementDisposeFinalize()
        {
            Dispose(false);
        }

        //public implementation of Dispose pattern
        public void Dispose()
        {
            Dispose(true);

            //this should only be called if the class has finalizer/destructor
            GC.SuppressFinalize(this);
        }

        //protected implementation of Dispose pattern
        protected void Dispose(bool disposing)
        {
            if (!disposeValue)
            {
                if (disposing)
                {
                    safeHandle.Dispose();
                }
                disposeValue = true;
            }
        }
    }
}