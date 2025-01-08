using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class User
    {
            [DataMember]
            public int userId { get; set; }
            [DataMember]
            public string email { get; set; }
            [DataMember]
            public string password { get; set; }
            [DataMember]
            public bool isActive { get; set; }
            [DataMember]
            public int roleId { get; set; }
    }
}
