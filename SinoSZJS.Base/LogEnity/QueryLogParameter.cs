﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.LogEnity
{
    [DataContract]
    public class QueryLogParameter
    {
        [DataMember]
        public DateTime SDate { get; set; }
        [DataMember]
        public DateTime EDate { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string KeyWord { get; set; }
        //public bool OnlyFirst { get; set; }
    }
}
