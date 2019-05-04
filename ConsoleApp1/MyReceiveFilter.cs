using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyReceiveFilter : TerminatorReceiveFilter<StringPackageInfo>
    {
        public MyReceiveFilter()
        : base(Encoding.ASCII.GetBytes(Environment.NewLine)) // two vertical bars as package terminator
        {
        }

        public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            var stringPackageInfo = new StringPackageInfo("ADD", bufferStream.ReadString((int)bufferStream.Length, Encoding.ASCII), null);

            return stringPackageInfo;
        }

    }
}
