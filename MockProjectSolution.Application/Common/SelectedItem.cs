using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Common
{
    public class SelectedItem
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public bool Selected { set; get; }
        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}
