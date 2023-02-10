using System;
using System.Collections.Generic;
using System.Text;

namespace SafeBrowser_POC.Core
{
    public class ChangePageMessage
    {
        public readonly Type ViewModelType;

        public ChangePageMessage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
