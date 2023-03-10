using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.MvvmNames.Mobile.ViewModels
{
    public class SettingsViewModel : FreshBasePageModel
    {

        public SettingsViewModel() 
        {
        
        }

        public override void Init(object initData)
        {
            int parameter = (int) initData;
            base.Init(initData);
        }
    }
}
