using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builder
{
    public partial class Form1 : Form
    {
        private PhoneBuilder phoneBuilder;

        public Form1()
        {
            InitializeComponent();
        }

        private void IPhoneBtn_Click(object sender, EventArgs e)
        {
            phoneBuilder = new IPhoneBuilder();
            zLabel.Text = "Тип телефона: IPhone";
            UpdateInfo();
        }

        private void AndroidBtn_Click(object sender, EventArgs e)
        {
            phoneBuilder = new AndroidBuilder();
            zLabel.Text = "Тип телефона: Android";
            UpdateInfo();
        }

        // Собрать только корпус и дислпей
        private void BuildPartiallyBtn_Click(object sender, EventArgs e)
        {
            if (phoneBuilder != null)
            {
                Phone phone = phoneBuilder.MountOnlyPhone();
                ShowPhoneInfo(phone);
            } 
            else
            {
                zLabel.Text = "Сначала выберите тип телефона.";
            }
        }

        // Собрать целый телефон
        private void BuildFullBtn_Click(object sender, EventArgs e)
        {
            if (phoneBuilder != null)
            {
                Phone phone = phoneBuilder.MountFullPhone();
                ShowPhoneInfo(phone);
            }
            else
            {
                zLabel.Text = "Сначала выберите тип телефона.";
            }
        }

        private void UpdateInfo()
        {
            Phone phone = phoneBuilder.GetPhone();
            ShowPhoneInfo(phone);
        }

        private void ShowPhoneInfo(Phone phone)
        {
            lblPhoneInfo.Text = phone.AboutPhone();
        }

        private void lblClear()
        {
            lblPhoneInfo.Text = string.Empty;
        }

        // Класс сборки телефона
        public class Phone
        {
            private string data;

            public Phone()
            {
                data = "";
            }

            // Получить информацию о разработанном телефоне
            public string AboutPhone()
            {
                return data;
            }

            // Сбор информации о стадии разработки
            public void AppendData(string str)
            {
                data += str;
            }
        }

        public abstract class PhoneBuilder
        {
            protected Phone phone;
            public Phone GetPhone()
            {
                return phone;
            }

            public abstract Phone MountOnlyPhone(); // Собрать телефон частично
            public abstract Phone MountFullPhone(); // Собрать целый телефон
        }

        public class AndroidBuilder : PhoneBuilder
        {

            public AndroidBuilder()
            {
                phone = new Phone();
            }

            // Реализация метода сборки только корпуса и дисплея
            public override Phone MountOnlyPhone()
            {
                phone.AppendData("Произведен корпус Samsung\n");
                phone.AppendData("Произведен дисплей Samsung\n");
                return phone;
            }

            // Реализация метода сборки целого телефона
            public override Phone MountFullPhone()
            {
                phone.AppendData("Произведен корпус Samsung;\n");
                phone.AppendData("Произведен дисплей Samsung;\n");
                phone.AppendData("Установлена система Android;\n");
                return phone;
            }
        }

        public class IPhoneBuilder : PhoneBuilder
        {
            public IPhoneBuilder()
            {
                phone = new Phone();
            }

            public override Phone MountOnlyPhone()
            {
                phone.AppendData("Произведен корпус Apple;\n");
                phone.AppendData("Произведен дисплей Apple;\n");
                return phone;
            }

            public override Phone MountFullPhone()
            {
                phone.AppendData("Произведен корпус Apple;\n");
                phone.AppendData("Произведен дисплей Apple;\n");
                phone.AppendData("Установлена система iOS;\n");
                return phone;
            }
        }
            
    }
}
