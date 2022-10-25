using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace project
{
    public partial class FormMain : Form
    {
        IList<int> list_int;//1
        IList<char> list_char;//3
        IList<string> list_string;//6
        IList<float> list_float;//2
        IList<double> list_double;//4
        IList<bool> list_bool;//5
        IList<MyType> list_myType;//7
        UnmutableList<int> UnList_int;
        UnmutableList<char> UnList_char;
        UnmutableList<string> UnList_string;
        UnmutableList<float> UnList_float;
        UnmutableList<double> UnList_double;
        UnmutableList<bool> UnList_bool;
        UnmutableList<MyType> UnList_myType;

        public string path;
        public string nameList;
        public int realization;
        public int type;
        public ListButtons list_buttons = new ListButtons();
        DataHistory data = new DataHistory();
        bool mutable = true;
        ContextMenuStrip ContextMenu = new ContextMenuStrip();
        object copy = null;



        //string+
        //bool+
        //double+
        //char+
        //float+
        //int+
        ListUtils.SetUtils.ConvertDelegate<int, int> convertIntToInt = IntToInt;
        ListUtils.SetUtils.ConvertDelegate<char, char> convertCharToChar = CharToChar;
        ListUtils.SetUtils.ConvertDelegate<float, float> convertFloatToFloat = FloatToFloat;
        ListUtils.SetUtils.ConvertDelegate<double, double> convertDoubleToDouble = DoubleToDouble;
        ListUtils.SetUtils.ConvertDelegate<bool, bool> convertBoolToBool = BoolToBool;
        ListUtils.SetUtils.ConvertDelegate<string, string> convertStringToString = StringToString;
        ListUtils.SetUtils.ConvertDelegate<MyType, MyType> convertMyTypeToMyType = MyTypeToMyType;
        ListUtils.SetUtils.ConvertDelegate<string, int> convertStringToInt = StringToInt;
        ListUtils.SetUtils.ConvertDelegate<string, float> convertStringToFloat = StringToFloat;
        ListUtils.SetUtils.ConvertDelegate<string, char> convertStringToChar = StringToChar;
        ListUtils.SetUtils.ConvertDelegate<string, double> convertStringToDouble = StringToDouble;
        ListUtils.SetUtils.ConvertDelegate<string, bool> convertStringToBool = StringToBool;
        ListUtils.SetUtils.ConvertDelegate<bool, string> convertBoolToString = BoolToString;
        ListUtils.SetUtils.ConvertDelegate<bool, double> convertBoolToDouble = BoolToDouble;
        ListUtils.SetUtils.ConvertDelegate<bool, char> convertBoolToChar = BoolToChar;
        ListUtils.SetUtils.ConvertDelegate<bool, float> convertBoolToFloat = BoolToFloat;
        ListUtils.SetUtils.ConvertDelegate<bool, int> convertBoolToInt = BoolToInt;
        ListUtils.SetUtils.ConvertDelegate<double, int> convertDoubleToInt = DoubleToInt;
        ListUtils.SetUtils.ConvertDelegate<double, float> convertDoubleToFloat = DoubleToFloat;
        ListUtils.SetUtils.ConvertDelegate<double, char> convertDoubleToChar = DoubleToChar;
        ListUtils.SetUtils.ConvertDelegate<double, bool> convertDoubleToBool = DoubleToBool;
        ListUtils.SetUtils.ConvertDelegate<double, string> convertDoubleToString = DoubleToString;
        ListUtils.SetUtils.ConvertDelegate<char, int> convertCharToInt = CharToInt;
        ListUtils.SetUtils.ConvertDelegate<char, float> convertCharToFloat = CharToFloat;
        ListUtils.SetUtils.ConvertDelegate<char, double> convertCharToDouble = CharToDouble;
        ListUtils.SetUtils.ConvertDelegate<char, bool> convertCharToBool = CharToBool;
        ListUtils.SetUtils.ConvertDelegate<char, string> convertCharToString = CharToString;
        ListUtils.SetUtils.ConvertDelegate<float, int> convertFloatToInt = FloatToInt;
        ListUtils.SetUtils.ConvertDelegate<float, char> convertFloatToChar = FloatToChar;
        ListUtils.SetUtils.ConvertDelegate<float, double> convertFloatToDouble = FloatToDouble;
        ListUtils.SetUtils.ConvertDelegate<float, bool> convertFloatToBool = FloatToBool;
        ListUtils.SetUtils.ConvertDelegate<float, string> convertFloatToString = FloatToString;
        ListUtils.SetUtils.ConvertDelegate<int, float> convertIntToFloat = IntToFloat;
        ListUtils.SetUtils.ConvertDelegate<int, char> convertIntToChar = IntToChar;
        ListUtils.SetUtils.ConvertDelegate<int, double> convertIntToDouble = IntToDouble;
        ListUtils.SetUtils.ConvertDelegate<int, bool> convertIntToBool = IntToBool;
        ListUtils.SetUtils.ConvertDelegate<int, string> convertIntToString = IntToString;

        ListUtils.SetUtils.CheckDelegate_<int> CompareToIntLess = Compare_ToInt_less;
        ListUtils.SetUtils.CheckDelegate_<float> CompareToFloatLess = Compare_ToFloat_less;
        ListUtils.SetUtils.CheckDelegate_<char> CompareToCharLess = Compare_ToChar_less;
        ListUtils.SetUtils.CheckDelegate_<double> CompareToDoubleLess = Compare_ToDouble_less;
        ListUtils.SetUtils.CheckDelegate_<bool> CompareToBoolLess = Compare_ToBool_less;
        ListUtils.SetUtils.CheckDelegate_<string> CompareToStringLess = Compare_ToString_less;
        ListUtils.SetUtils.CheckDelegate_<MyType> CompareToMyTypeLess = Compare_ToMyType_less;

        ListUtils.SetUtils.CheckDelegate_<int> CompareToIntMore = Compare_ToInt_more;
        ListUtils.SetUtils.CheckDelegate_<float> CompareToFloatMore = Compare_ToFloat_more;
        ListUtils.SetUtils.CheckDelegate_<char> CompareToCharMore = Compare_ToChar_more;
        ListUtils.SetUtils.CheckDelegate_<double> CompareToDoubleMore = Compare_ToDouble_more;
        ListUtils.SetUtils.CheckDelegate_<bool> CompareToBoolMore = Compare_ToBool_more;
        ListUtils.SetUtils.CheckDelegate_<string> CompareToStringMore = Compare_ToString_more;
        ListUtils.SetUtils.CheckDelegate_<MyType> CompareToMyTypeMore = Compare_ToMyType_more;

        ListUtils.SetUtils.CheckDelegate<int> isOddInt = isOddInt_;
        ListUtils.SetUtils.CheckDelegate<float> isOddFloat = isOddFloat_;
        ListUtils.SetUtils.CheckDelegate<char> isOddChar = isOddChar_;
        ListUtils.SetUtils.CheckDelegate<double> isOddDouble = isOddDouble_;
        ListUtils.SetUtils.CheckDelegate<bool> isOddBool = isOddBool_;
        ListUtils.SetUtils.CheckDelegate<string> isOddString = isOddString_;
        ListUtils.SetUtils.CheckDelegate<MyType> isOddMyType = isOddMyType_;

        ListUtils.SetUtils.CheckDelegate<int> isntOddInt = isntOddInt_;
        ListUtils.SetUtils.CheckDelegate<float> isntOddFloat = isntOddFloat_;
        ListUtils.SetUtils.CheckDelegate<char> isntOddChar = isntOddChar_;
        ListUtils.SetUtils.CheckDelegate<double> isntOddDouble = isntOddDouble_;
        ListUtils.SetUtils.CheckDelegate<bool> isntOddBool = isntOddBool_;
        ListUtils.SetUtils.CheckDelegate<string> isntOddString = isntOddString_;
        ListUtils.SetUtils.CheckDelegate<MyType> isntOddMyType = isntOddMyType_;





        public FormMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            list_int = new LinkedList<int>();
            list_int.Add(2);
            foreach(int element in list_int)
            {

            }

            menuStrip1.Renderer = new NoHigthligthRenderer();
            foreach (ToolStripMenuItem m in menuStrip1.Items)
            {
                SetColor_1(m);
            }
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem_1());

            menuStrip2.Renderer = new NoHigthligthRenderer();
            foreach (ToolStripMenuItem m in menuStrip2.Items)
            {
                SetColor_1(m);
            }
            menuStrip2.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem_2());
            toolStripMenuItem1.DropDownClosed += new EventHandler(toolStripMeuItem1_Closed);
            toolStripMenuItem1.DropDownItemClicked += ToolStripMenuItem1_DropDownItemClicked;
            toolStripMenuItem1.ForeColor = Color.DarkGray;
            menuStrip2.Visible = false;


            ToolStripMenuItem EditMenuItem = new ToolStripMenuItem("Edit");
            EditMenuItem.Click += Edit_click;
            ToolStripMenuItem InsertMenuItem = new ToolStripMenuItem("Insert");
            InsertMenuItem.Click += Insert_click;
            ToolStripMenuItem CopyMenuItem = new ToolStripMenuItem("Copy");
            CopyMenuItem.Click += Copy_click;
            ToolStripMenuItem DeleteMenuItem = new ToolStripMenuItem("Delete");
            DeleteMenuItem.Click += Delete_click;
            ContextMenu.Items.AddRange(new[] { EditMenuItem, InsertMenuItem, CopyMenuItem, DeleteMenuItem });
            foreach (ToolStripMenuItem m in ContextMenu.Items)
            {
                SetColor_1(m);
            }
            ContextMenu.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem_3());
            ContextMenu.Font = new Font("Consolas", 12);
            panel3.ContextMenuStrip = ContextMenu;

            currnet_list.Visible = false;
            label_type.Visible = false;
            Show();
            panel2.Location = new Point(Width - 200, 54);
            panel2.Width = 37;
            menuStrip2.Visible = false;
            FormTypeData form = new FormTypeData();
            form.TopMost = true;
            form.ShowDialog();
            data = form.data;
            if (form.nameList != null)
            {
                currnet_list.Visible = true;
                label_type.Visible = true;
                currnet_list.Text = form.nameList;
                Button button = new Button();
                mutable = form.mutable;
                if (mutable)
                    VisableElementMenuForMutableList();
                else
                    UnVisableElementMenuForMutableList();
                path = form.path;
                nameList = form.nameList;
                realization = form.realization;
                type = form.type;
                ChangeTextLabelType();
                list_buttons.Add(path, nameList, type, realization, mutable);
                button.Text = nameList;
                button.Name = "button";
                button.BackColor = Color.OrangeRed;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                button.FlatAppearance.MouseOverBackColor = Color.Tomato;
                button.Width = 90;
                button.Height = 30;
                button.TabIndex = 3;
                button.Visible = true;
                button.Font = new Font("Consolas", 14);
                button.ForeColor = Color.White;
                button.Location = new Point(0, 0);
                button.Click += new EventHandler(button_click);
                ToolTip toolTip_1 = new ToolTip();
                toolTip_1.AutoPopDelay = 5000;
                toolTip_1.InitialDelay = 200;
                toolTip_1.ReshowDelay = 200;
                toolTip_1.ShowAlways = true;
                toolTip_1.SetToolTip(button, path);
                panel1.Controls.Add(button);
                Load_Data_from_file(path);
            }
            else
                UnVisableElemenMenu();
        }
        private void toolStripMeuItem1_Closed(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.DarkGray;
        }
        internal class NoHigthligthRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.OwnerItem == null)
                    base.OnRenderMenuItemBackground(e);
            }
        }
        private void ChangeTextLabelType()
        {
            switch (type)
            {
                case 1:
                    label_type.Text = "int";
                    break;
                case 2:
                    label_type.Text = "float";
                    break;
                case 3:
                    label_type.Text = "char";
                    break;
                case 4:
                    label_type.Text = "double";
                    break;
                case 5:
                    label_type.Text = "bool";
                    break;
                case 6:
                    label_type.Text = "string";
                    break;
                case 7:
                    label_type.Text = "My type";
                    break;
            }
        }
        public class ChangeStyleItem_1 : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return Color.DarkSlateGray; } }
            public override Color ToolStripBorder { get { return Color.DarkCyan; } }
            public override Color ToolStripDropDownBackground { get { return Color.DarkCyan; } }
            public override Color ImageMarginGradientBegin { get { return Color.DarkCyan; } }
            public override Color ImageMarginGradientEnd { get { return Color.DarkCyan; } }
            public override Color ImageMarginGradientMiddle { get { return Color.DarkCyan; } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemBorder { get { return Color.DarkCyan; } }
        }
        public class ChangeStyleItem_2 : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return Color.Indigo; } }
            public override Color ToolStripBorder { get { return Color.Indigo; } }
            public override Color ToolStripDropDownBackground { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientBegin { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientEnd { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientMiddle { get { return Color.DarkViolet; } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemBorder { get { return Color.DarkViolet; } }
        }
        public class ChangeStyleItem_3 : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return Color.Indigo; } }
            public override Color ToolStripBorder { get { return Color.Indigo; } }
            public override Color ToolStripDropDownBackground { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientBegin { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientEnd { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientMiddle { get { return Color.DarkViolet; } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemBorder { get { return Color.DarkViolet; } }
        }
        private void SetColor_1(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetColor_1(it);
            }
        }


        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTask form = new FormTask();
            form.TopMost = true;
            form.Show();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.OrangeRed, 5);
            Point p1 = new Point(41, 79);
            Point p2 = new Point(Width - 72, 79);
            e.Graphics.DrawLine(pen, p1, p2);
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            panel3.Width = Width - 112;
            currnet_list.Location = new Point(Width - 163, currnet_list.Location.Y);
        }

        private void FormMain_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void createListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTypeData form = new FormTypeData();
            form.TopMost = true;
            form.ShowDialog();
            if (form.nameList != null)
            {
                VisableElementMenu();
                mutable = form.mutable;
                if (mutable)
                    VisableElementMenuForMutableList();
                else
                    UnVisableElementMenuForMutableList();
                path = form.path;
                nameList = form.nameList;
                realization = form.realization;
                type = form.type;
                data = form.data;
                bool isPath = false;
                bool isName = false;
                NodeButton current = list_buttons.head;
                while (current != null && !isName)
                {
                    if (current.node.name == nameList || current.node.name == path)
                    {
                        isName = true;
                        if (current.node.path == path)
                            isPath = true;
                        else
                            nameList = path;
                    }
                    current = current.next;
                }
                label_type.Visible = true;
                ChangeTextLabelType();
                currnet_list.Text = nameList;
                currnet_list.Visible = true;
                if (panel1.Controls.Count < 17)
                {
                    if (!isPath)
                    {
                        foreach (Button element in panel1.Controls)
                        {
                            element.BackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                        }
                        Button button = new Button();
                        list_buttons.Add(path, nameList, type, realization, mutable);
                        button.Text = nameList;
                        button.Name = "button";
                        button.BackColor = Color.OrangeRed;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                        button.FlatAppearance.MouseOverBackColor = Color.Tomato;
                        button.Width = 90;
                        button.Height = 30;
                        button.TabIndex = 3;
                        button.Visible = true;
                        button.Font = new Font("Consolas", 14);
                        button.ForeColor = Color.White;
                        button.Location = new Point((list_buttons.Count - 1) * 100, 0);
                        button.Click += new EventHandler(button_click);
                        ToolTip toolTip_1 = new ToolTip();
                        toolTip_1.AutoPopDelay = 5000;
                        toolTip_1.InitialDelay = 200;
                        toolTip_1.ReshowDelay = 200;
                        toolTip_1.ShowAlways = true;
                        toolTip_1.SetToolTip(button, path);
                        Load_Data_from_file(path);
                        panel1.Controls.Add(button);
                    }
                    else
                        foreach (Button element in panel1.Controls)
                        {
                            if (element.Text == nameList)
                            {
                                element.BackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                            }
                            else
                            {
                                element.BackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                            }
                        }
                }
                else
                {
                    if (!isPath)
                    {
                        toolStripMenuItem1.DropDownItems.Add(nameList);
                        list_buttons.Add(path, Name, type, realization, mutable);
                        foreach (ToolStripMenuItem m in menuStrip2.Items)
                        {
                            SetColor_1(m);
                        }
                        toolStripMenuItem1.ForeColor = Color.DarkGray;
                        menuStrip2.Visible = true;
                    }
                }
                Load_Data_from_file(path);
            }
        }
        private void ToolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem element = e.ClickedItem;
            string name = element.Text;
            if (nameList != name)
            {
                NodeButton current = list_buttons.head;
                while (current != null && current.node.name != name)
                    current = current.next;
                string message = "Сохранить список " + nameList + "?";
                FormDialog_ok_notOk form = new FormDialog_ok_notOk(message);
                form.TopMost = true;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                    saveToolStripMenuItem_Click(sender, e);
                realization = current.node.realization;
                type = current.node.type;
                currnet_list.Text = current.node.name;
                nameList = current.node.name;
                path = current.node.path;
                mutable = current.node.mutable;
                currnet_list.Text = nameList;
                ChangeTextLabelType();
                if (mutable)
                    VisableElementMenuForMutableList();
                else
                    UnVisableElementMenuForMutableList();
                Load_Data_from_file(path);

            }
        }
        private void button_click(object sender, EventArgs e)
        {
            string name = sender.ToString().Remove(0, 35);
            if (nameList != name)
            {
                NodeButton current = list_buttons.head;
                while (current != null && current.node.name != name)
                    current = current.next;
                string message = "Сохранить список " + nameList + "?";
                FormDialog_ok_notOk form = new FormDialog_ok_notOk(message);
                form.TopMost = true;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                    saveToolStripMenuItem_Click(sender, e);
                realization = current.node.realization;
                type = current.node.type;
                currnet_list.Text = current.node.name;
                nameList = current.node.name;
                path = current.node.path;
                mutable = current.node.mutable;
                ChangeTextLabelType();
                if (mutable)
                    VisableElementMenuForMutableList();
                else
                    UnVisableElementMenuForMutableList();
                foreach (Button element in panel1.Controls)
                {
                    if (element.Text == nameList)
                    {
                        element.BackColor = Color.OrangeRed;
                        element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                        element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                    }
                    else
                    {
                        element.BackColor = Color.DarkSlateGray;
                        element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                        element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                    }
                }
                Load_Data_from_file(path);
            }
        }
        private void label_enter(object sender, EventArgs e)
        {
            Label current = (Label)sender;
            current.BackColor = Color.Purple;
        }
        private void label_leave(object sender, EventArgs e)
        {
            Label current = (Label)sender;
            current.BackColor = Color.MediumPurple;
        }
        private void Edit_click(object sender, EventArgs e)
        {
            FormInputElement form = new FormInputElement(type);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Label currnet = (Label)ContextMenu.SourceControl;
                switch (type)
                {
                    case 1:
                        if (mutable)
                            list_int[(int)currnet.Tag] = form.result_int;
                        else
                            UnList_int[(int)currnet.Tag] = form.result_int;
                        break;
                    case 2:
                        if (mutable)
                            list_float[(int)currnet.Tag] = form.result_float;
                        else
                            UnList_float[(int)currnet.Tag] = form.result_float;
                        break;
                    case 3:
                        if (mutable)
                            list_char[(int)currnet.Tag] = form.result_char;
                        else
                            UnList_char[(int)currnet.Tag] = form.result_char;
                        break;
                    case 4:
                        if (mutable)
                            list_double[(int)currnet.Tag] = form.result_double;
                        else
                            UnList_double[(int)currnet.Tag] = form.result_double;
                        break;
                    case 5:
                        if (mutable)
                            list_bool[(int)currnet.Tag] = form.result_bool;
                        else
                            UnList_bool[(int)currnet.Tag] = form.result_bool;
                        break;
                    case 6:
                        if (mutable)
                            list_string[(int)currnet.Tag] = form.result_string;
                        else
                            UnList_string[(int)currnet.Tag] = form.result_string;
                        break;
                    case 7:
                        if (mutable)
                            list_myType[(int)currnet.Tag] = form.result_myType;
                        else
                            UnList_myType[(int)currnet.Tag] = form.result_myType;
                        break;
                }
                panel_load_label();
            }
        }
        private void Insert_click(object sender, EventArgs e)
        {
            if (copy != null)
            {
                int index = 0;
                if (ContextMenu.SourceControl == panel3)
                    switch (type)
                    {
                        case 1:
                            if (mutable)
                                index = list_int.Count;
                            else
                                index = UnList_int.Count;
                            break;
                        case 2:
                            if (mutable)
                                index = list_float.Count;
                            else
                                index = UnList_float.Count;
                            break;
                        case 3:
                            if (mutable)
                                index = list_char.Count;
                            else
                                index = UnList_char.Count;
                            break;
                        case 4:
                            if (mutable)
                                index = list_double.Count;
                            else
                                index = UnList_double.Count;
                            break;
                        case 5:
                            if (mutable)
                                index = list_bool.Count;
                            else
                                index = UnList_bool.Count;
                            break;
                        case 6:
                            if (mutable)
                                index = list_string.Count;
                            else
                                index = UnList_string.Count;
                            break;
                        case 7:
                            if (mutable)
                                index = list_myType.Count;
                            else
                                index = UnList_myType.Count;
                            break;
                    }

                else
                {
                    Label current = (Label)ContextMenu.SourceControl;
                    index = (int)current.Tag;
                }
                switch (type)
                {
                    case 1:
                        if (mutable)
                            list_int.Insert(index, (int)copy);
                        else
                            UnList_int.Insert(index, (int)copy);
                        break;
                    case 2:
                        if (mutable)
                            list_float.Insert(index, (float)copy);
                        else
                            UnList_float.Insert(index, (float)copy);
                        break;
                    case 3:
                        if (mutable)
                            list_char.Insert(index, (char)copy);
                        else
                            UnList_char.Insert(index, (char)copy);
                        break;
                    case 4:
                        if (mutable)
                            list_double.Insert(index, (double)copy);
                        else
                            UnList_double.Insert(index, (double)copy);
                        break;
                    case 5:
                        if (mutable)
                            list_bool.Insert(index, (bool)copy);
                        else
                            UnList_bool.Insert(index, (bool)copy);
                        break;
                    case 6:
                        if (mutable)
                            list_string.Insert(index, (string)copy);
                        else
                            UnList_string.Insert(index, (string)copy);
                        break;
                    case 7:
                        MyType tmp = new MyType();
                        tmp = (MyType)copy;
                        if (mutable)
                            list_myType.Insert(index, tmp);
                        else
                            UnList_myType.Insert(index, tmp);
                        break;
                }
                panel_load_label();
            }
        }
        private void Copy_click(object sender, EventArgs e)
        {
            if (ContextMenu.SourceControl != panel3)
            {
                Label current = (Label)ContextMenu.SourceControl;
                switch (type)
                {
                    case 1:
                        if (mutable)
                            copy = list_int[(int)current.Tag];
                        else
                            copy = UnList_int[(int)current.Tag];
                        break;
                    case 2:
                        if (mutable)
                            copy = list_float[(int)current.Tag];
                        else
                            copy = UnList_float[(int)current.Tag];
                        break;
                    case 3:
                        if (mutable)
                            copy = list_char[(int)current.Tag];
                        else
                            copy = UnList_char[(int)current.Tag];
                        break;
                    case 4:
                        if (mutable)
                            copy = list_double[(int)current.Tag];
                        else
                            copy = UnList_double[(int)current.Tag];
                        break;
                    case 5:
                        if (mutable)
                            copy = list_bool[(int)current.Tag];
                        else
                            copy = UnList_bool[(int)current.Tag];
                        break;
                    case 6:
                        if (mutable)
                            copy = list_string[(int)current.Tag];
                        else
                            copy = UnList_string[(int)current.Tag];
                        break;
                    case 7:
                        if (mutable)
                            copy = list_myType[(int)current.Tag];
                        else
                            copy = UnList_myType[(int)current.Tag];
                        break;
                }
            }
        }
        private void Delete_click(object sender, EventArgs e)
        {
            if (ContextMenu.SourceControl != panel3)
            {
                Label current = (Label)ContextMenu.SourceControl;
                switch (type)
                {
                    case 1:
                        if (mutable)
                            list_int.RemoveAt((int)current.Tag);
                        else
                            UnList_int.RemoveAt((int)current.Tag);
                        break;
                    case 2:
                        if (mutable)
                            list_float.RemoveAt((int)current.Tag);
                        else
                            UnList_float.RemoveAt((int)current.Tag);
                        break;
                    case 3:
                        if (mutable)
                            list_char.RemoveAt((int)current.Tag);
                        else
                            UnList_char.RemoveAt((int)current.Tag);
                        break;
                    case 4:
                        if (mutable)
                            list_double.RemoveAt((int)current.Tag);
                        else
                            list_double.RemoveAt((int)current.Tag);
                        break;
                    case 5:
                        if (mutable)
                            list_bool.RemoveAt((int)current.Tag);
                        else
                            UnList_bool.RemoveAt((int)current.Tag);
                        break;
                    case 6:
                        if (mutable)
                            list_string.RemoveAt((int)current.Tag);
                        else
                            UnList_string.RemoveAt((int)current.Tag);
                        break;
                    case 7:
                        if (mutable)
                            list_myType.RemoveAt((int)current.Tag);
                        else
                            UnList_myType.RemoveAt((int)current.Tag);
                        break;
                }
                panel_load_label();
            }
        }
        private void label_click(object sender, MouseEventArgs e)
        {

        }
        private void panel_load_label()
        {
            panel3.Controls.Clear();
            int count = 0;
            if (mutable)
                switch (type)
                {
                    case 1:
                        count = list_int.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.ForeColor = Color.White;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_int[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите правой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 2:
                        count = list_float.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_float[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 3:
                        count = list_char.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_char[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 4:
                        count = list_double.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_double[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 5:
                        count = list_bool.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_bool[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 6:
                        count = list_string.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_string[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 7:
                        count = list_myType.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 8);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = list_myType[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                }
            else
                switch (type)
                {
                    case 1:
                        count = UnList_int.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.ForeColor = Color.White;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_int[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 2:
                        count = UnList_float.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_float[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 3:
                        count = UnList_char.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_char[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 4:
                        count = UnList_double.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_double[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 5:
                        count = UnList_bool.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_bool[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 6:
                        count = UnList_string.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 14);
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_string[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                    case 7:
                        count = UnList_myType.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Label lbl = new Label();
                            lbl.MouseEnter += new EventHandler(label_enter);
                            lbl.MouseLeave += new EventHandler(label_leave);
                            lbl.Font = new Font("Consolas", 8);
                            // lbl.ContextMenuStrip = ContextMenuStrip1;
                            lbl.FlatStyle = FlatStyle.Flat;
                            lbl.BackColor = Color.MediumPurple;
                            lbl.Height = 45;
                            lbl.Width = 150;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Location = new Point(25 + 200 * (i % 9), 30 + 80 * (i / 9));
                            lbl.Text = UnList_myType[i].ToString();
                            lbl.Tag = i;
                            lbl.ContextMenuStrip = ContextMenu;
                            lbl.MouseClick += new MouseEventHandler(label_click);
                            ToolTip tip = new ToolTip();
                            tip.AutoPopDelay = 5000;
                            tip.InitialDelay = 200;
                            tip.ReshowDelay = 200;
                            tip.ShowAlways = true;
                            tip.SetToolTip(lbl, "Нажмите левой кнопкой мыши");
                            panel3.Controls.Add(lbl);
                        }
                        break;
                }


            for (int i = 0; i < count / 9; i++)
            {
                Label lbl = new Label();
                lbl.FlatStyle = FlatStyle.Flat;
                lbl.BackColor = Color.LavenderBlush;
                lbl.Height = 2;
                lbl.Width = 1750;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                panel3.Controls.Add(lbl);
                lbl.Location = new Point(25, 90 + 80 * i);
            }
        }
        private void Load_Data_from_file(string path)
        {
            StreamReader file = new StreamReader(File.OpenRead(path));
            file.ReadLine();
            file.ReadLine();
            file.ReadLine();

            switch (realization)
            {
                case 1:
                    switch (type)
                    {
                        case 1:
                            list_int = new LinkedList<int>();
                            while (file.Peek() != -1)
                            {
                                int p = Convert.ToInt32(file.ReadLine());
                                list_int.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_int = new UnmutableList<int>(list_int);
                                list_int.Clear();
                            }
                            break;
                        case 2:
                            list_float = new LinkedList<float>();
                            while (file.Peek() != -1)
                            {
                                float p = float.Parse(file.ReadLine());
                                list_float.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_float = new UnmutableList<float>(list_float);
                                list_float.Clear();
                            }
                            break;
                        case 3:
                            list_char = new LinkedList<char>();
                            while (file.Peek() != -1)
                            {
                                char p = char.Parse(file.ReadLine());
                                list_char.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_char = new UnmutableList<char>(list_char);
                                list_char.Clear();
                            }
                            break;
                        case 4:
                            list_double = new LinkedList<double>();
                            while (file.Peek() != -1)
                            {
                                double p = Convert.ToDouble(file.ReadLine());
                                list_double.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_double = new UnmutableList<double>(list_double);
                                list_double.Clear();
                            }
                            break;
                        case 5:
                            list_bool = new LinkedList<bool>();
                            while (file.Peek() != -1)
                            {
                                bool p = Convert.ToBoolean(file.ReadLine());
                                list_bool.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_bool = new UnmutableList<bool>(list_bool);
                                list_bool.Clear();
                            }
                            break;
                        case 6:
                            list_string = new LinkedList<string>();
                            while (file.Peek() != -1)
                            {
                                string p = file.ReadLine();
                                list_string.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_string = new UnmutableList<string>(list_string);
                                list_string.Clear();
                            }
                            break;
                        case 7:
                            list_myType = new LinkedList<MyType>();
                            MyType currnet = new MyType();
                            string ReadText;
                            while (file.Peek() != -1)
                            {
                                ReadText = file.ReadLine().Replace("Дата: ", "");
                                currnet.date = DateTime.Parse(ReadText);
                                ReadText = file.ReadLine().Replace("Наименование: ", "");
                                currnet.name = ReadText;
                                list_myType.Add(currnet);
                                file.ReadLine();
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_myType = new UnmutableList<MyType>(list_myType);
                                list_myType.Clear();
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (type)
                    {
                        case 1:
                            list_int = new ArrayList<int>();
                            while (file.Peek() != -1)
                            {
                                int p = Convert.ToInt32(file.ReadLine());
                                list_int.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_int = new UnmutableList<int>(list_int);
                                list_int.Clear();
                            }
                            break;
                        case 2:
                            list_float = new ArrayList<float>();
                            while (file.Peek() != -1)
                            {
                                float p = float.Parse(file.ReadLine());
                                list_float.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_float = new UnmutableList<float>(list_float);
                                list_float.Clear();
                            }
                            break;
                        case 3:
                            list_char = new ArrayList<char>();
                            while (file.Peek() != -1)
                            {
                                char p = char.Parse(file.ReadLine());
                                list_char.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_char = new UnmutableList<char>(list_char);
                                list_char.Clear();
                            }
                            break;
                        case 4:
                            list_double = new ArrayList<double>();
                            while (file.Peek() != -1)
                            {
                                double p = Convert.ToDouble(file.ReadLine());
                                list_double.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_double = new UnmutableList<double>(list_double);
                                list_double.Clear();
                            }
                            break;
                        case 5:
                            list_bool = new ArrayList<bool>();
                            while (file.Peek() != -1)
                            {
                                bool p = Convert.ToBoolean(file.ReadLine());
                                list_bool.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_bool = new UnmutableList<bool>(list_bool);
                                list_bool.Clear();
                            }
                            break;
                        case 6:
                            list_string = new ArrayList<string>();
                            while (file.Peek() != -1)
                            {
                                string p = file.ReadLine();
                                list_string.Add(p);
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_string = new UnmutableList<string>(list_string);
                                list_string.Clear();
                            }
                            break;
                        case 7:
                            list_myType = new ArrayList<MyType>();
                            MyType currnet = new MyType();
                            string ReadText;
                            while (file.Peek() != -1)
                            {
                                ReadText = file.ReadLine().Replace("Дата: ", "");
                                currnet.date = DateTime.Parse(ReadText);
                                ReadText = file.ReadLine().Replace("Наименование: ", "");
                                currnet.name = ReadText;
                                list_myType.Add(currnet);
                                file.ReadLine();
                            }
                            panel_load_label();
                            if (!mutable)
                            {
                                UnList_myType = new UnmutableList<MyType>(list_myType);
                                list_myType.Clear();
                            }
                            break;
                    }
                    break;
            }
            file.Close();
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void menuStrip2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.DarkViolet;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ///
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case 1:
                    if (mutable)
                        list_int.Save(path, type, realization, mutable);
                    else
                        UnList_int.Save(path, type, realization, mutable);
                    break;
                case 2:
                    if (mutable)
                        list_float.Save(path, type, realization, mutable);
                    else
                        UnList_float.Save(path, type, realization, mutable);
                    break;
                case 3:
                    if (mutable)
                        list_char.Save(path, type, realization, mutable);
                    else
                        UnList_char.Save(path, type, realization, mutable);
                    break;
                case 4:
                    if (mutable)
                        list_double.Save(path, type, realization, mutable);
                    else
                        UnList_double.Save(path, type, realization, mutable);
                    break;
                case 5:
                    if (mutable)
                        list_bool.Save(path, type, realization, mutable);
                    else
                        UnList_bool.Save(path, type, realization, mutable);
                    break;
                case 6:
                    if (mutable)
                        list_string.Save(path, type, realization, mutable);
                    else
                        UnList_string.Save(path, type, realization, mutable);
                    break;
                case 7:
                    if (mutable)
                        list_myType.Save(path, type, realization, mutable);
                    else
                        UnList_myType.Save(path, type, realization, mutable);
                    break;
            }
            DataNode n = new DataNode();
            n.path = path;
            n.name = nameList;
            n.date = Convert.ToString(DateTime.Now);
            data.Add(n);
        }

        ///
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                NodeButton current = list_buttons.head;
                while (current != null && current.node.path != path)
                    current = current.next;
                File.Delete(path);
                foreach (Button button in panel1.Controls)
                {
                    if (button.Text == nameList)
                        button.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
                }
                path = dialog.FileName;
                current.node.path = path;
                DataNode n = new DataNode();
                n.path = path;
                nameList = Path.GetFileNameWithoutExtension(dialog.FileName);
                n.name = nameList;
                currnet_list.Text = nameList;
                n.date = Convert.ToString(DateTime.Now);
                data.Add(n);
                saveToolStripMenuItem_Click(sender, e);
            }
        }
        private void UnVisableElemenMenu()
        {
            saveToolStripMenuItem.Visible = false;
            saveAsToolStripMenuItem.Visible = false;
            closeAllToolStripMenuItem.Visible = false;
            closeListToolStripMenuItem.Visible = false;
            cleanListToolStripMenuItem.Visible = false;
            addElementToolStripMenuItem.Visible = false;
            existsElementToolStripMenuItem.Visible = false;
            converrtRealizationToolStripMenuItem.Visible = false;
            convertTypeToolStripMenuItem.Visible = false;
            changeMutableToolStripMenuItem.Visible = false;
            existsElementConditionToolStripMenuItem.Visible = false;
        }
        private void VisableElementMenu()
        {
            saveToolStripMenuItem.Visible = true;
            saveAsToolStripMenuItem.Visible = true;
            closeAllToolStripMenuItem.Visible = true;
            closeListToolStripMenuItem.Visible = true;
            cleanListToolStripMenuItem.Visible = true;
            addElementToolStripMenuItem.Visible = true;
            existsElementToolStripMenuItem.Visible = true;
            converrtRealizationToolStripMenuItem.Visible = true;
            convertTypeToolStripMenuItem.Visible = true;
            changeMutableToolStripMenuItem.Visible = true;
            existsElementConditionToolStripMenuItem.Visible = true;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                VisableElementMenu();
                path = dialog.FileName;
                nameList = Path.GetFileNameWithoutExtension(dialog.FileName);
                bool isName = false;
                bool isPath = false;
                NodeButton current = list_buttons.head;
                while (current != null && !isName)
                {
                    if (current.node.name == nameList || current.node.name == path)
                    {
                        isName = true;
                        if (current.node.path == path)
                            isPath = true;
                        else
                            nameList = path;
                    }
                    current = current.next;
                }
                if (panel1.Controls.Count < 17)
                {
                    if (!isPath)
                    {
                        StreamReader file = new StreamReader(File.OpenRead(path));
                        string s = file.ReadLine();
                        if (s == "+")
                        {
                            mutable = true;
                            VisableElementMenuForMutableList();
                        }
                        else
                        {
                            mutable = false;
                            UnVisableElementMenuForMutableList();
                        }
                        type = Convert.ToInt32(file.ReadLine());
                        realization = Convert.ToInt32(file.ReadLine());
                        file.Close();
                        DataNode n = new DataNode();
                        n.date = Convert.ToString(DateTime.Now);
                        n.name = nameList;
                        n.path = path;
                        data.Add(n);
                        list_buttons.Add(path, nameList, type, realization, mutable);
                        Button button = new Button();
                        button.Text = nameList;
                        button.Name = "button";
                        button.BackColor = Color.OrangeRed;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                        button.FlatAppearance.MouseOverBackColor = Color.Tomato;
                        button.Width = 90;
                        button.Height = 30;
                        button.TabIndex = 3;
                        button.Visible = true;
                        button.Font = new Font("Consolas", 14);
                        button.ForeColor = Color.White;
                        button.Location = new Point((list_buttons.Count - 1) * 100, 0);
                        button.Click += new EventHandler(button_click);
                        ToolTip toolTip_1 = new ToolTip();
                        toolTip_1.AutoPopDelay = 5000;
                        toolTip_1.InitialDelay = 200;
                        toolTip_1.ReshowDelay = 200;
                        toolTip_1.ShowAlways = true;
                        toolTip_1.SetToolTip(button, path);
                        foreach (Button element in panel1.Controls)
                        {
                            if (element.Text == nameList)
                            {
                                element.BackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                            }
                            else
                            {
                                element.BackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                            }
                        }
                        panel1.Controls.Add(button);
                        currnet_list.Text = nameList;
                        ChangeTextLabelType();
                        Load_Data_from_file(path);
                    }
                    else
                    {
                        menuStrip2.Visible = true;
                        type = current.node.type;
                        realization = current.node.realization;
                        nameList = current.node.name;
                        path = current.node.path;
                        currnet_list.Text = nameList;
                        ChangeTextLabelType();
                        foreach (Button element in panel1.Controls)
                        {
                            if (element.Text == nameList)
                            {
                                element.BackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                                element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                            }
                            else
                            {
                                element.BackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                                element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                            }
                        }
                    }
                }
                else
                {
                    if (!isPath)
                    {
                        toolStripMenuItem1.DropDownItems.Add(nameList);
                        list_buttons.Add(path, Name, type, realization, mutable);
                        foreach (ToolStripMenuItem m in menuStrip2.Items)
                        {
                            SetColor_1(m);
                        }
                        toolStripMenuItem1.ForeColor = Color.DarkGray;
                        menuStrip2.Visible = true;
                    }
                }
            }
        }

        private void VisableElementMenuForMutableList()
        {
            cleanListToolStripMenuItem.Visible = true;
            addElementToolStripMenuItem.Visible = true;
            convertTypeToolStripMenuItem.Visible = true;
            converrtRealizationToolStripMenuItem.Visible = true;
            changeMutableToolStripMenuItem.Visible = true;
        }

        private void UnVisableElementMenuForMutableList()
        {
            cleanListToolStripMenuItem.Visible = false;
            converrtRealizationToolStripMenuItem.Visible = false;
            convertTypeToolStripMenuItem.Visible = false;
            changeMutableToolStripMenuItem.Visible = false;
            addElementToolStripMenuItem.Visible = false;
        }

        private void closeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Сохранить список " + nameList + "?";
            FormDialog_ok_notOk form = new FormDialog_ok_notOk(message);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                saveToolStripMenuItem_Click(sender, e);
            list_buttons.Delete(path);
            copy = null;
            if (list_buttons.Count == 0)
            {
                UnVisableElemenMenu();
                panel1.Controls.Clear();
                currnet_list.Visible = false;
                label_type.Visible = false;
                panel3.Controls.Clear();
            }
            else
            {
                NodeButton current = list_buttons.head;
                nameList = current.node.name;
                path = current.node.path;
                type = current.node.type;
                realization = current.node.realization;
                mutable = current.node.mutable;
                if (!mutable)
                    UnVisableElementMenuForMutableList();
                if (list_buttons.Count < 17)//////
                {
                    panel1.Controls.Clear();
                    Button button_1 = new Button();
                    menuStrip2.Visible = false;
                    button_1.Text = nameList;
                    button_1.Name = "button";
                    button_1.BackColor = Color.OrangeRed;
                    button_1.FlatStyle = FlatStyle.Flat;
                    button_1.FlatAppearance.BorderSize = 0;
                    button_1.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                    button_1.FlatAppearance.MouseOverBackColor = Color.Tomato;
                    button_1.Width = 90;
                    button_1.Height = 30;
                    button_1.TabIndex = 3;
                    button_1.Visible = true;
                    button_1.Font = new Font("Consolas", 14);
                    button_1.ForeColor = Color.White;
                    button_1.Location = new Point(0, 0);
                    button_1.Click += new EventHandler(button_click);
                    ToolTip toolTip_1 = new ToolTip();
                    toolTip_1.AutoPopDelay = 5000;
                    toolTip_1.InitialDelay = 200;
                    toolTip_1.ReshowDelay = 200;
                    toolTip_1.ShowAlways = true;
                    toolTip_1.SetToolTip(button_1, path);
                    panel1.Controls.Add(button_1);
                    Load_Data_from_file(path);
                    current = current.next;
                    while (current != null)
                    {
                        Button button = new Button();
                        button.Text = current.node.name;
                        button.Name = "button";
                        button.BackColor = Color.DarkSlateGray;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                        button.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                        button.Width = 90;
                        button.Height = 30;
                        button.TabIndex = 3;
                        button.Visible = true;
                        button.Font = new Font("Consolas", 14);
                        button.ForeColor = Color.White;
                        button.Location = new Point((list_buttons.Count - 1) * 100, 0);
                        button.Click += new EventHandler(button_click);
                        ToolTip toolTip = new ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 200;
                        toolTip.ReshowDelay = 200;
                        toolTip.ShowAlways = true;
                        toolTip.SetToolTip(button, current.node.path);
                        panel1.Controls.Add(button);
                        current = current.next;
                    }
                }
                else
                {
                    int count = 0;
                    foreach (ToolStripMenuItem element in toolStripMenuItem1.DropDownItems)
                    {
                        if (element.Text == currnet_list.Text)
                        {
                            toolStripMenuItem1.DropDownItems.RemoveAt(count);
                            break;
                        }
                        count++;
                    }
                    foreach (Button element in panel1.Controls)
                    {
                        if (element.Text == nameList)
                        {
                            element.BackColor = Color.OrangeRed;
                            element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                            element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                        }
                        else
                        {
                            element.BackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                        }
                    }
                }
                currnet_list.Text = nameList;
                ChangeTextLabelType();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnVisableElemenMenu();
            currnet_list.Visible = false;
            label_type.Visible = false;
            menuStrip2.Visible = false;
            string message = "Сохранить список " + nameList + "?";
            FormDialog_ok_notOk form = new FormDialog_ok_notOk(message);
            form.ShowDialog();
            NodeButton current = list_buttons.head;
            copy = null;
            while (current != null)
            {
                path = current.node.path;
                nameList = current.node.name;
                type = current.node.type;
                realization = current.node.realization;
                mutable = current.node.mutable;
                if (form.DialogResult == DialogResult.OK)
                    saveToolStripMenuItem_Click(sender, e);
                current = current.next;
            }
            if (list_buttons.Count >= 17)
            {
                foreach (ToolStripMenuItem element in toolStripMenuItem1.DropDownItems)
                {
                    toolStripMenuItem1.DropDownItems.Remove(element);
                }
            }
            list_buttons.Clear();
            panel1.Controls.Clear();
            panel3.Controls.Clear();
        }

        private void cleanListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Сохранить список " + nameList + "?";
            FormDialog_ok_notOk form = new FormDialog_ok_notOk(message);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                saveToolStripMenuItem_Click(sender, e);
            copy = null;
            switch (type)
            {
                case 1:
                    if (mutable)
                        list_int.Clear();
                    else
                        UnList_int.Clear();
                    break;
                case 2:
                    if (mutable)
                        list_float.Clear();
                    else
                        UnList_float.Clear();
                    break;
                case 3:
                    if (mutable)
                        list_char.Clear();
                    else
                        UnList_char.Clear();
                    break;
                case 4:
                    if (mutable)
                        list_double.Clear();
                    else
                        UnList_double.Clear();
                    break;
                case 5:
                    if (mutable)
                        list_bool.Clear();
                    else
                        UnList_bool.Clear();
                    break;
                case 6:
                    if (mutable)
                        list_string.Clear();
                    else
                        UnList_string.Clear();
                    break;
                case 7:
                    if (mutable)
                        list_myType.Clear();
                    else
                        UnList_myType.Clear();
                    break;
            }
        }

        private void addElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputElement form = new FormInputElement(type);
            form.TopMost = true;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                switch (type)
                {
                    case 1:
                        if (mutable)
                            list_int.Add(form.result_int);
                        else
                            UnList_int.Add(form.result_int);
                        break;
                    case 2:
                        if (mutable)
                            list_float.Add(form.result_float);
                        else
                            UnList_float.Add(form.result_float);
                        break;
                    case 3:
                        if (mutable)
                            list_char.Add(form.result_char);
                        else
                            UnList_char.Add(form.result_char);
                        break;
                    case 4:
                        if (mutable)
                            list_double.Add(form.result_double);
                        else
                            UnList_double.Add(form.result_double);
                        break;
                    case 5:
                        if (mutable)
                            list_bool.Add(form.result_bool);
                        else
                            UnList_bool.Add(form.result_bool);
                        break;
                    case 6:
                        if (mutable)
                            list_string.Add(form.result_string);
                        else
                            UnList_string.Add(form.result_string);
                        break;
                    case 7:
                        if (mutable)
                            list_myType.Add(form.result_myType);
                        else
                            UnList_myType.Add(form.result_myType);
                        break;
                }
                MessageBox.Show("Элемент успешно добавлен", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel_load_label();
            }

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputElement form = new FormInputElement(type);
            form.TopMost = true;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                int pos = -1;
                switch (type)
                {
                    case 1:
                        if (mutable)
                            pos = list_int.IndexOf(form.result_int);
                        else
                            pos = UnList_int.IndexOf(form.result_int);
                        break;
                    case 2:
                        if (mutable)
                            pos = list_float.IndexOf(form.result_float);
                        else
                            pos = UnList_float.IndexOf(form.result_float);
                        break;
                    case 3:
                        if (mutable)
                            pos = list_char.IndexOf(form.result_char);
                        else
                            pos = UnList_char.IndexOf(form.result_char);
                        break;
                    case 4:
                        if (mutable)
                            pos = list_double.IndexOf(form.result_double);
                        else
                            pos = UnList_double.IndexOf(form.result_double);
                        break;
                    case 5:
                        if (mutable)
                            pos = list_bool.IndexOf(form.result_bool);
                        else
                            pos = UnList_bool.IndexOf(form.result_bool);
                        break;
                    case 6:
                        if (mutable)
                            pos = list_string.IndexOf(form.result_string);
                        else
                            pos = UnList_string.IndexOf(form.result_string);
                        break;
                    case 7:
                        if (mutable)
                            pos = list_myType.IndexOf(form.result_myType);
                        else
                            pos = UnList_myType.IndexOf(form.result_myType);
                        break;
                }
                if (pos != -1)
                {
                    switch (type)
                    {
                        case 1:
                            if (mutable)
                                list_int.Remove(form.result_int);
                            else
                                UnList_int.Remove(form.result_int);
                            break;
                        case 2:
                            if (mutable)
                                list_float.Remove(form.result_float);
                            else
                                UnList_float.Remove(form.result_float);
                            break;
                        case 3:
                            if (mutable)
                                list_char.Remove(form.result_char);
                            else
                                UnList_char.Remove(form.result_char);
                            break;
                        case 4:
                            if (mutable)
                                list_double.Remove(form.result_double);
                            else
                                UnList_double.Remove(form.result_double);
                            break;
                        case 5:
                            if (mutable)
                                list_bool.Remove(form.result_bool);
                            else
                                UnList_bool.Remove(form.result_bool);
                            break;
                        case 6:
                            if (mutable)
                                list_string.Remove(form.result_string);
                            else
                                UnList_string.Remove(form.result_string);
                            break;
                        case 7:
                            if (mutable)
                                list_myType.Remove(form.result_myType);
                            else
                                UnList_myType.Remove(form.result_myType);
                            break;
                    }
                    MessageBox.Show("Элемент успешно удален", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel_load_label();
                }
                else
                    MessageBox.Show("Такого элемента не существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void existsElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputElement form = new FormInputElement(type);
            form.TopMost = true;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                int pos = -1;
                switch (type)
                {
                    case 1:
                        if (mutable)
                            pos = list_int.IndexOf(form.result_int);
                        else
                            pos = UnList_int.IndexOf(form.result_int);
                        break;
                    case 2:
                        if (mutable)
                            pos = list_float.IndexOf(form.result_float);
                        else
                            pos = UnList_float.IndexOf(form.result_float);
                        break;
                    case 3:
                        if (mutable)
                            pos = list_char.IndexOf(form.result_char);
                        else
                            pos = UnList_char.IndexOf(form.result_char);
                        break;
                    case 4:
                        if (mutable)
                            pos = list_double.IndexOf(form.result_double);
                        else
                            pos = UnList_double.IndexOf(form.result_double);
                        break;
                    case 5:
                        if (mutable)
                            pos = list_bool.IndexOf(form.result_bool);
                        else
                            pos = UnList_bool.IndexOf(form.result_bool);
                        break;
                    case 6:
                        if (mutable)
                            pos = list_string.IndexOf(form.result_string);
                        else
                            pos = UnList_string.IndexOf(form.result_string);
                        break;
                    case 7:
                        if (mutable)
                            pos = list_myType.IndexOf(form.result_myType);
                        else
                            pos = UnList_myType.IndexOf(form.result_myType);
                        break;
                }
                if (pos != -1)
                    MessageBox.Show("Элемент найден", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Элемент не найден", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private static int IntToInt(int a)
        {
            return a;
        }
        private static float FloatToFloat(float a)
        {
            return a;
        }
        private static char CharToChar(char a)
        {
            return a;
        }
        private static double DoubleToDouble(double a)
        {
            return a;
        }
        private static bool BoolToBool(bool a)
        {
            return a;
        }
        private static string StringToString(string a)
        {
            return a;
        }
        private static MyType MyTypeToMyType(MyType a)
        {
            return a;
        }
        private void converrtRealizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mutable)
                MessageBox.Show("Невозможно изменить данный список", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormConvertElement form = new FormConvertElement();
                form.ShowDialog();
                if (form.choice != -1)
                {
                    //2- array, 1-list
                    realization = form.choice;
                    NodeButton current = list_buttons.head;
                    while (current.node.path != path)
                        current = current.next;
                    current.node.realization = form.choice;
                    switch (form.choice)
                    {
                        case 1:
                            switch (type)
                            {
                                case 1:
                                    list_int = ListUtils.SetUtils.ConvertAll<int, int>(list_int, convertIntToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                    list_int.Save(path, type, realization, mutable);
                                    break;
                                case 2:
                                    list_float = ListUtils.SetUtils.ConvertAll<float, float>(list_float, convertFloatToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                    list_float.Save(path, type, realization, mutable);
                                    break;
                                case 3:
                                    list_char = ListUtils.SetUtils.ConvertAll<char, char>(list_char, convertCharToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                    list_char.Save(path, type, realization, mutable);
                                    break;
                                case 4:
                                    list_double = ListUtils.SetUtils.ConvertAll<double, double>(list_double, convertDoubleToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                    list_double.Save(path, type, realization, mutable);
                                    break;
                                case 5:
                                    list_bool = ListUtils.SetUtils.ConvertAll<bool, bool>(list_bool, convertBoolToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                    list_bool.Save(path, type, realization, mutable);
                                    break;
                                case 6:
                                    list_string = ListUtils.SetUtils.ConvertAll<string, string>(list_string, convertStringToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                    list_string.Save(path, type, realization, mutable);
                                    break;
                                case 7:
                                    list_myType = ListUtils.SetUtils.ConvertAll<MyType, MyType>(list_myType, convertMyTypeToMyType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                    list_myType.Save(path, type, realization, mutable);
                                    break;
                            }
                            break;
                        case 2:
                            switch (type)
                            {
                                case 1:
                                    list_int = ListUtils.SetUtils.ConvertAll<int, int>(list_int, convertIntToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                    list_int.Save(path, type, realization, mutable);
                                    break;
                                case 2:
                                    list_float = ListUtils.SetUtils.ConvertAll<float, float>(list_float, convertFloatToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                    list_float.Save(path, type, realization, mutable);
                                    break;
                                case 3:
                                    list_char = ListUtils.SetUtils.ConvertAll<char, char>(list_char, convertCharToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                    list_char.Save(path, type, realization, mutable);
                                    break;
                                case 4:
                                    list_double = ListUtils.SetUtils.ConvertAll<double, double>(list_double, convertDoubleToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                    list_double.Save(path, type, realization, mutable);
                                    break;
                                case 5:
                                    list_bool = ListUtils.SetUtils.ConvertAll<bool, bool>(list_bool, convertBoolToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                    list_bool.Save(path, type, realization, mutable);
                                    break;
                                case 6:
                                    list_string = ListUtils.SetUtils.ConvertAll<string, string>(list_string, convertStringToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                    list_string.Save(path, type, realization, mutable);
                                    break;
                                case 7:
                                    list_myType = ListUtils.SetUtils.ConvertAll<MyType, MyType>(list_myType, convertMyTypeToMyType, ListUtils.SetUtils.ArrayListConstructor<MyType>);
                                    list_myType.Save(path, type, realization, mutable);
                                    break;
                            }
                            break;
                    }
                }
                panel_load_label();
            }
        }

        private void changeMutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mutable)
            {
                switch (type)
                {
                    case 1:
                        UnList_int = new UnmutableList<int>(list_int);
                        UnList_int.Save(path, type, realization, mutable);
                        list_int.Clear();
                        break;
                    case 2:
                        UnList_float = new UnmutableList<float>(list_float);
                        UnList_float.Save(path, type, realization, mutable);
                        list_float.Clear();
                        break;
                    case 3:
                        UnList_char = new UnmutableList<char>(list_char);
                        UnList_char.Save(path, type, realization, mutable);
                        list_char.Clear();
                        break;
                    case 4:
                        UnList_double = new UnmutableList<double>(list_double);
                        UnList_double.Save(path, type, realization, mutable);
                        list_double.Clear();
                        break;
                    case 5:
                        UnList_bool = new UnmutableList<bool>(list_bool);
                        UnList_bool.Save(path, type, realization, mutable);
                        list_bool.Clear();
                        break;
                    case 6:
                        UnList_string = new UnmutableList<string>(list_string);
                        UnList_string.Save(path, type, realization, mutable);
                        list_string.Clear();
                        break;
                    case 7:
                        UnList_myType = new UnmutableList<MyType>(list_myType);
                        UnList_myType.Save(path, type, realization, mutable);
                        list_myType.Clear();
                        break;
                }
                mutable = false;
                UnVisableElementMenuForMutableList();
            }
            else
            {
                switch (type)
                {
                    case 1:
                        switch (realization)
                        {
                            case 1:
                                list_int = new LinkedList<int>();
                                break;
                            case 2:
                                list_int = new ArrayList<int>();
                                break;
                        }
                        foreach (int element in UnList_int)
                            list_int.Add(element);
                        UnList_int = null;
                        list_int.Save(path, type, realization, mutable);
                        break;
                    case 2:
                        switch (realization)
                        {
                            case 1:
                                list_float = new LinkedList<float>();
                                break;
                            case 2:
                                list_float = new ArrayList<float>();
                                break;
                        }

                        foreach (float element in UnList_float)
                            list_float.Add(element);
                        UnList_float = null;
                        list_float.Save(path, type, realization, mutable);
                        break;
                    case 3:
                        switch (realization)
                        {
                            case 1:
                                list_char = new LinkedList<char>();
                                break;
                            case 2:
                                list_char = new ArrayList<char>();
                                break;
                        }
                        foreach (char element in UnList_char)
                            list_char.Add(element);
                        UnList_char = null;
                        list_char.Save(path, type, realization, mutable);
                        break;
                    case 4:
                        switch (realization)
                        {
                            case 1:
                                list_double = new LinkedList<double>();
                                break;
                            case 2:
                                list_double = new ArrayList<double>();
                                break;
                        }
                        foreach (double element in UnList_double)
                            list_double.Add(element);
                        UnList_double = null;
                        list_double.Save(path, type, realization, mutable);
                        break;
                    case 5:
                        switch (realization)
                        {
                            case 1:
                                list_bool = new LinkedList<bool>();
                                break;
                            case 2:
                                list_bool = new ArrayList<bool>();
                                break;
                        }
                        foreach (bool element in UnList_bool)
                            list_bool.Add(element);
                        UnList_bool = null;
                        list_bool.Save(path, type, realization, mutable);
                        break;
                    case 6:
                        switch (realization)
                        {
                            case 1:
                                list_string = new LinkedList<string>();
                                break;
                            case 2:
                                list_string = new ArrayList<string>();
                                break;
                        }
                        foreach (string element in UnList_string)
                            list_string.Add(element);
                        UnList_string = null;
                        list_string.Save(path, type, realization, mutable);
                        break;
                    case 7:
                        switch (realization)
                        {
                            case 1:
                                list_myType = new LinkedList<MyType>();
                                break;
                            case 2:
                                list_myType = new ArrayList<MyType>();
                                break;
                        }
                        foreach (MyType element in UnList_myType)
                            list_myType.Add(element);
                        UnList_myType = null;
                        list_myType.Save(path, type, realization, mutable);
                        break;
                }
                mutable = true;
                VisableElementMenuForMutableList();
            }
        }

        private static int StringToInt(string other)
        {
            foreach (char sim in other)
            {
                if ((sim < '0') || (sim > '9'))
                    return -1;
            }
            return Convert.ToInt32(other);
        }

        private static float StringToFloat(string other)
        {
            if (other[0] == ',')
                return -1;
            else
            {
                int count = 0;
                int pos = 0;
                while (pos < other.Length && count < 2)
                {
                    if (other[pos] == ',')
                        count++;
                    else
                    {
                        if ((other[pos] >= '0') && (other[pos] <= '9'))
                            pos++;
                        else

                            return -1;
                    }
                }
                if (count == 2)
                    return -1;
                return float.Parse(other);
            }
        }

        private static char StringToChar(string other)
        {
            if (other.Length > 1)
            {
                return '-';
            }
            else
                return other[0];
        }

        private static double StringToDouble(string other)
        {
            if (other[0] == ',')
                return -1;
            else
            {
                int count = 0;
                int pos = 0;
                while (pos < other.Length && count < 2)
                {
                    if (other[pos] == ',')
                        count++;
                    else
                    {
                        if ((other[pos] >= '0') && (other[pos] <= '9'))
                            pos++;
                        else
                            return -1;
                    }
                }
                if (count == 2)
                    return -1;
                return Convert.ToDouble(other);
            }
        }

        private static bool StringToBool(string other)
        {
            string text = other.ToLowerInvariant();
            if (text == "true")
                return true;
            else
                return false;
        }

        private static string BoolToString(bool other)
        {
            if (other)
                return "true";
            else
                return "false";
        }

        private static double BoolToDouble(bool other)
        {
            if (other)
                return 1;
            else
                return 0;
        }

        private static char BoolToChar(bool other)
        {
            if (other)
                return 't';
            else
                return 'f';
        }

        private static float BoolToFloat(bool other)
        {
            if (other)
                return 1;
            else
                return 0;
        }

        private static int BoolToInt(bool other)
        {
            if (other)
                return 1;
            else
                return 0;
        }
        private static int DoubleToInt(double other)
        {
            return Convert.ToInt32(other);
        }
        private static float DoubleToFloat(double other)
        {
            return (float)other;
        }
        private static char DoubleToChar(double other)
        {
            return (char)((int)other - '0');
        }
        private static bool DoubleToBool(double other)
        {
            if (other == 0)
                return false;
            else
                return true;
        }
        private static string DoubleToString(double other)
        {
            return other.ToString();
        }
        private static int CharToInt(char c)
        {
            if ((c >= '0') && (c <= '9'))
                    return Convert.ToInt32(c);
            return -1;
        }
        private static float CharToFloat(char c)
        {
            if ((c >= '0') && (c <= '9'))
                return (float)c;
            return -1;
        }
        private static double CharToDouble(char c)
        {
            if ((c >= '0') && (c <= '9'))
                return Convert.ToDouble(c);
            return -1;
        }
        private static bool CharToBool(char c)
        {
            if (c == 't' || c == 'T')
                return true;
            else
               return false;
        }
        private static string CharToString(char c)
        {
            return c.ToString();
        }
        private static int FloatToInt(float other)
        {
            return Convert.ToInt32(other);
        }
        private static double FloatToDouble(float other)
        {
            return (float)other;
        }
        private static char FloatToChar(float other)
        {
            return (char)((int)other - '0');
        }
        private static bool FloatToBool(float other)
        {
            if (other == 0)
                return false;
            else
                return true;
        }
        private static string FloatToString(float other)
        {
            return other.ToString();
        }
        private static float IntToFloat(int other)
        {
            return (float)other;
        }
        private static char IntToChar(int other)
        {
            return (char)(other - '0');
        }
        private static double IntToDouble(int other)
        {
            return Convert.ToDouble(other);
        }
        private static bool IntToBool(int other)
        {
            if (other == 0)
                return true;
            else
                return false;
        }
        private static string IntToString(int other)
        {
            return other.ToString();
        }

        private void convertTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mutable)
                MessageBox.Show("Данный список является не изменяемым", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (type == 7)
                    MessageBox.Show("Данный тип не поддерживает конвертации", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FormConvertType form = new FormConvertType();
                    form.ShowDialog();
                    switch(form.choice)//TO
                    {
                        case 1:
                            switch(type)//TI
                            {
                                case 1:
                                    switch(realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<int, int>(list_int, convertIntToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<int, int>(list_int, convertIntToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch(realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<float, int>(list_float, convertFloatToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<float, int>(list_float, convertFloatToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_float.Clear();
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch(realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<char, int>(list_char, convertCharToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<char, int>(list_char, convertCharToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_char.Clear();
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch(realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<double, int>(list_double, convertDoubleToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<double, int>(list_double, convertDoubleToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_double.Clear();
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<bool, int>(list_bool, convertBoolToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<bool, int>(list_bool, convertBoolToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_bool.Clear();
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_int = ListUtils.SetUtils.ConvertAll<string, int>(list_string, convertStringToInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                            break;
                                        case 2:
                                            list_int = ListUtils.SetUtils.ConvertAll<string, int>(list_string, convertStringToInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                            break;
                                    }
                                    list_string.Clear();
                                    list_int.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                        case 2:
                            switch (type)//TI
                            {
                                case 1:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<int, float>(list_int, convertIntToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<int, float>(list_int, convertIntToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_int.Clear();
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<float, float>(list_float, convertFloatToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<float, float>(list_float, convertFloatToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<char, float>(list_char, convertCharToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<char, float>(list_char, convertCharToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_char.Clear();
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<double, float>(list_double, convertDoubleToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<double, float>(list_double, convertDoubleToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_double.Clear();
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<bool, float>(list_bool, convertBoolToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<bool, float>(list_bool, convertBoolToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_bool.Clear();
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_float = ListUtils.SetUtils.ConvertAll<string, float>(list_string, convertStringToFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                            break;
                                        case 2:
                                            list_float = ListUtils.SetUtils.ConvertAll<string, float>(list_string, convertStringToFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                            break;
                                    }
                                    list_string.Clear();
                                    list_float.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                        case 3:
                            switch (type)//TI
                            {
                                case 1:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<int, char>(list_int, convertIntToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<int, char>(list_int, convertIntToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_int.Clear();
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<float, char>(list_float, convertFloatToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<float, char>(list_float, convertFloatToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_float.Clear();
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<char, char>(list_char, convertCharToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<char, char>(list_char, convertCharToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<double, char>(list_double, convertDoubleToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<double, char>(list_double, convertDoubleToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_double.Clear();
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<bool, char>(list_bool, convertBoolToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<bool, char>(list_bool, convertBoolToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_bool.Clear();
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_char = ListUtils.SetUtils.ConvertAll<string, char>(list_string, convertStringToChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                            break;
                                        case 2:
                                            list_char = ListUtils.SetUtils.ConvertAll<string, char>(list_string, convertStringToChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                            break;
                                    }
                                    list_string.Clear();
                                    list_char.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                        case 4:
                            switch (type)//TI
                            {
                                case 1:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<int, double>(list_int, convertIntToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<int, double>(list_int, convertIntToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_int.Clear();
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<float, double>(list_float, convertFloatToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<float, double>(list_float, convertFloatToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_float.Clear();
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<char, double>(list_char, convertCharToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<char, double>(list_char, convertCharToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_char.Clear();
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<double, double>(list_double, convertDoubleToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<double, double>(list_double, convertDoubleToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<bool, double>(list_bool, convertBoolToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<bool, double>(list_bool, convertBoolToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_bool.Clear();
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_double = ListUtils.SetUtils.ConvertAll<string, double>(list_string, convertStringToDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                            break;
                                        case 2:
                                            list_double = ListUtils.SetUtils.ConvertAll<string, double>(list_string, convertStringToDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                            break;
                                    }
                                    list_string.Clear();
                                    list_double.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                        case 5:
                            switch (type)//TI
                            {
                                case 1:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<int, bool>(list_int, convertIntToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<int, bool>(list_int, convertIntToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_int.Clear();
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<float, bool>(list_float, convertFloatToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<float, bool>(list_float, convertFloatToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_float.Clear();
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<char, bool>(list_char, convertCharToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<char, bool>(list_char, convertCharToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_char.Clear();
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<double, bool>(list_double, convertDoubleToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<double, bool>(list_double, convertDoubleToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_double.Clear();
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<bool, bool>(list_bool, convertBoolToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<bool, bool>(list_bool, convertBoolToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_bool = ListUtils.SetUtils.ConvertAll<string, bool>(list_string, convertStringToBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                            break;
                                        case 2:
                                            list_bool = ListUtils.SetUtils.ConvertAll<string, bool>(list_string, convertStringToBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                            break;
                                    }
                                    list_string.Clear();
                                    list_bool.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                        case 6:
                            switch (type)//TI
                            {
                                case 1:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<int, string>(list_int, convertIntToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<int, string>(list_int, convertIntToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_int.Clear();
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 2:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<float, string>(list_float, convertFloatToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<float, string>(list_float, convertFloatToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_float.Clear();
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 3:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<char, string>(list_char, convertCharToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<char, string>(list_char, convertCharToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_char.Clear();
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 4:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<double, string>(list_double, convertDoubleToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<double, string>(list_double, convertDoubleToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_double.Clear();
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 5:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<bool, string>(list_bool, convertBoolToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<bool, string>(list_bool, convertBoolToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_bool.Clear();
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                                case 6:
                                    switch (realization)
                                    {
                                        case 1:
                                            list_string = ListUtils.SetUtils.ConvertAll<string, string>(list_string, convertStringToString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                            break;
                                        case 2:
                                            list_string = ListUtils.SetUtils.ConvertAll<string, string>(list_string, convertStringToString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                            break;
                                    }
                                    list_string.Save(path, form.choice, realization, mutable);
                                    panel_load_label();
                                    break;
                            }
                            break;
                    }
                    type = form.choice;
                    ChangeTextLabelType();
                }
            }
        }

        private static bool Compare_ToInt_less(int a, int b)
        {
            return a < b;
        }
        private static bool Compare_ToFloat_less(float a, float b)
        {
            return a < b;
        }
        private static bool Compare_ToChar_less(char a, char b)
        {
            return a < b;
        }
        private static bool Compare_ToDouble_less(double a, double b)
        {
            return a < b;
        }
        private static bool Compare_ToBool_less(bool a, bool b)
        {
            return a == b;
        }
        private static bool Compare_ToString_less(string a, string b)
        {
            return a.Length < b.Length;
        }
        private static bool Compare_ToMyType_less(MyType a, MyType b)
        {
            return a.CompareTo(b) == -1;
        }
        private static bool Compare_ToInt_more(int a, int b)
        {
            return a > b;
        }
        private static bool Compare_ToFloat_more(float a, float b)
        {
            return a > b;
        }
        private static bool Compare_ToChar_more(char a, char b)
        {
            return a > b;
        }
        private static bool Compare_ToDouble_more(double a, double b)
        {
            return a > b;
        }
        private static bool Compare_ToBool_more(bool a, bool b)
        {
            return a != b;
        }
        private static bool Compare_ToString_more(string a, string b)
        {
            return a.Length > b.Length;
        }
        private static bool Compare_ToMyType_more(MyType a, MyType b)
        {
            return a.CompareTo(b) == 1;
        }
        private static bool isOddInt_(int a)
        {
            return a % 2 == 0;
        }
        private static bool isOddFloat_(float a)
        {
            return a % 2 == 0;
        }
        private static bool isOddChar_(char a)
        {
            return a % 2 == 0;
        }
        private static bool isOddDouble_(double a)
        {
            return a % 2 == 0;
        }
        private static bool isOddBool_(bool a)
        {
            return a;
        }
        private static bool isOddString_(string a)
        {
            return a.Length % 2 == 0;
        }
        private static bool isOddMyType_(MyType b)
        {
            return b.name.Length % 2 == 0;
        }

        private static bool isntOddInt_(int a)
        {
            return a % 2 != 0;
        }
        private static bool isntOddFloat_(float a)
        {
            return a % 2 != 0;
        }
        private static bool isntOddChar_(char a)
        {
            return a % 2 != 0;
        }
        private static bool isntOddDouble_(double a)
        {
            return a % 2 != 0;
        }
        private static bool isntOddBool_(bool a)
        {
            return a;
        }
        private static bool isntOddString_(string a)
        {
            return a.Length % 2 != 0;
        }
        private static bool isntOddMyType_(MyType b)
        {
            return b.name.Length % 2 != 0;
        }

        private void addFindList()
        {
            DataNode n;
            n.name = "Find_el";
            n.date = Convert.ToString(DateTime.Now);
            string pathname = "Lists/List_Find_el";
            Directory.CreateDirectory(pathname);
            pathname += '\\' + "Find_el.bin";
            File.Create(pathname).Close();
            FileInfo file = new FileInfo(pathname);
            n.path = file.DirectoryName + '\\' + "Find_el.bin";
            data.Add(n);
            path = n.path;
            nameList = n.name;
            StreamWriter fileW = new StreamWriter(File.Open(n.path, FileMode.Open));
            fileW.WriteLine("+");
            fileW.WriteLine(type);
            fileW.WriteLine(realization);
            fileW.Close();
            bool isPath = false;
            bool isName = false;
            NodeButton current = list_buttons.head;
            while (current != null && !isName)
            {
                if (current.node.name == nameList || current.node.name == path)
                {
                    isName = true;
                    if (current.node.path == path)
                        isPath = true;
                    else
                        nameList = path;
                }
                current = current.next;
            }
            if (panel1.Controls.Count < 17)
            {
                if (!isPath)
                {
                    foreach (Button element in panel1.Controls)
                    {
                        element.BackColor = Color.DarkSlateGray;
                        element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                        element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                    }
                    Button button = new Button();
                    list_buttons.Add(path, nameList, type, realization, mutable);
                    button.Text = nameList;
                    button.Name = "button";
                    button.BackColor = Color.OrangeRed;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                    button.FlatAppearance.MouseOverBackColor = Color.Tomato;
                    button.Width = 90;
                    button.Height = 30;
                    button.TabIndex = 3;
                    button.Visible = true;
                    button.Font = new Font("Consolas", 14);
                    button.ForeColor = Color.White;
                    button.Location = new Point((list_buttons.Count - 1) * 100, 0);
                    button.Click += new EventHandler(button_click);
                    ToolTip toolTip_1 = new ToolTip();
                    toolTip_1.AutoPopDelay = 5000;
                    toolTip_1.InitialDelay = 200;
                    toolTip_1.ReshowDelay = 200;
                    toolTip_1.ShowAlways = true;
                    toolTip_1.SetToolTip(button, path);
                    //Load_Data_from_file(path);
                    panel1.Controls.Add(button);
                }
                else
                    foreach (Button element in panel1.Controls)
                    {
                        if (element.Text == nameList)
                        {
                            element.BackColor = Color.OrangeRed;
                            element.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                            element.FlatAppearance.MouseOverBackColor = Color.Tomato;
                        }
                        else
                        {
                            element.BackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
                            element.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                        }
                    }
            }
            else
            {
                if (!isPath)
                {
                    toolStripMenuItem1.DropDownItems.Add(nameList);
                    list_buttons.Add(path, Name, type, realization, mutable);
                    foreach (ToolStripMenuItem m in menuStrip2.Items)
                    {
                        SetColor_1(m);
                    }
                    toolStripMenuItem1.ForeColor = Color.DarkGray;
                    menuStrip2.Visible = true;
                }
            }
        }
        private void existsElementConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mutable)
                MessageBox.Show("Данный список является не изменяемым", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            { 
                FormCondition form = new FormCondition(type);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.doing)
                    {
                        case 1:
                            {
                                switch (realization)
                                {
                                    case 1:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll<int>(list_int, isOddInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll<float>(list_float, isOddFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll<char>(list_char, isOddChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll<double>(list_double, isOddDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll<bool>(list_bool, isOddBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll<string>(list_string, isOddString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll<MyType>(list_myType, isOddMyType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                    case 2:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll<int>(list_int, isOddInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll<float>(list_float, isOddFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll<char>(list_char, isOddChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll<double>(list_double, isOddDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll<bool>(list_bool, isOddBool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll<string>(list_string, isOddString, ListUtils.SetUtils.ArrayListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll<MyType>(list_myType, isOddMyType, ListUtils.SetUtils.ArrayListConstructor<MyType>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 2:
                            {
                                switch (realization)
                                {
                                    case 1:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll<int>(list_int, isntOddInt, ListUtils.SetUtils.LinkedListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll<float>(list_float, isntOddFloat, ListUtils.SetUtils.LinkedListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll<char>(list_char, isntOddChar, ListUtils.SetUtils.LinkedListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll<double>(list_double, isntOddDouble, ListUtils.SetUtils.LinkedListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll<bool>(list_bool, isntOddBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll<string>(list_string, isntOddString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll<MyType>(list_myType, isntOddMyType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                    case 2:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll<int>(list_int, isntOddInt, ListUtils.SetUtils.ArrayListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll<float>(list_float, isntOddFloat, ListUtils.SetUtils.ArrayListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll<char>(list_char, isntOddChar, ListUtils.SetUtils.ArrayListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll<double>(list_double, isntOddDouble, ListUtils.SetUtils.ArrayListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll<bool>(list_bool, isntOddBool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll<string>(list_string, isntOddString, ListUtils.SetUtils.LinkedListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll<MyType>(list_myType, isntOddMyType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 3:
                            {
                                switch (realization)
                                {
                                    case 1:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll_<int>(list_int, CompareToIntMore, form.result_int, ListUtils.SetUtils.LinkedListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll_<float>(list_float, CompareToFloatMore, form.result_float, ListUtils.SetUtils.LinkedListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll_<char>(list_char, CompareToCharMore, form.result_char, ListUtils.SetUtils.LinkedListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll_<double>(list_double, CompareToDoubleMore, form.result_double, ListUtils.SetUtils.LinkedListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll_<bool>(list_bool, CompareToBoolMore, form.result_bool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll_<string>(list_string, CompareToStringMore, form.result_string, ListUtils.SetUtils.LinkedListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll_<MyType>(list_myType, CompareToMyTypeMore, form.result_myType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                    case 2:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll_<int>(list_int, CompareToIntMore, form.result_int, ListUtils.SetUtils.ArrayListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll_<float>(list_float, CompareToFloatMore, form.result_float, ListUtils.SetUtils.ArrayListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll_<char>(list_char, CompareToCharMore, form.result_char, ListUtils.SetUtils.ArrayListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll_<double>(list_double, CompareToDoubleMore, form.result_double, ListUtils.SetUtils.ArrayListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll_<bool>(list_bool, CompareToBoolMore, form.result_bool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll_<string>(list_string, CompareToStringMore, form.result_string, ListUtils.SetUtils.ArrayListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll_<MyType>(list_myType, CompareToMyTypeMore, form.result_myType, ListUtils.SetUtils.ArrayListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 4:
                            {
                                switch (realization)
                                {
                                    case 1:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll_<int>(list_int, CompareToIntLess, form.result_int, ListUtils.SetUtils.LinkedListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll_<float>(list_float, CompareToFloatLess, form.result_float, ListUtils.SetUtils.LinkedListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll_<char>(list_char, CompareToCharLess, form.result_char, ListUtils.SetUtils.LinkedListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll_<double>(list_double, CompareToDoubleLess, form.result_double, ListUtils.SetUtils.LinkedListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll_<bool>(list_bool, CompareToBoolLess, form.result_bool, ListUtils.SetUtils.LinkedListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll_<string>(list_string, CompareToStringLess, form.result_string, ListUtils.SetUtils.LinkedListConstructor<string>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll_<MyType>(list_myType, CompareToMyTypeLess, form.result_myType, ListUtils.SetUtils.LinkedListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                    case 2:
                                        switch (type)
                                        {
                                            case 1:
                                                list_int = ListUtils.SetUtils.FindAll_<int>(list_int, CompareToIntLess, form.result_int, ListUtils.SetUtils.ArrayListConstructor<int>);
                                                addFindList();
                                                list_int.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 2:
                                                list_float = ListUtils.SetUtils.FindAll_<float>(list_float, CompareToFloatLess, form.result_float, ListUtils.SetUtils.ArrayListConstructor<float>);
                                                addFindList();
                                                list_float.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 3:
                                                list_char = ListUtils.SetUtils.FindAll_<char>(list_char, CompareToCharLess, form.result_char, ListUtils.SetUtils.ArrayListConstructor<char>);
                                                addFindList();
                                                list_char.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 4:
                                                list_double = ListUtils.SetUtils.FindAll_<double>(list_double, CompareToDoubleLess, form.result_double, ListUtils.SetUtils.ArrayListConstructor<double>);
                                                addFindList();
                                                list_double.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 5:
                                                list_bool = ListUtils.SetUtils.FindAll_<bool>(list_bool, CompareToBoolLess, form.result_bool, ListUtils.SetUtils.ArrayListConstructor<bool>);
                                                addFindList();
                                                list_bool.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 6:
                                                list_string = ListUtils.SetUtils.FindAll_<string>(list_string, CompareToStringLess, form.result_string, ListUtils.SetUtils.ArrayListConstructor<string>);
                                                addFindList();
                                                list_string.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                            case 7:
                                                list_myType = ListUtils.SetUtils.FindAll_<MyType>(list_myType, CompareToMyTypeLess, form.result_myType, ListUtils.SetUtils.ArrayListConstructor<MyType>);
                                                addFindList();
                                                list_myType.Save(path, type, realization, mutable);
                                                Load_Data_from_file(path);
                                                break;
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
