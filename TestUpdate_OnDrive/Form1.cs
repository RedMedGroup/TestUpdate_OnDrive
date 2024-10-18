using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TestUpdate_OnDrive
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Update()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebClient webClient = new WebClient();

            // رابط لملف نصي يحتوي على رقم الإصدار الأخير في GitHub Releases
            string versionUrl = "https://raw.githubusercontent.com/username/repository/main/version.txt";

            if (!webClient.DownloadString(versionUrl).Contains("1.0.0.0"))
            {
                if (MessageBox.Show("هل ترغب في تثبيت التحديث؟", "تحديث جديد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string updaterPath = System.IO.Path.Combine(appDataFolder, @"Your tst\Sonatrach\updater.exe");

                    if (File.Exists(updaterPath))
                    {
                        try
                        {
                            Process.Start(updaterPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حدث خطأ أثناء تشغيل المحدث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المحدث (updater.exe) في المسار المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void Update1()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebClient webClient = new WebClient();

            if (!webClient.DownloadString("https://www.dropbox.com/scl/fi/zewy4jv1mnr20bc0haf33/SHUpdate.txt?rlkey=7jv5vsdyg0bcv9oxqt09fc09y&st=wqjx7flb&dl=1").Contains("1.0.0.0"))
            {
                if (MessageBox.Show("هل ترغب في تثبيت التحديث؟", "تحديث جديد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // الحصول على مسار مجلد التطبيقات المحلية باستخدام Environment.GetFolderPath
                    string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    // تكوين مسار المحدث updater.exe داخل مجلد التطبيقات المحلية
                    string updaterPath = System.IO.Path.Combine(appDataFolder, @"Your tst\Sonatrach\updater.exe");

                    //string updaterPath = @"C:\Users\Roddik\AppData\Roaming\Your TEST\TEST\updater44.exe"; // تغيير المسار حسب مكان updater.exe على جهاز المستخدم
                    //C: \Users\Roddik\AppData\Roaming\Your tst\Sonatrach 4.0.0.0\install\Sonatrach1.cab
                    if (File.Exists(updaterPath))
                    {
                        try
                        {
                            // فتح updater.exe
                            Process.Start(updaterPath);

                            // إغلاق التطبيق الحالي (اختياري)
                            //this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حدث خطأ أثناء تشغيل المحدث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المحدث (updater.exe) في المسار المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
