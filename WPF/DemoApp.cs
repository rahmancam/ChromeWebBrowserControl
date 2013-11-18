namespace WPF
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xilium.CefGlue;

    internal sealed class DemoApp : CefApp
    {
        private CefRenderProcessHandler _renderProcessHandler = new DemoRenderProcessHandler();

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            ;
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
        }
    }
}
