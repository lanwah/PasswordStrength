using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PasswordStrength
{
    /// <summary>
    /// 强度提示条
    /// </summary>
    [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class PasswordBar
    {
        /// <summary>
        /// 强度提示条内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 强度提示条颜色
        /// </summary>
        public Color BarColor
        {
            get;
            set;
        }
    }
}
