using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace project
{
    static class Localization
    {
        public static void LocalFrmLoadOrCreate(FrmLoadOrCreateFile form, bool isEnglish)
        {
            if (!isEnglish)
            {
                form.BtnOpen.Text = "Открыть";
                form.BtnCreate.Text = "Создать";
                form.BtnCansel.Text = "Отмена";
                form.LblTitle.Text = "Файл:";
                form.textInput = "Введите имя файла";
                form.textError[0] = "Ошибка при открытии файла. Проверьте: первая строчка- тип данных";
                form.textError[1] = "Ошибка в имени файла";
                form.textError[2] = "Открыть файл";
                form.Text = "Открытие файла";
                form.Titles[0] = "Ошибка";
                form.Titles[1] = "Уведомление";
                if (form.listBox.Items[0].ToString() == "--History is empty--")
                {
                    form.listBox.Items.Clear();
                    form.listBox.Items.Add("--История пуста--");
                }
                form.closeFormMessage = "Закрыть форму?";
                form.closeFormTitle = "Закрытие";
            }
            else
            {
                form.BtnOpen.Text = "Open";
                form.BtnCreate.Text = "Create";
                form.BtnCansel.Text = "Cancel";
                form.LblTitle.Text = "File:";
                form.textInput = "Input file name";
                form.textError[0] = "Error when opening the file. Check: the first line is the data type";
                form.textError[1] = "Error in the file name";
                form.textError[2] = "Open a file";
                form.Text = "Opening a file";
                form.Titles[0] = "Error";
                form.Titles[1] = "Notification";
                if (form.listBox.Items[0].ToString() == "--История пуста--")
                {
                    form.listBox.Items.Clear();
                    form.listBox.Items.Add("--History is empty--");
                }
                form.closeFormMessage = "Close the form?";
                form.closeFormTitle = "Closing";
            }
            form.TextBox.Text = form.textInput;
        }
        public static void LocalFrmSetting(FrmSetting form, bool isEnglish)
        {
            if (!isEnglish)
            {
                form.Text = "Настройки";
                form.BtnAccept.Text = "Принять";
                form.BtnCancel.Text = "Отменить";
                form.textColor.Text = "Цветовая тема";
                form.textLanguage.Text = "Язык";

                if (form.ComboBoxColor.Items.Count == 0)
                {
                    form.ComboBoxColor.Items.Add("Светлая");
                    form.ComboBoxColor.Items.Add("Темная");
                    form.ComboBoxColor.Items.Add("Светло-синяя");
                }
                else
                {
                    form.ComboBoxColor.Items[0] = "Светлая";
                    form.ComboBoxColor.Items[1] = "Темная";
                    form.ComboBoxColor.Items[2] = "Светло-виолетовая";
                }
                if (form.ComboBoxLanguage.Items.Count == 0)
                {
                    form.ComboBoxLanguage.Items.Add("Русский");
                    form.ComboBoxLanguage.Items.Add("Английский");
                }
                else
                {
                    form.ComboBoxLanguage.Items[0] = ("Русский");
                    form.ComboBoxLanguage.Items[1] = ("Английский");
                    form.textLanguage.Location = new Point(93, 42);
                    form.textColor.Location = new Point(12, 12);
                }
                form.closeFormMessage = "Закрыть форму?";
                form.closeFormTitle = "Закрытие";
            }
            else
            {
                form.Text = "Settings";
                form.BtnAccept.Text = "Accept";
                form.BtnCancel.Text = "Cancel";
                form.textColor.Text = "Color Theme";
                form.textLanguage.Text = "Language";
                form.textLanguage.Location = new Point(63, 42);
                form.textColor.Location = new Point(34, 12);
                if (form.ComboBoxColor.Items.Count == 0)
                {
                    form.ComboBoxColor.Items.Add("Light");
                    form.ComboBoxColor.Items.Add("Dark");
                    form.ComboBoxColor.Items.Add("Light violet");
                }
                else
                {
                    form.ComboBoxColor.Items[0] = "Light";
                    form.ComboBoxColor.Items[1] = "Dark";
                    form.ComboBoxColor.Items[2] = "Light blue";
                }
                if (form.ComboBoxLanguage.Items.Count == 0)
                {
                    form.ComboBoxLanguage.Items.Add("Russian");
                    form.ComboBoxLanguage.Items.Add("English");
                }
                else
                {
                    form.ComboBoxLanguage.Items[0] = ("Russian");
                    form.ComboBoxLanguage.Items[1] = ("English");
                }
                form.closeFormMessage = "Close the form?";
                form.closeFormTitle = "Closing";
            }
        }
    }
}
