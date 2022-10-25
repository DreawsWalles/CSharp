using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class FormTask : Form
    {
        public FormTask()
        {
            InitializeComponent();
            richTextBox1.SelectionRightIndent = 30;
            richTextBox1.ReadOnly = true;
            MaximumSize = Size;
            MinimumSize = Size;

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 20, FontStyle.Bold);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionColor = Color.DarkOrange;
            richTextBox1.SelectedText = "Двойные списки\n";
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.SelectionIndent = 16;
            richTextBox1.SelectedText = "       Разработать библиотеку обобщенных классов для работы с двусвязными списками данных. В структуру классов входят:";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            richTextBox1.SelectionBullet = true;
            richTextBox1.BulletIndent = 12;
            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 30;
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> : ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IEnumerable";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectedText = ">";
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectedText = " – базовый интерфейс для всех двусвязных списков;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTextBox1.SelectionIndent = 42;
            richTextBox1.SelectionColor = Color.DarkOrange;
            richTextBox1.SelectedText = "Методы:";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 54;
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "Add";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "value";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "Clear";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "();";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "void bool ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "Contains";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "value";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "IndexOf";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "value";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "Insert";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "index";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ", ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "value";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "Remove";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "value";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "RemoveAt";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "index";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += "\n";
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.SelectedText = "sublist";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "fromIndex";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ", ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "toIndex";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ");";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';

            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTextBox1.SelectionIndent = 42;
            richTextBox1.SelectionColor = Color.DarkOrange;
            richTextBox1.SelectedText = "Свойства:";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 54;
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "Count;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "this";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "[";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.SelectedText = "index";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "];";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 30;
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListException ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectedText = "– класс, описывающий исключения, которые могут происходить в ходе работы с двусвязным списком;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ArrayList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">: ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectedText = "– класс двусвязного списка на основе массива;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "LinkedList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">: ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectedText = " – класс двусвязного списка на основе связного списка;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "UnmutableList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">: ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectedText = " – класс неизменяющегося двусвязного списка, является оберткой над любым существующим списком;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListUtils";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Wheat;
            richTextBox1.SelectedText = " – класс различных операций над двусвязным списком;";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTextBox1.SelectionColor = Color.DarkOrange;
            richTextBox1.SelectionIndent = 42;
            richTextBox1.SelectedText = "Методы:";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 54;
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static bool ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "Exists";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "Find";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectedText = "static ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "FindLast";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "FindIndex";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static int ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "FindLastIndex";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "FindAll";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListConstructorDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TO";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ConvertAll";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TI";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ", ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TO";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TI";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ConvertDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TI";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ", ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TO";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListConstructorDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "TO";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ForEach";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ActionDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static void ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "Sort";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CompareDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static bool ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckForAll";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "(";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "IList";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">, ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "CheckDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ">);";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTextBox1.SelectionIndent = 42;
            richTextBox1.SelectionColor = Color.DarkOrange;
            richTextBox1.SelectedText = "Свойства:";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 54;
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static readonly ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListConstructorDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ArrayListConstructor";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ";";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionIndent = 54;
            richTextBox1.SelectionColor = Color.RoyalBlue;
            richTextBox1.SelectedText = "static readonly ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "ListConstructorDelegate";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "<";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.YellowGreen;
            richTextBox1.SelectedText = "T";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = "> ";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.SpringGreen;
            richTextBox1.SelectedText = "LinkedListConstructor";
            richTextBox1.SelectionFont = new Font("Times New Roman", 14);
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectedText = ";";
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.SelectedText += '\n';
            richTextBox1.SelectionBullet = false;
            //-----------------------------------------------------------------

            richTextBox1.SelectionStart = 0;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormTask_Resize(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
