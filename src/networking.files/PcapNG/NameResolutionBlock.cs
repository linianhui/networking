using System;
using System.Collections.Generic;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Name Resolution Block
    /// <see href="https://pcapng.github.io/pcapng/#section_nrb"/>
    /// </summary>
    public partial class NameResolutionBlock : Block
    {
        /// <summary>
        /// 读取<see cref="Record"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Record> GetRecords()
        {
            var begin = Block.Layout.HeaderLength;
            var (recordType, recordLength) = GetRecordHeader(begin);
            while (recordType != RecordType.End)
            {
                yield return new Record
                {
                    IsLittleEndian = IsLittleEndian,
                    Bytes = GetBytes(begin, recordLength)
                };
                begin += recordLength;
                (recordType, recordLength) = GetRecordHeader(begin);
            }
        }

        private (RecordType recordType, Int32 recordValueLength) GetRecordHeader(Int32 begin)
        {
            var recordType = (RecordType)base.GetUInt16(begin);
            var recordValueLength = (Int32)base.GetUInt16(begin + 2);
            var i = recordValueLength % 4;
            if (i != 0)
            {
                recordValueLength = recordValueLength + 4 - i;
            }
            return (recordType, recordValueLength + 4);
        }
    }
}
