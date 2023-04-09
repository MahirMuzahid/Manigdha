using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Enums
{
    public class SnakeBarType
    {
        public enum Type
        {
            Danger,
            Success,
            Normal,
            Warning,
            Info,
        }
        public enum Time
        {
            ShortTime = 3,
            LongTime = 6
        }

        public string TypeToColor(Type type)
        {
            if(type == Type.Danger) { return "#CC3636"; }
            if (type == Type.Success) { return "#169851"; }
            if (type == Type.Normal) { return "#3D3D3D"; }
            if (type == Type.Warning) { return "#8E9009"; }
            if (type == Type.Info) { return "#1D98B9"; }

            return "#000000";
        }
    }
}
