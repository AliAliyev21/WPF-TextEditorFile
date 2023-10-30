using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppFile
{
    public static class Notifi
    {
        public static string NotifTextSavedSuccessfully(string fileName)
        {
            return $"Text saved successfully to {fileName}";
        }

        public static string NotifAutoSaveIsChecked(bool isChecked)
        {
            if (isChecked) return $"AutoSave turned ON";
            return $"AutoSave turned OFF";
        }
    }
}
