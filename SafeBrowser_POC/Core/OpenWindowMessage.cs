using System;
using System.Collections.Generic;
using System.Text;

namespace SafeBrowser_POC.Core
{
    public class OpenWindowMessage
    {

        public readonly Type ViewModelType;

        public OpenWindowMessage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
