using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Role
    {
        [DataMember]
        public int roleId { get; set; }
        [DataMember]
        public string role { get; set; }
    }

}
