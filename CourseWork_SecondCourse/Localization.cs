using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
                    form.ComboBoxColor.Items.Add("Светло-фиолетовая");
                }
                else
                {
                    form.ComboBoxColor.Items[0] = "Светлая";
                    form.ComboBoxColor.Items[1] = "Темная";
                    form.ComboBoxColor.Items[2] = "Светло-фиолетовая";
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
                    form.ComboBoxColor.Items[2] = "Light violet";
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
        public static void LocalFrmColor(FrmColor form, bool isEnglish)
        {
            if (!isEnglish)
            {
                form.closeFormMessage = "Закрыть форму?";
                form.closeFormTitle = "Закрытие";
                form.Text = "Смена цвета";
                form.BtnAccept.Text = "Принять";
                form.BtnCancel.Text = "Отменить";
            }
            else
            {
                form.closeFormMessage = "Close the form?";
                form.closeFormTitle = "Closing";
                form.Text = "Color change";
                form.BtnAccept.Text = "Accept";
                form.BtnCancel.Text = "Cancel";
            }
        }
        public static void LocalFrmMain(FrmMain form, bool isEnglish)
        {
            if (!isEnglish)
            {
                form.Notifications[0] = "Файл создан";
                form.Notifications[1] = "Файл не сохранен, так как не было открыто ни одного файла";
                form.Notifications[2] = "Файл сохранен";
                form.Notifications[3] = "Ни одного файла не было открыто";
                form.Notifications[4] = "Закрыть файл";
                form.Notifications[5] = "Cохранить файл";
                form.Notifications[6] = "Завершить работу программы?";
                form.Notifications[7] = "Файл не удалось открыть";
                form.Notifications[8] = "Элемент усешно добавлен";
                form.Titles[0] = "Курсовая работа.exe";
                form.Titles[1] = "Уведомления";
                form.Titles[2] = "Ошибка";
                form.textForFilms[0] = "Кинокомпания";
                form.textForFilms[1] = "Фильм";
                form.textForFilms[2] = "Режиссер";
                form.textForFilms[3] = "Длительность";
                form.textForFilms[4] = "Дата выхода";
                form.textForFilms[5] = "Главные герои";
                form.textForFilms[6] = "Призы";
                ToolStripMenuItem element = (ToolStripMenuItem)form.mainMenu.Items[0];
                element.Text = "Файл";
                element.DropDownItems[0].Text = "Создать";
                element.DropDownItems[1].Text = "Открыть";
                element.DropDownItems[2].Text = "Закрыть";
                element.DropDownItems[3].Text = "Сохранить";
                element.DropDownItems[4].Text = "Сохранить как...";
                element.DropDownItems[5].Text = "Выход";
                element = (ToolStripMenuItem)form.mainMenu.Items[1];
                element.Text = "Проект";
                element.DropDownItems[0].Text = "Добавить элемент";
                element.DropDownItems[1].Text = "Сортировать элементы...";
                element.DropDownItems[2].Text = "Настройки";
                element = (ToolStripMenuItem)element.DropDownItems[1];
                element.DropDownItems[0].Text = "С внутренней сортировкой";
                element.DropDownItems[1].Text = "Без внутренней сортировки";
            }
            else
            {
                form.Notifications[0] = "The file has been created";
                form.Notifications[1] = "The file was not saved because no files were opened";
                form.Notifications[2] = "The file is saved";
                form.Notifications[3] = "Not a single file was opened";
                form.Notifications[4] = "Close the file";
                form.Notifications[5] = "Save a file";
                form.Notifications[6] = "Terminate the program?";
                form.Notifications[7] = "The file could not be opened";
                form.Notifications[8] = "The item was successfully added";
                form.Titles[0] = "Course work.exe";
                form.Titles[1] = "Notifications";
                form.Titles[2] = "Mistake";
                form.textForFilms[0] = "Film company";
                form.textForFilms[1] = "Film";
                form.textForFilms[2] = "Director";
                form.textForFilms[3] = "Duration";
                form.textForFilms[4] = "Release date";
                form.textForFilms[5] = "The main characters";
                form.textForFilms[6] = "Prizes";
                ToolStripMenuItem element = (ToolStripMenuItem)form.mainMenu.Items[0];
                element.Text = "File";
                element.DropDownItems[0].Text = "Create";
                element.DropDownItems[1].Text = "Open";
                element.DropDownItems[2].Text = "Close";
                element.DropDownItems[3].Text = "Save";
                element.DropDownItems[4].Text = "Save as...";
                element.DropDownItems[5].Text = "Exit";
                element = (ToolStripMenuItem)form.mainMenu.Items[1];
                element.Text = "Project";
                element.DropDownItems[0].Text = "Append element";
                element.DropDownItems[1].Text = "Sort elements...";
                element.DropDownItems[2].Text = "Settings";
                element = (ToolStripMenuItem)element.DropDownItems[1];
                element.DropDownItems[0].Text = "With internal sorting";
                element.DropDownItems[1].Text = "Without internal sorting";
            }
        }
        public static void LocalFrmInputFilm(FrmInputFilm form, bool isEnglish)
        {
            if (!isEnglish)
            {
                form.TextForUser[0] = "Введите название фильма";
                form.TextForUser[1] = "Введите название киностудии";
                form.TextForUser[2] = "Введите режиссера";
                form.TextForUser[3] = "Введите продолжительность";
                form.TextForUser[4] = "Введите призы";
                form.TextForUser[5] = "Введите призы через запzтую. Если призы отсутствуют введите -";
                form.TextForUser[6] = "Введите главных героев";
                form.TextForUser[7] = "Считан некорректный символ: ";
                form.TextForUser[8] = " . Повторите ввод";
                form.TextForUser[9] = "Считанное значение некорректно.Значение должно быть больше 0";
                form.TextForUser[10] = "Введите призы, отделяя их запятой";
                form.TextForUser[11] = "Введите главных героев, отделяя их запятой";
                form.Titles[0] = "Добавление элемента";
                form.Titles[1] = "Уведомление";
                form.Titles[2] = "Ошибка";
                form.Notofocations[0] = "Не все поля заполнены";
                form.Notofocations[1] = "Введена пустая строка. Повторите ввод";
                form.labels[0].Text = "Название фильма";
                form.labels[1].Text = "Год выпуска";
                form.labels[2].Text = "Киностудия";
                form.labels[3].Text = "Режиссер";
                form.labels[4].Text = "Длительность фильма";
                form.labels[5].Text = "Наличия приза";
                form.labels[6].Text = "Главные герои";
                //form.BtnAdd.Text = "Добавить";
            }
            else
            {
                form.TextForUser[0] = "Enter the name of the movie";
                form.TextForUser[1] = "Enter the name of the film studio";
                form.TextForUser[2] = "Enter the director";
                form.TextForUser[3] = "Enter the duration";
                form.TextForUser[4] = "Enter the prizes";
                form.TextForUser[5] = "Enter the prizes separated by commas. If there are no prizes enter -";
                form.TextForUser[6] = "Enter the main characters";
                form.TextForUser[7] = "Invalid character was read: ";
                form.TextForUser[8] = " . Repeat the input";
                form.TextForUser[9] = "The read value is incorrect.The value must be greater than 0";
                form.TextForUser[10] = "Enter the prizes, separating them with a comma";
                form.TextForUser[11] = "Enter the main characters, separating them with a comma";
                form.Titles[0] = "Adding an element";
                form.Titles[1] = "Notification";
                form.Titles[2] = "Error";
                form.Notofocations[0] = "Not all fields are filled in";
                form.Notofocations[1] = "An empty string was entered. Repeat the input";
                form.labels[0].Text = "The name of the movie";
                form.labels[1].Text = "Year of release";
                form.labels[2].Text = "Film Studio";
                form.labels[3].Text = "Director";
                form.labels[4].Text = "Duration of the movie";
                form.labels[5].Text = "Availability of a prize";
                form.labels[6].Text = "The main characters";
                form.BtnAdd.Text = "Add";
            }
        }
        public static void LocalFrmInput(FrmInput form, bool isEnglish)
        {
            if(!isEnglish)
            {
                form.Text = "Добавление элементаы";
                form.Title = "Уведомление";
                form.BtnAccept.Text = "Ввести";
            }
            else
            {
                form.Text = "Adding an element";
                form.Title = "Notification";
                form.BtnAccept.Text = "Enter";
            }
        }
    }
}
