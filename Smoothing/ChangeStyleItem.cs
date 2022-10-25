using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_14
{
    public class ChangeStyleItem : ProfessionalColorTable
    {
        public override Color MenuItemSelected { get { return Color.LightSteelBlue; } }
        public override Color ToolStripBorder { get { return Color.Transparent; } }
        public override Color ToolStripDropDownBackground { get { return Color.White; } }
        public override Color ImageMarginGradientBegin { get { return Color.White; } }
        public override Color ImageMarginGradientEnd { get { return Color.White; } }
        public override Color ImageMarginGradientMiddle { get { return Color.White; } }
        public override Color MenuItemSelectedGradientBegin { get { return Color.LightSteelBlue; } }
        public override Color MenuItemSelectedGradientEnd { get { return Color.LightSteelBlue; } }
        public override Color MenuItemPressedGradientBegin { get { return Color.LightSteelBlue; } }
        public override Color MenuItemPressedGradientEnd { get { return Color.LightSteelBlue; } }
        public override Color MenuItemBorder { get { return Color.Blue; } }
    }
}
