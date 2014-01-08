<CODEGEN_FILENAME>BackgroundDispatcher.dbl</CODEGEN_FILENAME>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Collections.Generic
import System.Text
import System.Threading
import System.Threading.Tasks
import System.Windows.Threading

namespace <NAMESPACE>

    ;;; <summary>
    ;;; The BackgroundDispatcher class can be used to control
    ;;; processing of background tasks on different threads
    ;;; </summary>
    public class BackgroundDispatcher implements IDisposable extends MarshalByRefObject
        
        ;;; <summary>
        ;;;
        ;;; </summary>
        public static property UtilityBackgroundDispatcher, @BackgroundDispatcher
            method get
            proc
                if (mActiveDispatcherList.Count == 0)
                begin
                    data item = new DispatcherItem()
                    item.BDitem = new BackgroundDispatcher()
                    item.referenceCount = 1
                    mActiveDispatcherList.Add(item)
                end
                mreturn mActiveDispatcherList[0].BDitem
            endmethod
        endproperty
        
        .define CONST_MaxReferenceCount	,10
        
        ;;private memebers
        private mThread	,@Thread
        private mDispatcher	,@Task<Dispatcher>
        
        ;;define the structure of live dispatchers
        class DispatcherItem
            public referenceCount, int
            public BDitem, @BackgroundDispatcher
        endclass
        
        ;;store a list of active dispatcher super channels
        private static mActiveDispatcherList, @List<DispatcherItem>, new List<DispatcherItem>()
        
        public static method AllocateDispatcher	,@BackgroundDispatcher
            endparams
        proc
            data item, @DispatcherItem
            foreach item in mActiveDispatcherList
            begin
                ;;have we got room
                if (item.referenceCount < CONST_MaxReferenceCount)
                begin
                    incr item.referenceCount
                    mreturn item.BDitem
                end
            end
            
            ;;if we are here then either no active dispatcher items or they are all full
            item = new DispatcherItem()
            item.BDitem = new BackgroundDispatcher()
            item.referenceCount = 1
            mActiveDispatcherList.Add(item)
            mreturn item.BDitem
        endmethod
        
        public static method DeallocateDispatcher, void
            in req	disp, @BackgroundDispatcher
            endparams
        proc
            data item, @DispatcherItem
            foreach item in mActiveDispatcherList
            begin
                ;;find the passd dispatcher object in our list
                if (item.BDitem == disp)
                begin
                    ;;found it, so remove it!!
                    decr item.referenceCount
                    if (item.referenceCount == 0 && item.BDitem != ^null)
                    begin
                        item.BDitem.Dispose()
                        item.BDitem = ^null
                        mActiveDispatcherList.Remove(item)
                        exitloop
                    end
                end
            end
            
        endmethod
        
        public static method ShutdownDispatcher, void
            endparams
        proc
            
            data item, @DispatcherItem
            foreach item in mActiveDispatcherList
            begin
                if (item.BDitem != ^null)
                begin
                    item.BDitem.Dispose()
                    item.BDitem = ^null
                end
            end
            mActiveDispatcherList.Clear()
        endmethod
        
        public method BackgroundDispatcher
            endparams
        proc
            ;;create a thread to run logic on
            data dispatcherTask = new TaskCompletionSource<Dispatcher>()
            mDispatcher = dispatcherTask.Task
            mThread = new Thread(runDispatcher)
            mThread.IsBackground = true
            mThread.Start(dispatcherTask)
        endmethod
        
        ;;create and run a new dispatcher
        private method runDispatcher, void
            sender, @Object
            endparams
        proc
            data dispatcherTask = ^as(sender, TaskCompletionSource<Dispatcher>)
            xcall s_server_thread_init()
            dispatcherTask.SetResult(Dispatcher.CurrentDispatcher)
            Dispatcher.Run()
        endmethod
        
        ;;; <summary>
        ;;;
        ;;; </summary>
        public method Dispose, void
            endparams
        proc
            if (mDispatcher != ^null)
            begin
                mDispatcher.Wait()
                mDispatcher.Result.InvokeShutdown()
            end
        endmethod
        
        internal method Dispatch, void
            operation, @AppDomainDispatcherHelper
            endparams
        proc
            ;;call the invokeHelper mether to execute the "operation" code and return the completion status
            mDispatcher.Wait()
            if (mDispatcher.Result.CheckAccess() == true) then
                invokeHelper(operation)
            else
                mDispatcher.Result.BeginInvoke((Action<AppDomainDispatcherHelper>)invokeHelper, new Object[#] {operation})
        endmethod
        
        ;;actually perform the required task/operation. completionSource reutns the status
        private method invokeHelper, void
            operation, @AppDomainDispatcherHelper
            endparams
        proc
            try
            begin
                operation.RunAction()
                operation.SetResult(true)
            end
            catch (e, @Exception)
            begin
                operation.SetException(e)
            end
            endtry
        endmethod
        
    endclass

    public static class BackgroundDispatcherExtension

        public static extension method Dispatch	,@Task
            theDispatcher, @BackgroundDispatcher
            operation, @Action
            endparams
        proc

            ;;create a handle to let things know when the task is complete (and it's sucess)
            data completionSource = new TaskCompletionSource<Boolean>()

            theDispatcher.Dispatch(new AppDomainDispatcherHelper(operation,completionSource))

            mreturn completionSource.Task

        endmethod

    endclass

    public class AppDomainDispatcherHelper extends MarshalByRefObject
        
        private theAction, @Action
        private completionSource, @TaskCompletionSource<Boolean>
        
        public method AppDomainDispatcherHelper
            required in anAction, @Action
            required in theCompletionSource, @TaskCompletionSource<Boolean>
            endparams
        proc
            theAction = anAction
            completionSource = theCompletionSource
        endmethod

        public method RunAction, void
            endparams
        proc
            theAction()
        endmethod

        public method SetResult, void
            theResult, boolean
            endparams
        proc
            completionSource.SetResult(theResult)
        endmethod
        
        public method SetException, void
            theException, @Exception
            endparams
        proc
            completionSource.SetException(theException)
        endmethod
        
    endclass

endnamespace
