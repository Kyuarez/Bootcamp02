using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TKPacket
{
    
    [MessagePackObject]
    public class TKPacket
    {
        [Key(0)]
        public int PacketID { get; set; }

    }

    [MessagePackObject]
    public class TKPacketDoubleOperation : TKPacket
    {
        [Key(1)]
        public int Operand1 { get; set; }
        [Key(2)]
        public int Operand2 { get; set; }
        [Key(3)]
        public string Operator { get; set; }


        public int Execute()
        {
            if (Operator.CompareTo("+") == 0 || Operator.CompareTo("-") == 0 || Operator.CompareTo("*") == 0 || Operator.CompareTo("/") == 0)
            {
                int result = 0;
                switch (Operator)
                {
                    case "+":
                        result = Operand1 + Operand2;
                        break;
                    case "-":
                        result = Operand1 - Operand2;
                        break;
                    case "*":
                        result = Operand1 * Operand2;
                        break;
                    case "/":
                        result = Operand1 / Operand2;
                        break;
                    default:
                        break;
                }
                return result;
            }
            
            return int.MaxValue;
        }
    }
}
