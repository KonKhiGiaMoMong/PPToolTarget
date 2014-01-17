using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTargetTools.DataObject
{
    public class StyleObject
    {
        public StyleObject(string styleName,string value,string parent) {
            _styleName = styleName;
            _value = value;
            _paretnName = parent;
        }

        public string styleName { get { return _styleName;} set{_styleName=value;} }
        public string value { get { return _value; } set { _value = value; } }
        public string parentName { get; set; }

        private string _value;
        private string _styleName;
        private string _paretnName;

        public override string ToString()
        {
            return styleName.Trim();
        }
    }
}
